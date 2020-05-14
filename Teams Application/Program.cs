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
            handler.VoegSpelerToe(testSpeler);
            Team testTeam = new Team(95, "Pelicans", "Pecs", "That homeless guy");
            handler.VoegTeamToe(testTeam);

            //Transfer testTransfer = new Transfer();
            //testTransfer.OudTeam = testTeam;
            //testTransfer.NieuwTeam = handler.SelecteerTeam(7);
            //testTransfer.Speler = testSpeler;

            //handler.VoegTransferToe(testTransfer);


        }
    }
}
