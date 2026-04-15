using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FIBONACCI_25
{
    class Program
    {
        // Oluşturulma tarihi/Created At: 4 ağustos 2025 / 4 August 2025
        public class NegativeValueException : Exception
        {
            public NegativeValueException(string message) : base(message)
            {

            }
        }
        public static void Warning(byte code)
        {
            Console.Beep();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            if (code == 0) Console.WriteLine("Invalid input! Please enter numbers only.");
            if (code == 1) Console.WriteLine("The number you entered is too large or too small.");
            if (code == 2) Console.WriteLine("No value entered.");
            if (code == 3) Console.WriteLine("r cannot be greater than n");
            if (code == 4) Console.WriteLine("Negative numbers are not accepted");
            Console.ResetColor();
        }
        static void Main()
        {
            Console.WriteLine("Fibonacci numbers");
            Console.WriteLine("How many Fibonacci numbers?");
            byte code;
            int count;
            while (true)
            {
                try
                {
                    int tempNumber = Convert.ToInt32(Console.ReadLine());
                    if (tempNumber < 0) throw new NegativeValueException("Error");
                    count = tempNumber;
                    break;
                }

                catch (FormatException) // prevent crash on invalid input
                {
                    code = 0;
                    Warning(code);
                    continue;
                }

                catch (OverflowException)
                {
                    code = 1;
                    Warning(code);
                    continue;
                }

                catch (ArgumentNullException)
                {
                    code = 2;
                    Warning(code);
                    continue;
                }

                catch (NegativeValueException)
                {
                    code = 3;
                    Warning(code);
                    continue;
                }
            }

            Console.WriteLine(" ");
            int n0 = 0, n1 = 1, result = 0;

            Console.WriteLine("0");
            Console.WriteLine("1");
            for (int i = 0; i < count; i++)
            {
                result = n0 + n1;
                n0 = n1;
                n1 = result;
                Console.WriteLine(result);
            }
        }
    }
}