using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_61
{
    class Class1
    {
        static void Main(string[] args)
        {
            Lion berke = new Lion();
            Console.WriteLine(berke.IsAlive);

            berke.die();

            Console.WriteLine(berke.IsAlive);
        }
    }

    abstract class Zoo
    {
        private string? _Name;
        public string? Name
        {
            get => _Name;

            protected set => _Name = value?.Length < 15 ? value : value?.Substring(0, 15);
        }


        public abstract int Age { get; protected set; }
        public abstract int energy { get; protected set; }
        public abstract int price { get; protected set; }


        private static int _count;
        public static int count
        {
            get => _count;

            private set => _count = Math.Clamp(value, 1, 500);
        }

        public static Random rng { get; protected set; }

        private int _level;
        public int level
        {
            get => _level;

            private set => _level = Math.Clamp(value, 1, 999);
        }
        public bool IsAlive { get; private set; }


        static Zoo()
        {
            rng = new Random();
            count = 0;
        }

        public Zoo()
        {
            level = 1;
            count++;
            IsAlive = true;
        }

        public static void start()
        {

        }

        public void levelup() { level++; }

        public void EnterName()
        {
            while (true)
            {
                Name = Console.ReadLine();
                if (string.IsNullOrEmpty(Name)) { Console.WriteLine("Hata: İsim boş olamaz lütfen tekrar deneyin"); continue; }
                else { Console.WriteLine("İsim doğrulandı"); break; }
            }
        }

        public void die()
        {
            IsAlive = false;
        }

        public abstract void move();
        public abstract void eat();
        public abstract void sleep();
    }

    class Lion : Zoo
    {
        private int _age;
        private int _energy;
        private int _price;
        public override int Age { get => _age; protected set => _age = Math.Clamp(value, 1, 16); }
        public override int energy { get => _energy; protected set => _energy = Math.Clamp(value, 1, 300); }
        public override int price { get => _price; protected set => _price = Math.Clamp(value, 2000, 15000); }

        public Lion()
        {
            Age = rng.Next(1, 5);
            energy = rng.Next(90, 210);
            price = 3000;
        }

        public override void move()
        {
            throw new NotImplementedException();
        }

        public override void eat()
        {
            throw new NotImplementedException();
        }

        public override void sleep()
        {
            throw new NotImplementedException();
        }
    }

    class Elephant : Zoo
    {
        private int _age;
        private int _energy;
        private int _price;
        public override int Age { get => _age; protected set => _age = Math.Clamp(value, 1, 65); }
        public override int energy { get => _energy; protected set => _energy = Math.Clamp(value, 1, 200); }
        public override int price { get => _price; protected set => _price = Math.Clamp(value, 8000, 45000); }

        public Elephant()
        {
            Age = rng.Next(4, 12);
            energy = rng.Next(40, 100);
            price = 3000;
        }

        public override void move()
        {
            throw new NotImplementedException();
        }

        public override void eat()
        {
            throw new NotImplementedException();
        }

        public override void sleep()
        {
            throw new NotImplementedException();
        }
    }

    class Monkey : Zoo
    {
        private int _age;
        private int _energy;
        private int _price;
        public override int Age { get => _age; protected set => _age = Math.Clamp(value, 1, 65); }
        public override int energy { get => _energy; protected set => _energy = Math.Clamp(value, 1, 200); }
        public override int price { get => _price; protected set => _price = Math.Clamp(value, 8000, 45000); }

        public Monkey()
        {
            Age = rng.Next(4, 12);
            energy = rng.Next(40, 100);
            price = 3000;
        }

        public override void move()
        {
            throw new NotImplementedException();
        }

        public override void eat()
        {
            throw new NotImplementedException();
        }

        public override void sleep()
        {
            throw new NotImplementedException();
        }
    }
}
