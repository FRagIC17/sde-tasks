using System.Security.Cryptography.X509Certificates;

namespace yatzy_spil
{
    internal class Program
    {
        public static Player[] playersArray;

        //husk og lav sådan at spillere for de mulige pointscoringer hver runde for hvad der er muligt
        static void Main(string[] args)
        {
            Console.WriteLine("Yatzy spil");
            Console.WriteLine("-------------------");
            CreatePlayers();
            Console.WriteLine("-------------------");
            PlayGame();
        }

        public static void CreatePlayers()
        {
            Console.Write("vælg antal spillere: ");
            String numberOfPlayers = Console.ReadLine();

            int players = 0;
            if (numberOfPlayers == null || !int.TryParse(numberOfPlayers, out players) || players < 1 || players > 6)
            {
                Console.WriteLine("Ugyldigt antal spillere. Prøv igen.");
                Environment.Exit(0);
            }

            playersArray = new Player[players];
            for (int i = 0; i < players; i++)
            {
                Console.Write($"Indtast navn for spiller {i + 1}: ");
                string playerName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    Console.WriteLine("Navn kan ikke være tomt. Prøv igen.");
                    i--;
                    continue;
                }
                playersArray[i] = new Player(playerName);
            }
        }

        public static void PlayGame()
        {
            Console.WriteLine("Spillet starter nu!");

            for (int currentPlayerIndex = 0; currentPlayerIndex < playersArray.Length; currentPlayerIndex++)
            {
                Player currentPlayer = playersArray[currentPlayerIndex];
                Console.WriteLine($"Tur for {currentPlayer.name}");

                int unselectedDice = 5; // Start with 5 dice for each player

                for (int turn = 1; turn <= 3 && unselectedDice > 0; turn++)
                {
                    Console.WriteLine($"Turn {turn} for {currentPlayer.name}");
                    DiceRolls(unselectedDice);

                    bool valid = false;
                    List<int> selectedIndices = new List<int>();

                    while (!valid)
                    {
                        Console.Write("Vælg hvilke terninger at beholde (f.eks. 1,3,5 eller 0 for at slå igen): ");
                        string input = Console.ReadLine();
                        if (input.Trim() == "0")
                        {
                            Console.WriteLine("Du har valgt at slå alle terninger igen.");
                            valid = true;
                            selectedIndices.Clear();
                            continue;
                        }

                        string[] inputArray = input.Split(',');
                        selectedIndices.Clear();
                        valid = true;

                        foreach (var item in inputArray)
                        {
                            if (int.TryParse(item.Trim(), out int idx) && idx >= 1 && idx <= unselectedDice)
                            {
                                if (!selectedIndices.Contains(idx))
                                    selectedIndices.Add(idx);
                            }
                            else
                            {
                                valid = false;
                                break;
                            }
                        }

                        if (!valid || selectedIndices.Count == 0)
                        {
                            Console.WriteLine("Ugyldigt valg. Prøv igen.");
                        }
                    }

                    if (selectedIndices.Count > 0)
                    {
                        unselectedDice -= selectedIndices.Count;
                        currentPlayer.AddScore(selectedIndices.Count);
                        Console.WriteLine($"{currentPlayer.name} score: {currentPlayer.score}");
                    }

                    if (unselectedDice == 0)
                    {
                        Console.WriteLine("Alle terninger er valgt. Næste spillers tur.");
                        break;
                    }
                }
                Console.WriteLine("-------------------");
            }
            Console.WriteLine("Spillet er slut! Slutstilling:");
            foreach (var player in playersArray)
            {
                Console.WriteLine(player.ToString());
            }
        }

        public static void DiceRolls(int unselectedDice)
        {
            dice d = new dice();
            int[] diceRolls = new int[5];
            for (int i = 0; i < unselectedDice; i++)
            {
                diceRolls[i] = d.roll();
                Console.WriteLine($"Terning {i + 1}: {diceRolls[i]}");
            }
            Console.WriteLine("-------------------");
        }
    }

    public class Player
    {
        public string name { get; set; }
        public int score { get; set; }
        public Player(string name)
        {
            this.name = name;
            this.score = 0;
        }

        public void AddScore(int points)
        {
            score += points;
        }

        public void ResetScore()
        {
            score = 0;
        }

        public override string ToString()
        {
            return $"{name} - Score: {score}";
        }
    }


    public class dice
    {
        public int roll()
        {
            Random random = new Random();
            return random.Next(1, 7);
        }
    }
}
