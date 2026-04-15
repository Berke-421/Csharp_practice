using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_45
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    class King
    {
        private int _health;
        public int health
        {
            get => _health;

            set => _health = Math.Clamp(value, 0, max_health);
        }

        public int max_health { get; private set; } // dışarıdan sadece okunur içeriden değiştirilebilir

        public sbyte count_troops { get; private set; }

        public Age level { get; private set; }
        
        private int _damage;
        public int damage
        {
            get => _damage;

            set => _damage = value;
        }

        private static readonly Random rng;

        private static short count;

        private Position p;
        private Bullet_Position bp;

        static King()
        {
            rng = new Random();
            count = 0;
        }

        public King()
        {
            damage = 3;
            max_health = 10;
            health = 10;
            level = (Age)0;

            p = new Position(rng.Next(0, 500), rng.Next(1, 500));

            count++;
        }

        public void levelUp()
        {

        }

        public void move()
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

    struct Bullet_Position
    {

    }

    enum Age
    {
        stone,
        bronze,
        iron,
        ant,
        middle,
        ronesans,
        industruel,
        modern,
        digital,
        space
    }
}
