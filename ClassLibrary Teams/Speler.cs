using System;

namespace ClassLibrary_Teams
{
    public class Speler
    {
        public int SpelerID { get; set; }
        public string Naam { get; set; }
        public int RugNummer { get; set; }
        public int TransferWaarde { get; set; }
        public int TeamStamNummer { get; set; }
        public Team Team { get; set; }

    }
}
