using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CALCULATOR_APP
{
    // Oluşturulma tarihi/Created At: 29 Haziran 2025 / 29 June 2025
    public class EmptyInputException : Exception
    {
        public EmptyInputException(string message) : base(message)
        {

        }
    }

    public class InvalidTextException : Exception
    {
        public InvalidTextException(string message) : base(message)
        {

        }

    }

    public class InvalidOperatorException : Exception
    {
        public InvalidOperatorException(string message) : base(message)
        {

        }
    }

    public class LetterFoundException : Exception
    {
        public LetterFoundException(string message) : base(message)
        {

        }
    }

    public class ConsecutiveOperatorException : Exception
    {
        public ConsecutiveOperatorException(string message) : base(message)
        {

        }
    }

    public class ZeroDenominatorException : Exception
    {
        public ZeroDenominatorException(string message) : base(message)
        {

        }
    }

    public class RanException : Exception
    {
        public RanException(string message) : base(message)
        {

        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Calculator");
            while (true)
            {
                string? input = null;
                bool control1, control2;
                List<char> buffer = new List<char>();
                List<char> operators = new List<char>() { '*', '/', '=' };
                while (true)
                {
                    try
                    {
                        string? tempInput = Console.ReadLine();
                        if (string.IsNullOrEmpty(tempInput)) throw new EmptyInputException("Input cannot be empty");

                        if (!tempInput.Contains('+') && !tempInput.Contains('-') && !tempInput.Contains('*') && !tempInput.Contains('/') && !tempInput.Contains('='))
                        {
                            throw new InvalidTextException("Input is invalid");
                        }

                        Regex consecutive = new Regex(@"[\=!%*/]{2}");
                        bool hasConsecutive = consecutive.IsMatch(tempInput);
                        if (hasConsecutive) throw new ConsecutiveOperatorException("Operator error");

                        if (operators.Contains(tempInput[0]) || operators.Contains(tempInput[^1]))
                        {
                            throw new InvalidOperatorException("Invalid operator placement");
                        }

                        Regex positiveNegativePattern = new Regex(@"\b\d+\*\-\d+\b");
                        bool match1 = positiveNegativePattern.IsMatch(tempInput);
                        control1 = match1;
                        if (!match1) throw new ConsecutiveOperatorException("Operator error");

                        Regex positivePositivePattern = new Regex(@"\b\d+\*\+\d+\b");
                        bool match2 = positiveNegativePattern.IsMatch(tempInput);
                        control2 = match2;
                        if (!match2) throw new ConsecutiveOperatorException("Operator error");


                        Regex letter = new Regex(@"\p{L}"); // checks for letters
                        bool hasLetter = letter.IsMatch(tempInput); // true if letters present
                        if (hasLetter) throw new LetterFoundException("Operator error");

                        input = tempInput;
                        break;
                    }

                    catch (RanException)
                    {
                        Console.WriteLine("Ran");
                        continue;
                    }

                    catch (InvalidTextException ex)
                    {
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.Red;   // background red
                        Console.ForegroundColor = ConsoleColor.White; // text white
                        Console.WriteLine($"Input error: {ex.Message}");
                        Console.ResetColor();
                        continue;
                    }

                    catch (EmptyInputException ex)
                    {
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.Red;   // background red
                        Console.ForegroundColor = ConsoleColor.White; // text white
                        Console.WriteLine($"Input error: {ex.Message}");
                        Console.ResetColor();
                        continue;
                    }

                    catch (LetterFoundException ex)
                    {
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.Red;   // background red
                        Console.ForegroundColor = ConsoleColor.White; // text white
                        Console.WriteLine($"Input error: {ex.Message}");
                        Console.ResetColor();
                        continue;
                    }

                    catch (InvalidOperatorException ex)
                    {
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.Red;   // background red
                        Console.ForegroundColor = ConsoleColor.White; // text white
                        Console.WriteLine($"Input error: {ex.Message}");
                        Console.ResetColor();
                        continue;

                    }

                    catch (ConsecutiveOperatorException ex)
                    {
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.Red;   // background red
                        Console.ForegroundColor = ConsoleColor.White; // text white
                        Console.WriteLine($"Input error: {ex.Message}");
                        Console.ResetColor();
                        continue;
                    }

                    catch (IOException ex)
                    {
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.Red;   // background red
                        Console.ForegroundColor = ConsoleColor.White; // text white
                        Console.WriteLine($"Input I/O error: {ex.Message}");
                        Console.ResetColor();

                        continue;
                    }

                    catch (OutOfMemoryException ex)
                    {
                        Console.Beep();
                        Console.BackgroundColor = ConsoleColor.Red;   // background red
                        Console.ForegroundColor = ConsoleColor.White; // text white
                        Console.WriteLine($"Out of memory - input too long. {ex.Message}");
                        Console.ResetColor();

                        continue;
                    }
                }


                int j = 0, a = 0;
                bool control = true;
                double result = 0;
                List<string> foundOperatorsList = new List<string>();
                List<dynamic> tokensList = new List<dynamic>();
                Regex numberFinder = new Regex(@"\d+"); // finds numbers in text
                MatchCollection foundNumbers = numberFinder.Matches(input);
                foreach (Match gg in foundNumbers) tokensList.Add(double.Parse(gg.Value));

                Regex operatorFinder = new Regex(@"[+\-*/]");
                MatchCollection foundOperators = operatorFinder.Matches(input);
                foreach (Match CD in foundOperators) foundOperatorsList.Add(CD.Value);

                for (int i = 1; i <= foundOperators.Count; i += 1)
                {
                    tokensList.Insert(i + a, foundOperatorsList[j]);
                    j++;
                    a++;
                }

                while (control)
                {
                    for (int i = 0; i < tokensList.Count; i++)
                    {
                        if (tokensList[i].ToString() == "*")
                        {
                            int index = tokensList.IndexOf("*");
                            double left = Convert.ToDouble(tokensList[index + 1]);
                            double right = Convert.ToDouble(tokensList[index - 1]);

                            if (control1)
                            {
                                int minusIndex = tokensList.IndexOf("-");
                                tokensList[minusIndex + 1] *= -1;
                                tokensList.RemoveAt(minusIndex);
                            }

                            if (control2)
                            {
                                int plusIndex = tokensList.IndexOf("+");
                                tokensList[plusIndex + 1] *= 1;
                                tokensList.RemoveAt(plusIndex);
                            }

                            result = left * right;

                            tokensList.RemoveAt(index + 1);
                            tokensList.RemoveAt(index - 1);
                            int index2 = tokensList.IndexOf("*");
                            tokensList[index2] = result;
                        }
                    }

                    for (int i = tokensList.Count - 1; i >= 0; i--)
                    {
                        if (tokensList[i].ToString() == "/")
                        {
                            int index = tokensList.IndexOf("/");
                            double left = Convert.ToDouble(tokensList[index + 1].ToString());
                            double right = Convert.ToDouble(tokensList[index - 1].ToString());

                            if (control1)
                            {
                                int minusIndex = tokensList.IndexOf("-");
                                tokensList[minusIndex + 1] *= -1;
                                tokensList.RemoveAt(minusIndex);
                            }

                            if (control2)
                            {
                                int plusIndex = tokensList.IndexOf("+");
                                tokensList[plusIndex + 1] *= 1;
                                tokensList.RemoveAt(plusIndex);
                            }

                            result = right / left;

                            tokensList.RemoveAt(index + 1);
                            tokensList.RemoveAt(index - 1);
                            int index2 = tokensList.IndexOf("/");
                            tokensList[index2] = result;
                        }

                    }

                    for (int i = tokensList.Count - 1; i >= 0; i--)
                    {

                        if (tokensList[i].ToString() == "+")
                        {
                            int index = tokensList.IndexOf("+");
                            double left = Convert.ToDouble(tokensList[index + 1].ToString());
                            double right = Convert.ToDouble(tokensList[index - 1].ToString());

                            if (control1)
                            {
                                int minusIndex = tokensList.IndexOf("-");
                                tokensList[minusIndex + 1] *= -1;
                                tokensList.RemoveAt(minusIndex);
                            }

                            if (control2)
                            {
                                int plusIndex = tokensList.IndexOf("+");
                                tokensList[plusIndex + 1] *= 1;
                                tokensList.RemoveAt(plusIndex);
                            }

                            result = left + right;

                            tokensList.RemoveAt(index + 1);
                            tokensList.RemoveAt(index - 1);
                            int index2 = tokensList.IndexOf("+");
                            tokensList[index2] = result;
                        }
                    }

                    for (int i = tokensList.Count - 1; i >= 0; i--)
                    {
                        if (tokensList[i].ToString() == "-")
                        {
                            int index = tokensList.IndexOf("-");
                            double left = Convert.ToDouble(tokensList[index + 1].ToString());
                            double right = Convert.ToDouble(tokensList[index - 1].ToString());

                            if (control1)
                            {
                                int minusIndex = tokensList.IndexOf("-");
                                tokensList[minusIndex + 1] *= -1;
                                tokensList.RemoveAt(minusIndex);
                            }

                            if (control2)
                            {
                                int plusIndex = tokensList.IndexOf("+");
                                tokensList[plusIndex + 1] *= 1;
                                tokensList.RemoveAt(plusIndex);
                            }

                            result = right - left;

                            tokensList.RemoveAt(index + 1);
                            tokensList.RemoveAt(index - 1);
                            int index2 = tokensList.IndexOf("-");
                            tokensList[index2] = result;
                        }

                    }

                    if (tokensList.Count == 1) break;
                }

                Console.BackgroundColor = ConsoleColor.Green;   // background green
                Console.ForegroundColor = ConsoleColor.White; // text white
                foreach (double element in tokensList) Console.WriteLine(element);
                Console.ResetColor();

            }

        }
    }
}