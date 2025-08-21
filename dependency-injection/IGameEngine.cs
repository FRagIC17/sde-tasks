using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace dependency_injection
{
    public interface IGameEngine
    {
        public void Play();
    }

    public class GuessNumberGame : IGameEngine
    {
        public void Play()
        {
            Console.WriteLine("Welcome to the Guess the Number Game!");
            Random random = new Random();
            int numberToGuess = random.Next(1, 101);
            int userGuess = 0;
            Console.WriteLine("I have selected a number between 1 and 100. Try to guess it!");
            while (userGuess != numberToGuess)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out userGuess))
                {
                    if (userGuess < numberToGuess)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else if (userGuess > numberToGuess)
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You've guessed the number!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }
        }
    }

    public class RockPaperScissorsGame : IGameEngine
    {
        public void Play()
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            string[] choices = { "Rock", "Paper", "Scissors" };
            Random random = new Random();
            string computerChoice = choices[random.Next(choices.Length)];
            string userChoice = "";
            while (userChoice != "Rock" && userChoice != "Paper" && userChoice != "Scissors")
            {
                Console.Write("Enter your choice (Rock, Paper, Scissors): ");
                userChoice = Console.ReadLine();
                if (userChoice != "Rock" && userChoice != "Paper" && userChoice != "Scissors")
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            Console.WriteLine($"Computer chose: {computerChoice}");
            if (userChoice == computerChoice)
            {
                Console.WriteLine("It's a tie!");
            }
            else if ((userChoice == "Rock" && computerChoice == "Scissors") ||
                     (userChoice == "Paper" && computerChoice == "Rock") ||
                     (userChoice == "Scissors" && computerChoice == "Paper"))
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("You lose!");
            }
        }
    }

    public class GameRunner
    {
        private readonly IGameEngine _gameEngine;
        public GameRunner(IGameEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }
        public void Run()
        {
            _gameEngine.Play();
        }
    }
}
