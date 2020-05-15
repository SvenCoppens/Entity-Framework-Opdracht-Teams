using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeamsLibrary
{
    public class Transfer
    {
        public Transfer()
        {

        }
        //public Transfer(int spelerID,int nieuwTeamStamNummer,int oudTeamStamNummer)
        //{
        //    SpelerID = spelerID;
        //    NieuwTeamStamNummer = nieuwTeamStamNummer;
        //    OudTeamStamNummer = oudTeamStamNummer;
        //}
        public Transfer(Speler speler,Team nieuwTeam,Team oudTeam)
        {
            Speler = speler;
            NieuwTeam = nieuwTeam;
            OudTeam = oudTeam;
        }
        public int TransferID { get; set; }
        //public int SpelerID { get; set; }
        public Speler Speler { get; set; }
        public int TransferPrijs { get; set; }
        [Required]
        //public int NieuwTeamStamNummer { get; set; }
        public Team NieuwTeam { get; set; }
        //public int OudTeamStamNummer { get; set; }
        public Team OudTeam { get; set; }
    }
}
