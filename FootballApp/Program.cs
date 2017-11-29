using FootballApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballApp
{
    class Program
    { 

        static FootballModel db = new FootballModel();
        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateArena();
                        break;
                    case "2":
                        ShowAllArenas();
                        break;
                    case "3":
                        CreateTeam();
                        break;
                    case "4":
                        ShowAllTeams();
                        break;
                    case "5":
                        CreatePlayer();
                        break;
                    case "6":
                        ShowPlayersInTeam();
                        break;
                    case "A":
                        return;

                }

            }
            

        }

        private static void ShowPlayersInTeam()
        {
            Console.WriteLine("Välj först ett lag");
            ShowAllTeams();
            var teamName = Console.ReadLine();
            var team = db.Teams.Single(aTeam => aTeam.Name == teamName);
            foreach (var aPlayer in db.Players.Where(player => player.Teams.Id == team.Id))
            {
                Console.WriteLine(aPlayer.Name);
            }
        }

        private static void CreatePlayer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Välj först ett lag");
            ShowAllTeams();
            var teamName = Console.ReadLine();
            var team = db.Teams.Single(aTeam => aTeam.Name == teamName);
            Console.WriteLine("Ange ett spelare");
            var playerName = Console.ReadLine();
            db.Players.Add(new Players { Name = playerName, Teams=team });
            db.SaveChanges();
        }

        private static void ShowAllTeams()
        {
            foreach (var aTeam in db.Teams)
            {
                Console.WriteLine(aTeam.Name);
            }
        }

        private static void CreateTeam()
        {
            Console.WriteLine("Ange ett lag namn");
            var teamName = Console.ReadLine();
            db.Teams.Add(new Teams { Name = teamName });
            db.SaveChanges();
        }

        private static void ShowAllArenas()
        {
            foreach (var aArena in db.Arenas)
            {
                Console.WriteLine(aArena.Name);
            }
        }

        private static void CreateArena()
        {
            Console.WriteLine("Ange ett arena namn");
            var arenaName = Console.ReadLine();
            db.Arenas.Add(new Arenas { Name = arenaName });
            db.SaveChanges();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("1. Skapa en arena");
            Console.WriteLine("2. Lista alla arenor");
            Console.WriteLine("3. Skapa ett lag");
            Console.WriteLine("4. Lista alla lag");
            Console.WriteLine("5. Skapa en spelare");
            Console.WriteLine("6. Lista ett lag och dess spelare");
            Console.WriteLine("A. Avsluta");
        }
    }
   
}
