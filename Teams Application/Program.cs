using System;
using TeamsLibrary;

namespace Teams_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            //maak de nodige zaken required in de databank(naam van het team bijvoorbeeld)
            Console.WriteLine("Hello World!");
            DatabaseHandler handler = new DatabaseHandler();
            //string testFile = @"D:\Programmeren Data en Bestanden\Entity Framework Opdracht\foot.csv";
            //handler.AddFile(testFile);

            Speler testSpeler = new Speler("Sven", 12, 5);
            Team testTeam1 = new Team(95, "Pelicans", "Pels", "test trainer1");
            //handler.VoegTeamToe(testTeam1);
            testSpeler.SetTeam(testTeam1);
            handler.VoegSpelerToe(testSpeler);

            testSpeler.Naam = "nieuwe naam test";
            handler.UpdateSpeler(testSpeler);

            testTeam1.Bijnaam = "Mets";
            handler.UpdateTeam(testTeam1);

            Team testTeam2 = new Team(2, "testTeam2", "team2", "trainer2");
            handler.VoegTeamToe(testTeam2);
            handler.TransferSpeler(testSpeler, testTeam2);


        }
    }
}
