using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_44
{
    class Class1
    {
        static void Main(string[] args)
        {
            Snake a = new Snake();
        }
    }

    class Snake
    {
        private bool _Health;
        public bool Health
        {
            get => _Health;

            private set => _Health = value;
        }

        private int _Point;
        public int Point
        {
            get => _Point;

            private set => _Point = Math.Clamp(value, 10, 100000); 
        }

        private byte _speed;
        public byte speed
        {
            get => _speed;

            private set => _speed = value;
        }

        public static short count { get; private set; } // Başka sınıflardan okunabilen ama sadece kendi sınıfı içinde değiştirilebilen değişken

        private static readonly Random rng;

        public Color _color { get; private set; }

        private Position p;
        private Size s;

        static Snake()
        {
            // oyuna bağlanılacak kodlar...

            count = 0;
            rng = new Random();
        }

        public Snake()
        {
            Health = true; Point = 10; speed = 3;

            p = new Position(rng.Next(1, 500), rng.Next(1, 500));

            s = new Size();

            count++;
        }

        public void collect()
        {

        }

        public void Move()
        {

        }

        public void Die()
        {
            Health = false;
        }

        public void Max_speed()
        {

        }
    }

    struct Position
    {
        public int x;
        public int y;

        public Position(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }

    struct Size
    {

    }

    enum Color
    {
        red, yellow, blue, orange, green, white, black, gray
    }
}
