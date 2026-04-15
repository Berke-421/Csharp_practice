using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUESS_THE_NUMBER
{
    // Oluşturulma tarihi/Created At: 5 July/Temmuz 2025
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the 1-100 guessing game:");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Console.WriteLine();
            Random random = new Random();
            int secretNumber = random.Next(1, 101);

            Console.WriteLine("Which difficulty level should the game use?");
            Console.WriteLine("1: Easy (5 lives)");
            Console.WriteLine("2: Medium (3 lives)");
            Console.WriteLine("3: Hard (1 life)");
            byte lives = 0;
            bool control = true;
            string? difficulty = Console.ReadLine();

            while (control)
            {
                switch (difficulty)
                {
                    case "1":
                        lives += 5;
                        control = false;
                        break;

                    case "2":
                        lives += 3;
                        control = false;
                        break;

                    case "3":
                        lives += 1;
                        control = false;
                        break;

                    default:
                        Console.WriteLine("No option entered");
                        difficulty = Console.ReadLine();
                        break;
                }
            }

            Console.WriteLine("Make a guess");
            for (; lives > 0;)
            {
                try
                {
                    int guess = Convert.ToInt32(Console.ReadLine());
                    if (guess == 999)
                    {
                        Console.WriteLine($"Answer: {secretNumber}");
                    }

                    if (guess == secretNumber)
                    {
                        Console.WriteLine("Congratulations, you won!");
                        Console.ReadKey();
                        break;
                    }

                    if (guess != secretNumber)
                    {
                        lives--;
                        Console.WriteLine(new string('-', 20));
                        Console.WriteLine("Incorrect guess");
                        Console.WriteLine($"{lives} lives remaining");
                        Console.WriteLine(new string('-', 20));
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Error: Please enter a number");
                    continue;
                }

                catch (OverflowException)
                {
                    Console.WriteLine("Error: Please enter a valid guess within range");
                    continue;
                }

                catch (ArgumentNullException)
                {
                    Console.WriteLine("Error: Please enter a number");
                    continue;
                }
            }
            return;
        }
    }
}