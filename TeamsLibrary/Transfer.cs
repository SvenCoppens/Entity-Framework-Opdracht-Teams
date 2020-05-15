using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeamsLibrary
{
    public class Transfer
    {
        public Transfer(Speler speler,Team nieuwTeam,Team oudTeam)
        {
            Speler = speler;
            NieuwTeam = nieuwTeam;
            OudTeam = oudTeam;
        }
        public int TransferID { get; set; }
        public Speler Speler { get; set; }
        public int TransferPrijs { get; set; }
        [Required]
        public Team NieuwTeam { get; set; }
        public Team OudTeam { get; set; }
    }
}
