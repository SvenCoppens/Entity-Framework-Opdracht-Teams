using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_Teams
{
    public class Transfer
    {
        public int TransferID { get; set; }
        public int SpelerID { get; set; }
        public Speler Speler { get; set; }
        public int TransferPrijs { get; set; }
        public int NieuwTeamID { get; set; }
        public Team NieuwTeam { get; set; }
        public int OudTeamID { get; set; }
        public Team OudTeam { get; set; }
    }
}
