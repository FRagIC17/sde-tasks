using System;
using System.Collections.Generic;
using System.Linq;

namespace rat_race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- RAT RACE ---");
            Console.Write("Antal spillere (1-6): ");
            int playerCount;

            while (!int.TryParse(Console.ReadLine(), out playerCount) || playerCount < 1 || playerCount > 6)
            {
                Console.Write("Ugyldigt input. Indtast et tal mellem 1 og 6: ");

            }

            // Opret bane
            Track track = RaceManager.CreateTrack("Desert Dash", 5000);

            // Opret spillere
            List<Player> players = new List<Player>();
            for (int i = 1; i <= playerCount; i++)
            {
                Console.Write($"Indtast navn for spiller {i}: ");
                string name = Console.ReadLine();
                players.Add(RaceManager.CreatePlayer(name, 1000));
            }

            // Opret rotter
            List<Rat> rats = new List<Rat>
            {
                RaceManager.CreateRat("Speedy"),
                RaceManager.CreateRat("Cheesy"),
                RaceManager.CreateRat("Squeaky"),
                RaceManager.CreateRat("Whiskers")
            };

            // Opret race
            Race race = RaceManager.CreateRace(1, rats, track);

            // Vis rotter
            Console.WriteLine("\nTilgængelige rotter:");
            for (int i = 0; i < rats.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {rats[i].Name}");
            }

            // Betting fase
            Console.WriteLine("\n--- Placer dine bets ---");
            foreach (var player in players)
            {
                Console.WriteLine($"\n{player.playerName}, du har {player.Money} kr.");
                Console.Write("Vælg rotte (indtast nummer): ");
                int ratChoice;
                while (!int.TryParse(Console.ReadLine(), out ratChoice) || ratChoice < 1 || ratChoice > rats.Count)
                {
                    Console.Write("Ugyldigt valg. Prøv igen: ");
                }

                Rat chosenRat = rats[ratChoice - 1];

                Console.Write($"Hvor meget vil du satse (maks {player.Money}): ");
                int amount;
                while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0 || amount > player.Money)
                {
                    Console.Write("Ugyldigt beløb. Prøv igen: ");
                }

                // Opret bet
                Bet bet = new Bet
                {
                    Player = player,
                    Race = race,
                    Rat = chosenRat,
                    Money = amount,
                    IsWinningBet = false
                };

                player.Bets.Add(bet);
                player.Money -= amount; // træk penge med det samme
                race.Bets.Add(bet);
            }

            Console.WriteLine("\n--- Start race ---\n");

            // Simuler racet
            RaceManager.ConductRace(race);

            // Vis race log
            Console.WriteLine(RaceManager.ViewRaceReport(race));

            // Find vinder
            Rat winner = race.GetWinner();
            Console.WriteLine($"\nVinderen er: {winner.Name}!");

            // Udbetal gevinster
            foreach (var bet in race.Bets)
            {
                if (bet.Rat == winner)
                {
                    bet.IsWinningBet = true;
                    int winnings = bet.Money * 2;
                    bet.Player.Money += winnings;
                    Console.WriteLine($"{bet.Player.playerName} vinder {winnings} kr.!");
                }
            }

            // Slutresultat
            Console.WriteLine("\n--- Slutresultat ---");
            foreach (var player in players)
            {
                Console.WriteLine($"{player.playerName}: {player.Money} kr.");
            }
        }
    }

    public class RaceManager
    {
        public static Race CreateRace(int RaceID, List<Rat> rats, Track track)
        {
            return new Race
            {
                RaceID = RaceID,
                RaceTrack = track,
                Rats = rats
            };
        }

        public static Track CreateTrack(string trackName, int trackLength)
        {
            return new Track
            {
                trackName = trackName,
                trackLength = trackLength
            };
        }

        public static void ConductRace(Race race)
        {
            race.ConductRace();
        }

        public static string ViewRaceReport(Race race)
        {
            return race.GetRaceReport();
        }

        public static Player CreatePlayer(string playerName, int money)
        {
            return new Player
            {
                playerName = playerName,
                Money = money
            };
        }

        public static Rat CreateRat(string name)
        {
            return new Rat
            {
                Name = name,
                Position = 0
            };
        }
    }

    public class Race
    {
        public int RaceID { get; set; }
        public List<Rat> Rats { get; set; } = new List<Rat>();
        public Track RaceTrack { get; set; }
        public List<Bet> Bets { get; set; } = new List<Bet>();

        private Rat winner;
        private string log = "";

        public void ConductRace()
        {
            RNG rng = new RNG();
            bool finished = false;

            Console.WriteLine($"Race {RaceID} på {RaceTrack.trackName} starter!\n");
            logRace($"Race {RaceID} på {RaceTrack.trackName} starter!");
            int round = 1;
            while (!finished)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Out.Flush();
                Console.WriteLine("");
                Console.WriteLine($"--- Round {round} ---");
                foreach (var rat in Rats)
                {
                    int move = rng.GetRandomNumber(50, 200);
                    rat.MoveRat(move);

                    string message = $"{rat.Name} løb {move}m, total: {rat.Position}m";
                    Console.WriteLine(message); // Show immediately
                    logRace(message);

                    if (rat.Position >= RaceTrack.trackLength)
                    {
                        winner = rat;
                        string winMessage = $"{rat.Name} har krydset målstregen og er VINDEREN!";
                        Console.WriteLine(winMessage);
                        logRace(winMessage);
                        finished = true;
                        break;
                    }
                }

                System.Threading.Thread.Sleep(300);
                Console.Out.Flush();
                Rat leader = Rats.OrderByDescending(r => r.Position).First();
                string leaderboard = $"{leader.Name} fører med {leader.Position}m!";
                Console.WriteLine("\n" + leaderboard);
                round++;
            }
        }



        public Rat GetWinner()
        {
            return winner;
        }

        public string GetRaceReport()
        {
            return log;
        }

        private void logRace(string message)
        {
            log += message + "\n";
        }
    }

    public class Track
    {
        public string trackName { get; set; }
        public int trackLength { get; set; }
    }

    public class RNG
    {
        Random random = new Random();
        public int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }
    }

    public class Player
    {
        public string playerName { get; set; }
        public int Money { get; set; }
        public List<Bet> Bets { get; set; } = new List<Bet>();
    }

    public class Rat
    {
        public string Name { get; set; }
        public int Position { get; set; }

        public void ResetRat()
        {
            Position = 0;
        }

        public int MoveRat(int distance)
        {
            Position += distance;
            if (Position < 0) Position = 0;
            return Position;
        }
    }

    public class Bet
    {
        public int Money { get; set; }
        public Player Player { get; set; }
        public Race Race { get; set; }
        public Rat Rat { get; set; }
        public bool IsWinningBet { get; set; }
    }
}
