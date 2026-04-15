using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GEOMETRY_APP
{
    public class AngleException : Exception
    {
        public AngleException(string message) : base(message)
        {

        }
    }
    class Program
    {
        static public void Warning(byte code)
        {
            Console.Beep();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            if (code == 0) Console.WriteLine("Invalid input! Please enter numbers only.");
            if (code == 1) Console.WriteLine("The number you entered is too large or too small.");
            if (code == 2) Console.WriteLine("No value entered.");
            if (code == 3) Console.WriteLine("Invalid angle input");
            Console.ResetColor();
        }
        static void Main()
        {
            Console.WriteLine(new string('.', 50));
            Console.WriteLine("Key 1: hypotenuse calculation");
            Console.WriteLine("Key 2: side length calculation");
            Console.WriteLine("Key 3: circle and sector area calculation");
            Console.WriteLine(new string('.', 50));
            bool running = true;
            string? selection = "empty";
            while (true)
            {
                string? option = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(option))
                {
                    Console.WriteLine("Empty choice");
                    continue;
                }

                bool control = int.TryParse(option, out int parsed); // detects non-numeric input
                if (!control) Console.WriteLine("Error: please try again");

                if (control)
                {
                    selection = option;
                    break;
                }
            }

            while (running)
            {
                switch (selection)
                {
                    case "1":
                        FindHypotenuse();
                        running = false;
                        break;

                    case "2":
                        SideLengthCalculation();
                        running = false;
                        break;

                    case "3":
                        CircleOperation();
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Number entered is out of rule scope");
                        selection = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(selection))
                        {
                            Console.WriteLine("Empty choice");
                            continue;
                        }
                        break;
                }
            }


        }

        static public void FindHypotenuse()
        {
            Console.WriteLine("Hypotenuse");
            byte attempt = 0;
            byte code = 0;
            double vertical, horizontal, hypotenuse, area;
            while (true)
            {
                try
                {
                    if (attempt == 0) Console.WriteLine("Start:");
                    if (attempt == 1) Console.WriteLine("Start again");
                    Console.WriteLine("Enter the triangle's vertical length");

                    vertical = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter the triangle's horizontal length");
                    horizontal = Convert.ToDouble(Console.ReadLine());

                    hypotenuse = Math.Pow(vertical, 2) + Math.Pow(horizontal, 2);
                    hypotenuse = Math.Sqrt(hypotenuse);
                    area = (double)(vertical * horizontal / 2);

                    break;

                }

                catch (FormatException)
                {
                    code = 0;
                    attempt = 1;
                    Warning(code);
                    continue;
                }

                catch (OverflowException)
                {
                    code = 1;
                    attempt = 1;
                    Warning(code);
                    continue;
                }

                catch (ArgumentNullException)
                {
                    code = 2;
                    attempt = 1;
                    Warning(code);
                    continue;
                }
            }

            Console.WriteLine($"Triangle hypotenuse: {hypotenuse}");
            Console.WriteLine($"Triangle area: {area}");
        }

        static public void SideLengthCalculation()
        {
            Console.WriteLine("Side length");
            double a, b, hipo, h, angle;
            byte code = 0, attempt = 0;
            while (true)
            {
                try
                {
                    if (attempt == 0) Console.WriteLine("Start");
                    if (attempt == 0) Console.WriteLine("Start again");
                    Console.WriteLine("Angle a:");
                    angle = Convert.ToDouble(Console.ReadLine());
                    if (angle <= 0 || angle >= 180) throw new AngleException("Error");

                    Console.WriteLine("Length a:");
                    a = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Length b:");
                    b = Convert.ToDouble(Console.ReadLine());

                    hipo = Math.Sqrt(a * a + b * b);
                    h = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(angle * Math.PI / 180));

                    break;
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    code = 0;
                    attempt = 1;
                    Warning(code);
                    continue;
                }

                catch (OverflowException)
                {
                    code = 1;
                    attempt = 1;
                    Warning(code);
                    continue;
                }

                catch (ArgumentNullException)
                {
                    code = 2;
                    attempt = 1;
                    Warning(code);
                    continue;
                }

                catch (AngleException)
                {
                    code = 3;
                    attempt = 1;
                    Warning(code);
                    continue;
                }
            }

            Console.WriteLine($"Hypotenuse = {hipo}, height(h) = {h}");
        }

        static public void CircleOperation()
        {
            Console.WriteLine("Circle operation");
            double r, a, sectorArea, area;
            byte code = 0, attempt = 0;
            while (true)
            {
                try
                {
                    if (attempt == 0) Console.WriteLine("Start");
                    if (attempt == 1) Console.WriteLine("Start again");

                    Console.WriteLine("Radius (r) value:");
                    r = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Angle value");
                    a = Convert.ToDouble(Console.ReadLine());
                    if (a <= 0 || a >= 360) throw new AngleException("error");

                    area = Math.PI * r * r;
                    sectorArea = Math.PI * r * r * a / 360;

                    break;
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    code = 0;
                    attempt = 1;
                    Warning(code);
                    continue;
                }

                catch (OverflowException)
                {
                    code = 1;
                    attempt = 1;
                    Warning(code);
                    continue;
                }

                catch (ArgumentNullException)
                {
                    code = 2;
                    attempt = 1;
                    Warning(code);
                    continue;
                }

                catch (AngleException)
                {
                    code = 3;
                    attempt = 1;
                    Warning(code);
                    continue;
                }

            }

            Console.WriteLine($"Area: {area}");
            Console.WriteLine($"Sector area: {sectorArea}");
        }
    }
}