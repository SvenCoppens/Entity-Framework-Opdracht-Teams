using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TeamsLibrary
{
    public class DatabaseHandler
    {
        public void AddFile(string Filepath)
        {
            using (SpelerContext context = new SpelerContext())
            {
                List<Speler> nieuweSpelers = new List<Speler>();
                using (StreamReader reader = File.OpenText(Filepath))
                {
                    reader.ReadLine();
                    string line;
                        Dictionary<int, Team> localTeams = new Dictionary<int, Team>();
                    while ((line = reader.ReadLine()) != null)
                    {
                        //dictionary zodat we altijd maar met een object van een team werken, anders geeft EF errosrs
                        string[] splitLine = line.Split(',');
                        string naam = splitLine[0];
                        int rugNummer = int.Parse(splitLine[1]);
                        string clubNaam = splitLine[2];
                        int waarde = int.Parse(splitLine[3].Replace(" ",""));
                        int stamNr = int.Parse(splitLine[4]);
                        string trainer = splitLine[5];
                        string bijnaam = splitLine[6];
                        Team team;
                        if (!localTeams.ContainsKey(stamNr))
                        {
                            if (!context.Teams.Any(t => t.StamNummer == stamNr))
                            {
                                team = new Team(stamNr, clubNaam, bijnaam, trainer);
                                context.Teams.Add(team);
                                localTeams.Add(stamNr, team);
                            }
                            else
                            {
                                team = context.Teams.Single(t => t.StamNummer == stamNr);
                                localTeams.Add(stamNr, team);
                            }
                        }
                        else
                            team = localTeams[stamNr];
                        
                        Speler temp = new Speler(naam, rugNummer, waarde);
                        temp.SetTeam(team);
                        //testing vanaf hier want dit is insane aan het worden





                        //tot hier
                        if (!context.Spelers.Any(s => s.Naam.Equals(temp.Naam) && s.RugNummer == temp.RugNummer && s.TransferWaarde == temp.TransferWaarde))
                        {
                            nieuweSpelers.Add(temp);
                        }
                        
                    }
                }
                context.Spelers.AddRange(nieuweSpelers);
                context.SaveChanges();
            }
        }
        public void VoegSpelerToe(Speler speler)
        {
            
            using(SpelerContext context = new SpelerContext())
            {
                if (context.Teams.Any(t => t.StamNummer == speler.TeamStamNummer))
                    speler.Team = context.Teams.Single(t => t.StamNummer == speler.TeamStamNummer);
                if (!(context.Spelers.Any(s => (s.SpelerID == speler.SpelerID) || (s.Naam == speler.Naam && s.RugNummer == speler.RugNummer && s.TeamStamNummer == speler.TeamStamNummer))))
                {
                    context.Spelers.Add(speler);
                    context.SaveChanges();
                }
                else
                {
                    System.Console.WriteLine($"De speler met de naam {speler.Naam} en ID {speler.SpelerID} bevindt zich al in de databank");
                }
            }
        }
        public void VoegTeamToe(Team team)
        {
            using(SpelerContext context = new SpelerContext())
            {
                if (context.Teams.Any(t => t.StamNummer == team.StamNummer))
                {
                    System.Console.WriteLine($"team met stamnummer {team.StamNummer} behoort al tot de teams");
                }
                else
                {
                    context.Teams.Add(team);
                    context.SaveChanges();
                }
            }
        }
        public void VoegTransferToe(Transfer transfer)
        {
            using (SpelerContext context = new SpelerContext())
            {
                if (context.Teams.Any(t => t.StamNummer == transfer.OudTeam.StamNummer))
                    transfer.OudTeam = context.Teams.Single(t => t.StamNummer == transfer.OudTeam.StamNummer);
                if (context.Teams.Any(t => t.StamNummer == transfer.NieuwTeam.StamNummer))
                    transfer.NieuwTeam = context.Teams.Single(t => t.StamNummer == transfer.NieuwTeam.StamNummer);
                if (!context.Spelers.Any(s => s.SpelerID == transfer.Speler.SpelerID))
                    transfer.Speler = context.Spelers.Single(s => s.SpelerID == transfer.Speler.SpelerID);
                context.Transfers.Add(transfer);
                context.SaveChanges();
            }
        }
        public void UpdateSpeler(Speler speler)
        {
            using(SpelerContext context = new SpelerContext())
            {
                Speler dataSpeler;
                if (speler.SpelerID != 0)
                {
                    dataSpeler = context.Spelers.Single(s => s.SpelerID == speler.SpelerID);
                    dataSpeler.Naam = speler.Naam;
                    dataSpeler.RugNummer = speler.RugNummer;
                    dataSpeler.TransferWaarde = speler.TransferWaarde;
                    context.SaveChanges();
                }
                else
                    System.Console.WriteLine($"Missing PlayerID for {speler.Naam}, unable to update");
                
            }
        }
        public void UpdateTeam(Team team)
        {
            using (SpelerContext context = new SpelerContext())
            {
                if (context.Teams.Any(t => t.StamNummer == team.StamNummer))
                {
                    Team dataTeam = context.Teams.Single(t => t.StamNummer == team.StamNummer);
                    dataTeam.Bijnaam = team.Bijnaam;
                    dataTeam.Naam = team.Naam;
                    dataTeam.Trainer = team.Trainer;
                    context.SaveChanges();
                }
                else throw new ArgumentException($"Team with StamNummer {team.StamNummer} was not found in the database");
            }
        }
        public Speler SelecteerSpeler(int spelerID)
        {
            using (SpelerContext context = new SpelerContext())
            {
                if (context.Spelers.Any(s => s.SpelerID == spelerID))
                { 
                    Speler dataSpeler = context.Spelers.Include(s => s.Team).Single(s => s.SpelerID == spelerID);
                    return dataSpeler;
                }
                else throw new ArgumentException("Invalid ID");
            }
        }
        public Team SelecteerTeam(int stamnummer)
        {
            using (SpelerContext context = new SpelerContext())
            {
                if (context.Teams.Any(t => t.StamNummer == stamnummer))
                {
                    Team dataTeam = context.Teams.Single(t => t.StamNummer == stamnummer);
                    return dataTeam;
                }
                else throw new ArgumentException($"Team with StamNummer {stamnummer} was not present in teh database");
            }
        }
        public Transfer SelecteerTransfer(int transferID)
        {
            using (SpelerContext context = new SpelerContext())
            {
                if (context.Transfers.Any(t => t.TransferID == transferID))
                {
                    Transfer dataTransfer = context.Transfers.Include(t => t.NieuwTeam).Include(t => t.OudTeam).Include(t => t.Speler).Single(t => t.TransferID == transferID);
                    return dataTransfer;
                }
                else throw new ArgumentException($"Transfer with ID {transferID} was not present in the database");
            }
        }
        public void TransferSpeler(Speler speler,Team nieuwteam)
        {
            using(SpelerContext context = new SpelerContext())
            {
                Team oudTeam;
                if ((oudTeam = context.Teams.Single(t => t.StamNummer == speler.TeamStamNummer)) != null)
                    speler.Team = oudTeam;
                if (context.Teams.Any(t => t.StamNummer == nieuwteam.StamNummer))
                    nieuwteam = context.Teams.Single(t => t.StamNummer == nieuwteam.StamNummer);
                if (context.Spelers.Any(s => s.SpelerID == speler.SpelerID))
                    speler = context.Spelers.Single(s => s.SpelerID == speler.SpelerID);

                Transfer transfer = new Transfer(speler, nieuwteam,oudTeam);
                transfer.TransferPrijs = speler.TransferWaarde;
                context.Transfers.Add(transfer);
                context.SaveChanges();
            }
        }
    }
}
