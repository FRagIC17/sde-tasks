using System.Media;
using System.Net.Http.Headers;
namespace mozart_opgave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What instrument do you want to use? \npiano\nmbira\nflute-harp\nclarinet");
            String instrumentInput = Console.ReadLine();
            Console.WriteLine("minuet or trio??");
            String minuetOrTrio = Console.ReadLine();

            PlayInstrument(instrumentInput, minuetOrTrio);

            static void PlayInstrument(String instrumentInput, String minuetOrTrio) {
                Die dice = new Die();

                PathFinder pathFinder = new PathFinder(Path.Combine("mozart", instrumentInput.ToLower()));
                string filePath = pathFinder.FilePath;
                Console.WriteLine(filePath);

                for (int i = 0; i <= 15; i++)
                {
                    int roll = 0;
                    if (minuetOrTrio.ToLower() == "trio") {
                        roll = dice.roll();
                    } else
                    {
                        roll = dice.roll() + dice.roll();
                    }
                    Console.WriteLine($"Rolled a {roll}");
                    string soundFile = Path.Combine(filePath, $"{minuetOrTrio}{i}-{roll}.wav");
                    Console.WriteLine(soundFile);
                    using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundFile))
                    {
                        player.PlaySync();
                    } 
                }
            }

        }

    }
}

public class PathFinder
{
    public string FilePath { get; set; }
    public PathFinder(string filePath)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        FilePath = Path.Combine(currentDirectory, filePath);

    }
}

public class Die
{
    public int roll()
    {
        Random random = new Random();
        return random.Next(1, 7);
    }
}

   
