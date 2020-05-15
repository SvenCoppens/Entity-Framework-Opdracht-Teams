using System;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is Speler speler &&
                   Naam.Equals(speler.Naam) &&
                   RugNummer == speler.RugNummer &&
                   TransferWaarde == speler.TransferWaarde;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Naam, RugNummer, TransferWaarde);
        }

        public void SetTeam(Team team)
        {
            Team = team;
            TeamStamNummer = team.StamNummer;
        }
    }
}
