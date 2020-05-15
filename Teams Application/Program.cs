using System;
using TeamsLibrary;

namespace Teams_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DatabaseHandler handler = new DatabaseHandler();
            string testFile = @"D:\Programmeren Data en Bestanden\Entity Framework Opdracht\foot.csv";
            handler.AddFile(testFile);

            Speler testSpeler = new Speler("Sven", 12, 5);
            Team testTeam1 = new Team(95, "Pelicans", "Pels", "test trainer1");
            //methode 2
            handler.VoegTeamToe(testTeam1);
            testSpeler.SetTeam(testTeam1);
            //methode 1
            handler.VoegSpelerToe(testSpeler);
            testSpeler.SpelerID = 131;

            Speler naamSpeler = handler.SelecteerSpeler(125);
            naamSpeler.Naam = "nieuwe naam test";
            handler.UpdateSpeler(naamSpeler);

            testTeam1.Bijnaam = "Mets";
            handler.UpdateTeam(testTeam1);

            Team testTeam2 = new Team(2, "testTeam2", "team2", "trainer2");
            handler.VoegTeamToe(testTeam2);
            //verwerkt hierbinnen: methode 3
            handler.TransferSpeler(testSpeler, testTeam2);

            Transfer transfer = handler.SelecteerTransfer(25);
            Console.WriteLine(transfer);
            //Console.ReadKey();

        }
    }
}
