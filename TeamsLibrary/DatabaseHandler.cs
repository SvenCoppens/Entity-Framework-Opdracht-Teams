using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;

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
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] splitLine = line.Split(',');
                        string naam = splitLine[0];
                        int rugNummer = int.Parse(splitLine[1]);
                        string clubNaam = splitLine[2];
                        int waarde = int.Parse(splitLine[3].Replace(" ",""));
                        int stamNr = int.Parse(splitLine[4]);
                        string trainer = splitLine[5];
                        string bijnaam = splitLine[6];
                        Team team;
                        if (context.Teams.Any(t => t.StamNummer == stamNr))
                        {
                            team = new Team(stamNr, clubNaam, bijnaam, trainer);
                        }
                        else team = context.Teams.Find(stamNr);
                        Speler temp = new Speler(naam, rugNummer, waarde);
                        temp.Team = team;
                        nieuweSpelers.Add(temp);
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
                context.Spelers.Add(speler);
                context.SaveChanges();
            }
        }
        public void VoegTeamToe(Team team)
        {
            using(SpelerContext context = new SpelerContext())
            {
                context.Teams.Add(team);
                context.SaveChanges();
            }
        }
        public void VoegTransferToe(Transfer transfer)
        {
            using (SpelerContext context = new SpelerContext())
            {
                context.Transfers.Add(transfer);
                context.SaveChanges();
            }
        }
        public void UpdateSpeler(Speler speler)
        {
            using(SpelerContext context = new SpelerContext())
            {
                Speler dataSpeler = context.Spelers.Single(s => s.SpelerID == speler.SpelerID);
                dataSpeler = speler;
                context.SaveChanges();
            }
        }
        public void UpdateTeam(Team team)
        {
            using (SpelerContext context = new SpelerContext())
            {
                Team dataTeam = context.Teams.Single(t => t.StamNummer == team.StamNummer);
                dataTeam = team; ;
                context.SaveChanges();
            }
        }
        public Speler SelecteerSpeler(int spelerID)
        {
            using (SpelerContext context = new SpelerContext())
            {
                Speler dataSpeler = context.Spelers.Include(s=>s.Team).Single(s => s.SpelerID == spelerID);
                return dataSpeler;
            }
        }
        public Team SelecteerTeam(int stamnummer)
        {
            using (SpelerContext context = new SpelerContext())
            {
                Team dataTeam = context.Teams.Single(t => t.StamNummer == stamnummer);
                return dataTeam;
            }
        }
        public Transfer SelecteerTransfer(int transferID)
        {
            using (SpelerContext context = new SpelerContext())
            {
                Transfer dataTransfer = context.Transfers.Include(t=>t.NieuwTeam).Include(t=>t.OudTeam).Single(t => t.TransferID== transferID);
                return dataTransfer;
            }
        }
        public void TransferSpeler(Speler speler,Team nieuwteam)
        {
            Team oudTeam = speler.Team;
            speler.Team = nieuwteam;
            Transfer transfer = new Transfer(speler, oudTeam, nieuwteam);
            VoegTransferToe(transfer);
            UpdateSpeler(speler);

        }
    }
}
