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
                        return;

                }

            }
            

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
            Console.WriteLine("5. Avsluta");
        }
    }
   
}
