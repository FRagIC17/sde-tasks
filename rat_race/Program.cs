namespace rat_race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Track track = new Track
            {
                trackName = "Desert Dash",
                trackLength = 5000 
            };
        }
    }

    public class RaceManager
    {
        List<Track> tracks = new List<Track>();
        List<Player> players = new List<Player>();
        List<Race> races = new List<Race>();
        List<Rat> rats = new List<Rat>();

        public static Race CreateRace(int RaceID, List<Rat> rats, Track track)
        {
            
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

        }

        public static string ViewRaceReport(Race race)
        {

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

    public class Bookmaker
    {
        public List<Bet> Bets { get; set; } = new List<Bet>();
        public void PlaceBet(Player player, Rat rat, int amount)
        {
            if (player.Money >= amount)
            {
                player.Money -= amount;
                Bets.Add(new Bet { player = player, money = amount, IsWinningBet = false });
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds to place bet.");
            }
        }
        public void SettleBets(Rat winner)
        {
            foreach (var bet in Bets)
            {
                if (bet.rat == winner)
                {
                    bet.IsWinningBet = true;
                    bet.player.Money += bet.money * 2; // Assuming a simple 1:1 payout for winning bets
                }
            }
        }
    }

    public class Race
    {
        public int RaceID;
        List<Rat> Rats { get; set; } = new List<Rat>();

        public Track RaceTrack { get; set; }

        private Rat winner;

        private string log;

        public void ConductRace()
        {
            
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

        private int position;
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
        private int money { get; set; }
        private Player player { get; set; }
        private Race race { get; set; }
        private Rat rat { get; set; }

        public static void PayWinnings()
        {

        }
    }
}
