using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_60
{
    class Class1
    {
        static void Main(string[] args)
        {
            Okcu a = new Okcu("Adam");
            Console.WriteLine(a.level);
        }
    }

    abstract class Karakter
    {
        private string? _name;
        public string? name
        {
            get => _name;

            protected set => _name = value?.Length < 15 ? value : value?.Substring(0, 15); 
        }

        public abstract int health { get; protected set; }
        public abstract int maxhealth { get; protected set; }
        public abstract int vurus { get; protected set; }
        public bool IsAlive { get; protected set; }
        public abstract int level { get; protected set; }

        private static int _count;
        public static int count
        {
            get => _count;

            private set => _count = Math.Clamp(value, 0, 70);
        }

        static Karakter()
        {
            count = 0;
        }

        public Karakter(string? NAME)
        {
            IsAlive = true;
            count++;
            level = 1;
        }

        public static void Start()
        {

        }

        public abstract void Move();
        public abstract void Hit();
        public abstract void die();
        public abstract void speak();
    }

    class AnaKarakter : Karakter
    {
        private int _health;
        private int _maxhealth;
        private int _vurus;
        private int _level;
        public override int level { get => _level; protected set => _level = Math.Clamp(value, 1, 999); }
        public override int health { get => _health; protected set => _health = Math.Clamp(value, 0, maxhealth); }
        public override int maxhealth { get => _maxhealth; protected set => _maxhealth = Math.Clamp(value, 50, 1000); }
        public override int vurus { get => _vurus; protected set => _maxhealth = Math.Clamp(value, 0, 120); }

        private int _score;
        public int score
        {
            get => _score;

            private set => _score = Math.Clamp(value, 1, 999999);
        }

        public AnaKarakter(string? AD) : base(AD)
        {
            this.name = AD;
            maxhealth = 50;
            health = maxhealth;
            score = 0;
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Hit()
        {
            throw new NotImplementedException();
        }

        public override void die()
        {
            throw new NotImplementedException();
        }

        public override void speak()
        {
            throw new NotImplementedException();
        }
    }

    class Buyucu : Karakter
    {
        private int _health;
        private int _maxhealth;
        private int _vurus;
        private int _level;
        public override int level { get => _level; protected set => _level = Math.Clamp(value, 1, 10); }
        public override int health { get => _health; protected set => _health = Math.Clamp(value, 0, maxhealth); }
        public override int maxhealth { get => _maxhealth; protected set => _maxhealth = Math.Clamp(value, 100, 1800); }
        public override int vurus { get => _vurus; protected set => _maxhealth = Math.Clamp(value, 0, 220); }

        public Buyucu(string? AD) : base(AD)
        {
            maxhealth = 1800;
            health = maxhealth;
            vurus = 30;
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Hit()
        {
            throw new NotImplementedException();
        }

        public override void die()
        {
            throw new NotImplementedException();
        }

        public override void speak()
        {
            throw new NotImplementedException();
        }
    }

    class Okcu : Karakter
    {
        private int _health;
        private int _maxhealth;
        private int _vurus;
        private int _level;
        public override int level { get => _level; protected set => _level = Math.Clamp(value, 1, 5); }
        public override int health { get => _health; protected set => _health = Math.Clamp(value, 0, maxhealth); }
        public override int maxhealth { get => _maxhealth; protected set => _maxhealth = Math.Clamp(value, 30, 400); }
        public override int vurus { get => _vurus; protected set => _maxhealth = Math.Clamp(value, 0, 40); }

        public Okcu(string? AD) : base(AD)
        {
            maxhealth = 30;
            health = maxhealth;
            vurus = 5;
            level = 900;
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Hit()
        {
            throw new NotImplementedException();
        }

        public override void die()
        {
            throw new NotImplementedException();
        }

        public override void speak()
        {
            throw new NotImplementedException();
        }
    }

    abstract class Person
    {
        public abstract int Age { get; }

        public Person()
        {
            Age = 30; // ❌ HATA: abstract olduğu için burada atanamaz
        }
    }
}
