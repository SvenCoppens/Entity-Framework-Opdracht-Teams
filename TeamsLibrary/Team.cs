using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TeamsLibrary
{
    public class Team
    {
        public Team(int stamNummer,string naam,string bijnaam,string trainer)
        {
            StamNummer = stamNummer;
            Naam = naam;
            Bijnaam = bijnaam;
            Trainer = trainer;
        }
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StamNummer { get; set; }
        public string Naam { get; set; }
        public string Bijnaam { get; set; }
        public string Trainer { get; set; }

        public ICollection<Speler> Spelers { get; set; } = new List<Speler>();
        public override bool Equals(object obj)
        {
            if (obj is Team)
                return StamNummer == (obj as Team).StamNummer;
            else return false;
        }
    }
}
