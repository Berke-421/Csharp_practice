using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_51
{
    class Class1
    {
        static void Main(string[] args)
        {
            Asker a = new Asker();
            Enemy b = new Enemy();

            Console.WriteLine(Asker.count);
        }
    }

    class Asker
    {
        private int _Damage;

        private int _Health;

        private int _speed;
        public int Damage
        {
            get => _Damage; // bütün sınıflardan okunabilir

            protected set => _Damage = Math.Clamp(value, 0, 100); // sadece ana sınıfta ve türetilmiş sınıflarda değeri değiştirilebilir. (Ayarlama ile karıştımra)
        }
        
        public int Healt
        {
            get => _Health;

            protected set => _Health = Math.Clamp(value, 0, MaxHealt);
        }

        public int speed
        {
            get => _speed;

            protected set => _speed = Math.Clamp(value, 0, 5);
        }

        public Color rnk { get; protected set; }
        public int MaxHealt { get; protected set; }
        public static byte count { get; protected set; }

        protected static Random rng;

        static Asker()
        {
            count = 0;
            rng = new Random();
        }

        public Asker()
        {
            MaxHealt = 100;
            Healt = 100;
            Damage = 3;
            speed = 1;

            count++;
            rnk = (Color)(rng.Next(0, 12));
        }

        public virtual void Fire()
        {
            Console.WriteLine("ta ta ta");
        }

        public virtual void Die()
        {
            Console.WriteLine("AAARRGHH");
        }

        public virtual void Move()
        {
            Console.WriteLine("okey I'm moving sir");
        }

        public virtual void TakeDamage()
        {
            Console.WriteLine("auvh");
        }
    }

    class Enemy : Asker
    {
        public Enemy()
        {
            MaxHealt = 130;
            Healt = 130;
            Damage = 5;
            rnk = (Color)(rng.Next(0, 12));
        }

        public override void Fire()
        {
            Console.WriteLine("tum tum tum");
        }

        public override void Die()
        {
            Console.WriteLine("ÖÖEEEHHH");
        }

        public override void Move()
        {
            Console.WriteLine("Come on let's go");
        }

        public override void TakeDamage()
        {
            Console.WriteLine("dame it");
        }
    }

    enum Color
    {
        red, blue, yellow, green, gray, orange, pruple, pink, white, black, brown, skyblue
    }
}
