using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_50
{
    class Class1
    {
        static void Main(string[] args)
        {
            Car berke = new Car();

            Console.WriteLine(Car.count);

            Toyata nesne = new Toyata();
            nesne.MaxSpeed = 700;
            Console.WriteLine(nesne.MaxSpeed);

            nesne.deneme = 123;
            nesne.deneme2 = 12;
        }
    }

    class Car
    {
        private int _MaxSpeed;
        private int _Money;
        private int _SpeedNow;

        private int deneme;
        public int deneme2;


        public int MaxSpeed
        {
            get => _MaxSpeed;

            set => _MaxSpeed = Math.Clamp(value, 0, 600);
        }  
        public virtual int SpeedNow
        {
            get => _SpeedNow;

            private set => _SpeedNow = Math.Clamp(value, 0, MaxSpeed);
        }    
        public int Money
        {
            get => _Money;

            protected set => _Money = Math.Clamp(value, 0, 999999);
        }


        public Color c { get; private set; } // Dışarıdaki sınıflardan okunabilen ve sadece ana ve türetilmiş sınıflardan değiştirilebilen değişken

        private static Random? rng;
        public static byte count { get; private set; }
        public Position pst { get; set; }
    }

    class Toyata : Car
    {

    }

    enum Color
    {
        red, yellow, blue, white, black, orange, pink, gray, purple, green
    }

    struct Position
    {
        public int x;
        public int y;

        public Position(int X, int Y) { x = X; y = Y; }
    }
}
