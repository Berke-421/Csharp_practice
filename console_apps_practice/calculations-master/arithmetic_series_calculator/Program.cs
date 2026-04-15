using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOOPS_1
{
    class Loop1
    {
        // oluşturulma tarihi/Created At: 20 Haziran 2025 / 20 June 2025
        static void Main()
        {
            Console.WriteLine(new string('.', 50));
            Console.WriteLine("1: Print \"Hello\" 5 times");
            Console.WriteLine("2: Print numbers from 1 to N");
            Console.WriteLine("3: Print values between two entered numbers");
            Console.WriteLine(new string('.', 50));
            bool running = true;
            string? choice = "empty";
            while (true)
            {
                string? option = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(option))
                {
                    Console.WriteLine("Empty choice");
                    continue;
                }

                bool control = int.TryParse(option, out int parsed);
                if (!control) Console.WriteLine("Error: please try again");
                if (control)
                {
                    choice = option;
                    break;
                }
            }

            while (running)
            {
                switch (choice)
                {
                    case "1":
                        PrintFiveTimes();
                        running = false;
                        break;

                    case "2":
                        OneToN();
                        running = false;
                        break;

                    case "3":
                        BetweenTwoValues();
                        running = false;
                        break;

                    case "4":
                        PowerOfNumber();
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Number entered is out of rule scope");
                        choice = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(choice))
                        {
                            Console.WriteLine("Empty choice");
                            continue;
                        }
                        break;

                }
            }


        }

        public static void PrintFiveTimes()
        {
            Console.WriteLine(new string('-', 50));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Hello");
            }
            Console.WriteLine(new string('-', 50));
            Console.ReadKey();
        }

        public static void OneToN()
        {
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Counting from 1 to N");
            Console.WriteLine("Enter a number");
            byte number = Convert.ToByte(Console.ReadLine());
            for (int j = 0; j < number; j++)
            {
                Console.Write($" {j}");
            }
            Console.WriteLine(new string('-', 50));
            Console.ReadKey();
        }

        public static void BetweenTwoValues()
        {
            Console.WriteLine(new string('-', 50));

            List<short> buffer = new List<short>();
            short sum = 0;
            Console.WriteLine("Please enter the 1st number (limit)");
            short limit = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Please enter the 2nd number (start)");
            short start = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Specify the increment step");
            short step = Convert.ToInt16(Console.ReadLine());

            for (; start <= limit;)
            {
                buffer.Add(start);
                sum += start;
                start += step;
            }

            Console.Write("Elements:");
            foreach (short item in buffer)
            {
                Console.Write($" {item}");
            }

            Console.WriteLine();
            Console.Write("all elements: ");
            foreach (short element in buffer)
            {
                Console.Write($" {element}");
            }
            Console.WriteLine($"Sum:{sum}");
            Console.WriteLine(new string('-', 50));
            Console.ReadKey();
        }

        public static void PowerOfNumber()
        {
            Console.Write("Number: ");
            int baseNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Power: ");
            int power = Convert.ToInt32(Console.ReadLine());

            double result = Math.Pow(baseNumber, power);
            Console.WriteLine($"answer: {result}");
            Console.ReadKey();
        }
    }
}
