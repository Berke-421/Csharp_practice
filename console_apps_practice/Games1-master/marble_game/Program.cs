using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARBLE_GAME
{
    // Oluşturulma tarihi/Created At: 3 July/Temmuz 2025 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Marble game");
            Console.WriteLine("Please enter your name");
            string? name;
            while (true)
            {
                string? temp = Console.ReadLine();

                if (string.IsNullOrEmpty(temp))
                {
                    Console.WriteLine("Error: Please enter a name");
                    continue;
                }

                bool hasSpecialChar = false;

                foreach (char ch in temp)
                {
                    if (!char.IsLetterOrDigit(ch) && ch != ' ')
                    {
                        hasSpecialChar = true;
                    }
                }

                if (hasSpecialChar)
                {
                    Console.WriteLine("Error: Name cannot contain special characters");
                    continue;
                }

                name = temp;
                Console.WriteLine($"{name} name verified");
                break;
            }

            Console.ReadKey();
            int marblesPlayer = 10, marblesComputer = 10;
            List<string> jokerList = new List<string>() { "jkr", ".", ",", "d", "q" };
            List<string> pcGuessOptions = new List<string>() { "even", "odd" }; // computer choice list

            string errorCode = "a0";
            bool gameOver = false;

            for (; !gameOver && marblesPlayer > 0 && marblesComputer > 0;) // game ends when either player's marbles reach zero
            {
                try
                {
                    Random pc = new Random();
                    int pcTaken = pc.Next(1, marblesComputer); // computer can take up to its current marbles
                    Console.WriteLine($"Computer: Is my marble count even or odd, {name}?");
                    string? guess = Console.ReadLine();

                    if (string.IsNullOrEmpty(guess))
                    {
                        Console.WriteLine("Error: no guess entered");
                        continue;
                    }

                    bool control1 = true;
                    while (control1)
                    {
                        if (errorCode == "a1") guess = Console.ReadLine();

                        if (guess == "even" || guess == "Even" || guess == "EVEN" || guess == "e" || guess == "E")
                        {
                            if (pcTaken % 2 == 0) // correct guess when predicting even
                            {
                                Console.WriteLine("Correct guess!");
                                Console.WriteLine($"computer took: {pcTaken} marbles");
                                marblesPlayer += pcTaken;
                                marblesComputer -= pcTaken;

                                Console.WriteLine(new string('-', 20));
                                Console.WriteLine($"Your marbles: {marblesPlayer}");
                                Console.WriteLine($"Computer marbles: {marblesComputer}");
                                Console.WriteLine(new string('-', 20));
                                if (marblesPlayer <= 0 || marblesComputer <= 0)
                                {
                                    gameOver = true;
                                    break;
                                }
                                control1 = false;
                            }

                            if (pcTaken % 2 != 0) // wrong guess when predicting even
                            {
                                Console.WriteLine("Wrong guess!");
                                Console.WriteLine($"computer took: {pcTaken} marbles");
                                marblesPlayer -= pcTaken;
                                marblesComputer += pcTaken;
                                Console.WriteLine(new string('-', 20));
                                Console.WriteLine($"Your marbles: {marblesPlayer}");
                                Console.WriteLine($"Computer marbles: {marblesComputer}");
                                Console.WriteLine(new string('-', 20));
                                if (marblesPlayer <= 0 || marblesComputer <= 0)
                                {
                                    gameOver = true;
                                    break;
                                }
                                control1 = false;
                            }
                        }

                        if (guess == "Odd" || guess == "odd" || guess == "ODD" || guess == "o" || guess == "O")
                        {
                            if (pcTaken % 2 == 1) // correct guess when predicting odd
                            {
                                Console.WriteLine(new string('-', 20));
                                Console.WriteLine("Correct guess!");
                                Console.WriteLine($"computer took: {pcTaken} marbles");
                                marblesPlayer += pcTaken;
                                marblesComputer -= pcTaken;
                                Console.WriteLine($"Your marbles: {marblesPlayer}");
                                Console.WriteLine($"Computer marbles: {marblesComputer}");
                                Console.WriteLine(new string('-', 20));
                                if (marblesPlayer <= 0 || marblesComputer <= 0)
                                {
                                    gameOver = true;
                                    break;
                                }
                                control1 = false;
                            }

                            if (pcTaken % 2 != 1) // wrong guess when predicting odd
                            {
                                Console.WriteLine(new string('-', 20));
                                Console.WriteLine("Wrong guess!");
                                Console.WriteLine($"computer took: {pcTaken} marbles");
                                marblesPlayer -= pcTaken;
                                marblesComputer += pcTaken;
                                Console.WriteLine($"Your marbles: {marblesPlayer}");
                                Console.WriteLine($"Computer marbles: {marblesComputer}");
                                Console.WriteLine(new string('-', 20));
                                if (marblesPlayer <= 0 || marblesComputer <= 0)
                                {
                                    gameOver = true;
                                    break;
                                }
                                control1 = false;
                            }
                        }

                        if (guess != "Odd" || guess != "odd" || guess != "ODD" || guess != "o" || guess != "O")
                        {
                            Console.WriteLine("Error: no guess entered");
                            errorCode = "a1";
                            continue;
                        }

                        else
                        {
                            Console.WriteLine("Please enter a choice.");
                            errorCode = "a1";
                            continue;
                        }
                    }


                    if (marblesPlayer <= 0 || marblesComputer <= 0)
                    {
                        break;
                    }
                    Console.WriteLine("Your turn!");
                    Console.WriteLine("How many marbles will you put in?");
                    int yourTaken2; // helper variable since inner read is used for validation
                    while (true)
                    {
                        try // validation when choosing marbles
                        {
                            int yourTaken = Convert.ToInt32(Console.ReadLine());

                            if (yourTaken > marblesPlayer || yourTaken < 0)
                            {
                                Console.WriteLine("You don't have that many marbles! You can put at most " + marblesPlayer + ".");
                                continue;
                            }

                            yourTaken2 = yourTaken;
                            break;
                        }

                        catch (IOException ex)
                        {
                            Console.WriteLine($"Input could not be read (I/O error): {ex.Message}");
                            continue;
                        }
                        catch (OutOfMemoryException ex)
                        {
                            Console.WriteLine($"Insufficient memory: {ex.Message}");
                            continue;
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine($"Input too long: {ex.Message}");
                            continue;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"Numeric format error: {ex.Message}");
                            continue;
                        }
                        catch (OverflowException ex)
                        {
                            Console.WriteLine($"Number exceeded int range: {ex.Message}");
                            continue;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Unexpected error: {ex.Message}");
                            continue;
                        }
                    }

                    Random pcGuessRand = new Random();
                    int pcGuessIndex = pcGuessRand.Next(0, 2); // index for computer's even/odd guess
                    string pcGuess = pcGuessOptions[pcGuessIndex]; // selected guess assigned to pcGuess

                    if (pcGuess == "even")
                    {
                        if (yourTaken2 % 2 == 0) //'even' chosen by computer and it's correct
                        {
                            Console.WriteLine(new string('-', 20));
                            Console.WriteLine("Computer guessed correctly! You lost marbles");
                            marblesPlayer -= yourTaken2;
                            marblesComputer += yourTaken2;
                            Console.WriteLine($"Your marbles: {marblesPlayer}");
                            Console.WriteLine($"Computer marbles: {marblesComputer}");
                            Console.WriteLine(new string('-', 20));
                            if (marblesPlayer <= 0 || marblesComputer <= 0)
                            {
                                gameOver = true;
                                break;
                            }
                        }

                        if (yourTaken2 % 2 != 0) //'even' chosen by computer and it's wrong
                        {
                            Console.WriteLine(new string('-', 20));
                            Console.WriteLine("Computer guessed wrong! You won marbles");
                            marblesPlayer += yourTaken2;
                            marblesComputer -= yourTaken2;
                            Console.WriteLine($"Your marbles: {marblesPlayer}");
                            Console.WriteLine($"Computer marbles: {marblesComputer}");
                            Console.WriteLine(new string('-', 20));
                            if (marblesPlayer <= 0 || marblesComputer <= 0)
                            {
                                gameOver = true;
                                break;
                            }
                        }
                    }

                    if (pcGuess == "odd")
                    {
                        if (yourTaken2 % 2 == 1) // 'odd' chosen by computer and it's correct
                        {
                            Console.WriteLine(new string('-', 20));
                            Console.WriteLine("Computer guessed correctly! You lost marbles");
                            marblesPlayer -= yourTaken2;
                            marblesComputer += yourTaken2;
                            Console.WriteLine($"Your marbles: {marblesPlayer}");
                            Console.WriteLine($"Computer marbles: {marblesComputer}");
                            Console.WriteLine(new string('-', 20));
                            if (marblesPlayer <= 0 || marblesComputer <= 0)
                            {
                                gameOver = true;
                                break;
                            }
                        }

                        if (yourTaken2 % 2 != 1) // 'odd' chosen by computer and it's wrong
                        {
                            Console.WriteLine(new string('-', 20));
                            Console.WriteLine("Computer guessed wrong! You won marbles");
                            marblesPlayer += yourTaken2;
                            marblesComputer -= yourTaken2;
                            Console.WriteLine($"Your marbles: {marblesPlayer}");
                            Console.WriteLine($"Computer marbles: {marblesComputer}");
                            Console.WriteLine(new string('-', 20));
                            if (marblesPlayer <= 0 || marblesComputer <= 0)
                            {
                                gameOver = true;
                                break;
                            }
                        }
                    }

                }
                catch (IOException ioEx)
                {
                    Console.WriteLine("An error occurred while reading input: " + ioEx.Message);
                }
                catch (OutOfMemoryException memEx)
                {
                    Console.WriteLine("Too much data entered, memory insufficient: " + memEx.Message);
                }
                catch (ObjectDisposedException objEx)
                {
                    Console.WriteLine("Input stream closed: " + objEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unknown error occurred: " + ex.Message);
                }
            }
            if (marblesPlayer > marblesComputer)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations! You won");
            }
            if (marblesPlayer < marblesComputer) Console.WriteLine("You lost");
            Console.ReadKey();
        }
    }
}