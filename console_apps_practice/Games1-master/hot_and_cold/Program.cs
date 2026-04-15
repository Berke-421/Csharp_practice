using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOT_AND_COLD_GAME
{
    // Oluşturulma tarihi/Created At: 6 July/Temmuz 2025
    class Program
    {
        public class TooLarge : Exception
        {
            public TooLarge(string message) : base(message)
            {

            }
        }

        public class OutOfRange : Exception
        {
            public OutOfRange(string message2) : base(message2)
            {

            }
        }
        static public void ShowWarning(byte code)
        {
            Console.Beep();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            if (code == 0) Console.WriteLine("Invalid input! Please enter numbers only.");
            if (code == 1) Console.WriteLine("The number you entered is too large or too small.");
            if (code == 2) Console.WriteLine("No value entered.");
            if (code == 3) Console.WriteLine("r cannot be greater than n");
            Console.ResetColor();
        }

        static public void PlayMusic()
        {
            Console.Beep(784, 200);  // G5
            Console.Beep(880, 200);  // A5
            Console.Beep(988, 200);  // B5
            Console.Beep(1046, 300); // C6
            Thread.Sleep(100);
            Console.Beep(1046, 150); // C6
            Console.Beep(988, 150);  // B5
            Console.Beep(1174, 400); // D6
        }

        static public byte RandomBetween(byte maxPlusOne) // returns a random number between 1 and the given parameter - 1
        {
            Random rng = new Random();
            byte result = (byte)(rng.Next(1, maxPlusOne));
            return result;
        }
        static void Main()
        {
            Console.WriteLine("Welcome to the Hot and Cold number guessing game");
            Console.WriteLine("The goal is to reach the target number with as few guesses as possible to get the highest score");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Easy level (1-10)");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Medium level (1-20)");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hard level (1-30)");
            Console.ResetColor();
            Console.WriteLine("Press any key to begin the game");
            Console.ReadKey();
            PlayGame(); // start the game
        }

        public static void PlayGame()
        {
            byte secret1 = RandomBetween(11); // returns a number between 1 and 10

            byte score;
            byte warnCode, totalScore; // warnCode for warnings and totalScore for calculated score
            short attempts1 = 0, attempts2 = 0, attempts3 = 0; // counters for each level

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Game started! Level 1");
            Console.ResetColor();
            PlayMusic();
            Console.WriteLine("The computer picked a number between 1 and 10! Try to find it with as few guesses as possible");

            while (true)
            {
                try
                {
                    byte guess = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine("");
                    attempts1 += 1; // increment counter for each guess

                    if (guess == secret1) // if the number is found, level 1 ends
                    {
                        Console.WriteLine("Correct guess, well done! Level 1 finished!");
                        break;
                    }

                    try // feedback based on how close the guess is; continues until number is found
                    {
                        if (guess < 0 || guess > 10)
                        {
                            throw new OutOfRange("Error");
                        }

                        if (guess == secret1 + 1 || guess == secret1 - 1)
                        {
                            Console.WriteLine("You're burning");
                            continue;
                        }

                        else if (guess == secret1 + 2 || guess == secret1 - 2 || guess == secret1 + 3 || guess == secret1 - 3)
                        {
                            Console.WriteLine("Hot");
                            continue;
                        }

                        else
                        {
                            Console.WriteLine("Cold");
                            continue;
                        }
                    }

                    catch (OutOfRange) // prevent crash when guess is outside allowed bounds
                    {
                        Console.WriteLine("You exceeded the limit. That means you entered a number outside 1-10");
                        continue;
                    }
                }

                catch (FormatException) // handle invalid input format
                {
                    warnCode = 0;
                    ShowWarning(warnCode);
                    continue;
                }

                catch (OverflowException)
                {
                    warnCode = 1;
                    ShowWarning(warnCode);
                    continue;
                }

                catch (ArgumentNullException)
                {
                    warnCode = 2;
                    ShowWarning(warnCode);
                    continue;
                }

            }


            Console.WriteLine($"You tried {attempts1} times!");

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to start level 2");
            Console.ResetColor();
            Console.WriteLine("Level 2 started");
            PlayMusic();
            Console.WriteLine("The computer picked a number between 1 and 20");


            byte secret2 = RandomBetween(21);

            while (true)
            {
                try
                {
                    byte guess = Convert.ToByte(Console.ReadLine());
                    attempts2 += 1;

                    if (guess == secret2)
                    {
                        Console.WriteLine("Correct guess! Well done, Level 2 finished");
                        Console.WriteLine("");
                        break;
                    }

                    try
                    {
                        if (guess < 0 || guess > 20)
                        {
                            throw new OutOfRange("Error");
                        }

                        if (guess == secret2 + 1 || guess == secret2 - 1)
                        {
                            Console.WriteLine("You're burning");
                            continue;
                        }

                        else if (guess == secret2 + 2 || guess == secret2 - 2 || guess == secret2 + 3 || guess == secret2 - 3)
                        {
                            Console.WriteLine("Very hot");
                            continue;
                        }

                        else if (guess == secret2 + 4 || guess == secret2 - 4 || guess == secret2 - 5 || guess == secret2 + 5
                              || guess == secret2 - 6 || guess == secret2 + 6)

                        {
                            Console.WriteLine("Hot");
                            continue;
                        }

                        else if (guess == secret2 + 7 || guess == secret2 - 7 || guess == secret2 - 8 || guess == secret2 + 8)
                        {
                            Console.WriteLine("Warm");
                            continue;
                        }

                        else
                        {
                            Console.WriteLine("Cold");
                            continue;
                        }

                    }

                    catch (OutOfRange)
                    {
                        Console.WriteLine("You exceeded the limit. That means you entered a number outside 1-20");
                        continue;
                    }
                }

                catch (FormatException)
                {
                    warnCode = 0;
                    ShowWarning(warnCode);
                    continue;
                }

                catch (OverflowException)
                {
                    warnCode = 1;
                    ShowWarning(warnCode);
                    continue;
                }

                catch (ArgumentNullException)
                {
                    warnCode = 2;
                    ShowWarning(warnCode);
                    continue;
                }

            }


            Console.WriteLine($"You made {attempts2} guesses");

            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to start level 3");
            Console.ResetColor();
            Console.ReadKey();
            PlayMusic();
            Console.WriteLine("Level 3 started!");

            byte secret3 = RandomBetween(31);

            while (true)
            {
                try
                {
                    byte guess = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine("");
                    attempts3 += 1;

                    if (guess == secret3)
                    {
                        Console.WriteLine("Congratulations, you found the number!");
                        break;
                    }

                    try
                    {
                        if (guess < 0 || guess > 30)
                        {
                            throw new OutOfRange("Error");
                        }

                        if (guess == secret3 - 1 || guess == secret3 + 1)
                        {
                            Console.WriteLine("You're burning");
                            continue;
                        }

                        else if (guess == secret3 + 2 || guess == secret3 - 2 || guess == secret3 + 3 || guess == secret3 - 3)
                        {
                            Console.WriteLine("Very hot");
                            continue;
                        }

                        else if (guess == secret3 + 4 || guess == secret3 - 4 || guess == secret3 + 5 || guess == secret3 - 5
                             || guess == secret3 + 6 || guess == secret3 - 6)
                        {
                            Console.WriteLine("Hot");
                            continue;
                        }

                        else if (guess == secret3 + 7 || guess == secret3 - 7 || guess == secret3 + 8 || guess == secret3 - 8)
                        {
                            Console.WriteLine("Warm");
                            continue;
                        }

                        else
                        {
                            Console.WriteLine("Cold");
                            continue;
                        }
                    }

                    catch (OutOfRange)
                    {
                        Console.WriteLine("You exceeded the limit. That means you entered a number outside 1-30");
                        continue;
                    }

                }

                catch (FormatException)
                {
                    warnCode = 0;
                    ShowWarning(warnCode);
                    continue;
                }

                catch (OverflowException)
                {
                    warnCode = 1;
                    ShowWarning(warnCode);
                    continue;
                }

                catch (ArgumentNullException)
                {
                    warnCode = 2;
                    ShowWarning(warnCode);
                    continue;
                }
            }


        }

    }
}