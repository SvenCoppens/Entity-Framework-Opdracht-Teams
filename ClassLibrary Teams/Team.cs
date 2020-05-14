using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary_Teams
{
    public class Team
    {
        [Key]
        public int TeamStamNummer { get; set; }
        public string Naam { get; set; }
        public string Bijnaam { get; set; }
        public string Trainer { get; set; }

        public ICollection<Speler> Spelers { get; set; } = new List<Speler>();
    }
}
