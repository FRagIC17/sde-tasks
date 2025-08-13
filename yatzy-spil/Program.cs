using System;
using System.Collections.Generic;
using System.Linq;

namespace yatzy_spil
{
    public class Program
    {
        public static Player[] playersArray;
        public static string[] categories = new string[]
        {
            "Ones", "Twos", "Threes", "Fours", "Fives", "Sixes",
            "One Pair", "Two Pairs", "Three of a Kind", "Four of a Kind",
            "Small Straight", "Large Straight", "Full House", "Chance", "Yatzy"
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("Yatzy spil");
            Console.WriteLine("-------------------");
            CreatePlayers();
            Console.WriteLine("-------------------");
            PlayGame();
        }

        public static void CreatePlayers()
        {
            Console.Write("Vælg antal spillere (2-6): ");
            if (!int.TryParse(Console.ReadLine(), out int players) || players < 2 || players > 6)
            {
                Console.WriteLine("Ugyldigt antal spillere. Afslutter.");
                Environment.Exit(0);
            }

            playersArray = new Player[players];
            for (int i = 0; i < players; i++)
            {
                Console.Write($"Indtast navn for spiller {i + 1}: ");
                string playerName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(playerName)) playerName = $"Spiller{i + 1}";
                playersArray[i] = new Player(playerName, categories.Length);
            }
        }

        public static void PlayGame()
        {
            for (int round = 0; round < categories.Length; round++)
            {
                Console.WriteLine($"\n--- Runde {round + 1} af {categories.Length} ---");

                foreach (Player currentPlayer in playersArray)
                {
                    Console.WriteLine($"\n{currentPlayer.Name}'s tur:");
                    int[] dice = new int[5];
                    bool[] held = new bool[5];

                    for (int rollNum = 1; rollNum <= 3; rollNum++)
                    {
                        RollDice(dice, held);

                        // Build a list of unheld dice indices for mapping
                        var unheldIndices = new List<int>();
                        for (int i = 0; i < dice.Length; i++)
                        {
                            if (!held[i])
                                unheldIndices.Add(i);
                        }

                        // Show only dice that are not held, but display as 1, 2, 3, ...
                        Console.WriteLine($"Kast {rollNum}:");
                        for (int i = 0; i < unheldIndices.Count; i++)
                        {
                            int dieIdx = unheldIndices[i];
                            Console.WriteLine($"terning {i + 1} : {dice[dieIdx]}");
                        }

                        if (rollNum < 4 && unheldIndices.Count > 0)
                        {
                            Console.Write("Indtast hvilke terninger at beholde (f.eks. 1,3,5 eller 0 for ingen): ");
                            string input = Console.ReadLine();
                            if (input.Trim() == "0") continue;

                            foreach (var part in input.Split(','))
                            {
                                if (int.TryParse(part.Trim(), out int idx) && idx >= 1 && idx <= unheldIndices.Count)
                                {
                                    held[unheldIndices[idx - 1]] = true;
                                }
                            }

                            // Stop rolling if all dice are held
                            if (held.All(h => h))
                            {
                                Console.WriteLine("Alle terninger er valgt. Slutter kast.");
                                break;
                            }
                        }
                    }



                    // Choose category
                    Console.WriteLine("Vælg en kategori:");
                    for (int i = 0; i < categories.Length; i++)
                    {
                        if (!currentPlayer.CategoryUsed[i])
                            Console.WriteLine($"{i + 1}. {categories[i]}");
                    }

                    int choice;
                    while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > categories.Length || currentPlayer.CategoryUsed[choice - 1])
                    {
                        Console.WriteLine("Ugyldigt valg. Prøv igen:");
                    }

                    int score = CalculateScore(dice, choice - 1);
                    currentPlayer.Score[choice - 1] = score;
                    currentPlayer.CategoryUsed[choice - 1] = true;

                    Console.WriteLine($"{currentPlayer.Name} fik {score} point i {categories[choice - 1]}");
                }
            }

            Console.WriteLine("\n--- Slutstilling ---");
            foreach (var player in playersArray)
            {
                int total = player.Score.Sum();
                Console.WriteLine($"{player.Name} - Total: {total}");
            }

            var winner = playersArray.OrderByDescending(p => p.Score.Sum()).First();
            Console.WriteLine($"\nVinderen er {winner.Name} med {winner.Score.Sum()} point!");
        }

        public static void RollDice(int[] dice, bool[] held)
        {
            Random rand = new Random();
            for (int i = 0; i < dice.Length; i++)
            {
                if (!held[i])
                    dice[i] = rand.Next(1, 7);
            }
        }

        public static int CalculateScore(int[] dice, int categoryIndex)
        {
            var counts = dice.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            int score = 0;

            switch (categoryIndex)
            {
                case 0: score = counts.ContainsKey(1) ? counts[1] * 1 : 0; break;
                case 1: score = counts.ContainsKey(2) ? counts[2] * 2 : 0; break;
                case 2: score = counts.ContainsKey(3) ? counts[3] * 3 : 0; break;
                case 3: score = counts.ContainsKey(4) ? counts[4] * 4 : 0; break;
                case 4: score = counts.ContainsKey(5) ? counts[5] * 5 : 0; break;
                case 5: score = counts.ContainsKey(6) ? counts[6] * 6 : 0; break;
                case 6: // One Pair
                    score = counts.Where(c => c.Value >= 2).OrderByDescending(c => c.Key).Select(c => c.Key * 2).FirstOrDefault();
                    break;
                case 7: // Two Pairs
                    var pairs = counts.Where(c => c.Value >= 2).OrderByDescending(c => c.Key).Take(2).ToList();
                    if (pairs.Count == 2) score = pairs.Sum(p => p.Key * 2);
                    break;
                case 8: // Three of a Kind
                    score = counts.Where(c => c.Value >= 3).Select(c => c.Key * 3).FirstOrDefault();
                    break;
                case 9: // Four of a Kind
                    score = counts.Where(c => c.Value >= 4).Select(c => c.Key * 4).FirstOrDefault();
                    break;
                case 10: // Small Straight (1-5)
                    score = dice.OrderBy(x => x).SequenceEqual(new[] { 1, 2, 3, 4, 5 }) ? 15 : 0;
                    break;
                case 11: // Large Straight (2-6)
                    score = dice.OrderBy(x => x).SequenceEqual(new[] { 2, 3, 4, 5, 6 }) ? 20 : 0;
                    break;
                case 12: // Full House
                    if (counts.Values.Contains(3) && counts.Values.Contains(2))
                        score = dice.Sum();
                    break;
                case 13: // Chance
                    score = dice.Sum();
                    break;
                case 14: // Yatzy
                    score = counts.Values.Contains(5) ? 50 : 0;
                    break;
            }

            return score;
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int[] Score { get; set; }
        public bool[] CategoryUsed { get; set; }

        public Player(string name, int categoryCount)
        {
            Name = name;
            Score = new int[categoryCount];
            CategoryUsed = new bool[categoryCount];
        }
    }
}
