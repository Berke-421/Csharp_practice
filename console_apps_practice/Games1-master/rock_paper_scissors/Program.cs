using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Oluşturulma tarihi/Created At: 12 June/Haziran 2025 

namespace ROCK_PAPER_SCISSORS
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter your name");
            string? name;

            while (true) // name input area
            {
                name = Console.ReadLine();

                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Please enter a valid name.");
                    continue;
                }

                foreach (char ch in name)
                {
                    if (!char.IsLetterOrDigit(ch) && ch != ' ')
                    {
                        Console.WriteLine("Name cannot contain special characters");
                        continue;
                    }

                    else break;
                }

                Console.WriteLine($"{name} name verified");
                break;
            }

            PlayRockPaperScissors();
        }

        public static void ShowStatus(string selected, int playerLives, int computerLives)
        {
            Console.WriteLine(new string('-', 20));
            Console.WriteLine($"Computer: {selected}");
            Console.WriteLine("Draw");
            Console.WriteLine($"Your lives: {playerLives}");
            Console.WriteLine($"Computer lives: {computerLives}");
            Console.WriteLine(new string('-', 20));
        }

        public static void PlayRockPaperScissors()
        {
            Console.WriteLine("Welcome to Rock Paper Scissors");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();

            List<string> options = new List<string> { "rock", "paper", "scissors" };
            int playerLives = 0;
            int computerLives = 0;
            string? selected;
            bool control3 = true;

            Console.WriteLine("Which difficulty level should the game use?");
            Console.WriteLine("1: EASY");
            Console.WriteLine("2: MEDIUM");
            Console.WriteLine("3: HARD");

            while (control3)
            {
                string? choice = Console.ReadLine();

                if (string.IsNullOrEmpty(choice))
                {
                    Console.WriteLine("Please enter a choice");
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        playerLives += 5;
                        control3 = false;
                        break;

                    case "2":
                        playerLives += 3;
                        control3 = false;
                        break;

                    case "3":
                        playerLives += 1;
                        control3 = false;
                        break;

                    default:
                        Console.WriteLine("No choice entered");
                        break;

                }
            }

            computerLives += 3;

            for (; playerLives > 0 && computerLives > 0;)
            {
                try
                {
                    Console.WriteLine("Rock Paper Scissors?");
                    selected = null;
                    Random rnd = new Random();
                    int index = rnd.Next(0, 3);
                    selected = options[index];

                    string? input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("Enter a choice");
                        continue;
                    }

                    input = input.ToLower();

                    if (
                        input == "scissors"
                        )
                    {
                        if (input == selected)
                        {
                            Console.WriteLine("Draw");
                            ShowStatus(selected, playerLives, computerLives);
                        }

                        if (selected == "paper")
                        {
                            computerLives -= 1;
                            Console.WriteLine("You scored a point");
                            ShowStatus(selected, playerLives, computerLives);
                        }

                        if (selected == "rock")
                        {
                            playerLives -= 1;
                            Console.WriteLine("Unfortunately");
                            ShowStatus(selected, playerLives, computerLives);
                        }
                    }

                    if (
                        input == "paper"
                        )
                    {
                        if (input == selected)
                        {
                            Console.WriteLine("Draw");
                            ShowStatus(selected, playerLives, computerLives);
                        }

                        if (selected == "scissors")
                        {
                            computerLives -= 1;
                            Console.WriteLine("You scored a point");
                            ShowStatus(selected, playerLives, computerLives);
                        }

                        if (selected == "paper")
                        {
                            playerLives -= 1;
                            Console.WriteLine("Unfortunately");
                            ShowStatus(selected, playerLives, computerLives);
                        }

                    }

                    if (
                        input == "rock"
                        )
                    {
                        if (input == selected)
                        {
                            Console.WriteLine("Draw");
                            ShowStatus(selected, playerLives, computerLives);
                        }

                        if (selected == "rock")
                        {
                            computerLives -= 1;
                            Console.WriteLine("You scored a point");
                            ShowStatus(selected, playerLives, computerLives);
                        }

                        if (selected == "scissors")
                        {
                            playerLives -= 1;
                            Console.WriteLine("Unfortunately");
                            ShowStatus(selected, playerLives, computerLives);
                        }
                    }

                }

                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter rock, paper, or scissors");
                    continue;
                }
            }

            if (computerLives > playerLives)
            {
                Console.WriteLine($"You lost");
            }
            return;
        }

    }
}