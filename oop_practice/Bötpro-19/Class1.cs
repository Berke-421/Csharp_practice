using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_19
{
    public class Bosluk : Exception
    {
        public Bosluk(string mesaj1) : base(mesaj1)
        {

        }
    }
    class Class1
    {
        static void Main(string[] args)
        {

            Random a = new Random();
            short hiz = (short)(a.Next(1, 181));

            bool control = true;

            while (true)
            {
                try
                {
                    Car nesne = new Car();

                    Console.Write("What is the brand of your car: ");
                    nesne.brand = Console.ReadLine();

                    Console.Write("What is the color of your car: ");
                    nesne.color = Console.ReadLine();

                    Console.Write("How fast is your car: ");
                    nesne.speed = Convert.ToInt16(Console.ReadLine());

                    Console.WriteLine();

                    nesne.information();

                    Console.WriteLine();

                    Console.WriteLine("The definition is over, let the journey begin");

                    Console.WriteLine("your car is currently on the road");
                    Console.WriteLine("what do you want to do");
                    Console.WriteLine("s: increase speed");
                    Console.WriteLine("b: reduce speed");
                    Console.WriteLine("x: exit game");

                    while (control)
                    {
                        Console.WriteLine("Tercih giriniz");
                        string? prefer = Console.ReadLine();

                        switch (prefer)
                        {
                            case "s":
                                Console.WriteLine("Faster: ");
                                nesne.accelerate(Convert.ToInt16(Console.ReadLine()));
                                break;

                            case "b":
                                Console.WriteLine("slower");
                                nesne.breakk(Convert.ToInt16(Console.ReadLine()));
                                break;

                            case "x":
                                control = false;
                                break;

                            default:
                                Console.WriteLine("No preference entered");
                                break;
                        }

                        nesne.information();
                    }

                    break;

                }

                catch (FormatException)
                {
                    Console.WriteLine("Hatalı format! Lütfen bir sayı girin.");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Sayı çok büyük veya çok küçük! -32768 ile 32767 arasında olmalı.");
                    continue;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Hiçbir değer girilmedi!");
                    continue;
                }

            }



        }
    }

    class Car
    {
        public string? brand { get; set; }
        public string? color { get; set; }
        public short speed { get; set; }
        private static byte counter { get; set; }

        public Car()
        {
            brand = "'unknown'";
            color = "'unknown'";
            speed = 0;

            counter++;
            Console.WriteLine($"1 new car added! The number of new cars reached {counter}");
        }

        public void information()
        {
            Console.WriteLine($"I have a car {brand} of {color} rank that can go at {speed} speed");
        }

        public short accelerate(short amount)
        {
            speed += amount;
            return speed;
        }

        public short breakk(short amount)
        {
            speed -= amount;
            return speed;
        }
    }
}
