using System;

namespace TeamsLibrary
{
    public class Speler
    {
        public Speler(string naam,int rugNummer,int transferWaarde)
        {
            Naam = naam;
            RugNummer = rugNummer;
            TransferWaarde = transferWaarde;
        }
        public int SpelerID { get; set; }
        public string Naam { get; set; }
        public int RugNummer { get; set; }
        public int TransferWaarde { get; set; }
        public int TeamStamNummer { get; set; }
        public Team Team { get; set; }
        //public Transfer Transfer(Team nieuwTeam)
        //{
        //    Team oudTeam = Team;
        //    Team = nieuwTeam;
        //    TeamStamNummer = nieuwTeam.StamNummer;

        //    return new Transfer()
        //}
    }
}
