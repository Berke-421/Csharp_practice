using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_54
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    class Oyun
    {
        private int _can;
        public int can
        {
            get => _can;

            protected set => _can = Math.Clamp(value, 0, 100);
        }

        private int _damage;
        public int damage
        {
            get => _damage;

            protected set => _damage = Math.Clamp(value, 1, 20);
        }

        private int _speed;
        public int speed
        {
            get => _speed;

            set => _speed = Math.Clamp(value, 0, 12);
        }

        private static Random? rng;
        public static sbyte count { get; private set; }

    }
}
