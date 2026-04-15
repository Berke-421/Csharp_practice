using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_53
{
    class Class1
    {
        static void Main(string[] args)
        {
            Clasic_Plane a = new Clasic_Plane();
            j_20 b = new j_20();
            su_57 c = new su_57();
            f_35 d = new f_35();

            Console.WriteLine(Clasic_Plane.count);

            Console.WriteLine(b.health);
        }
    }

    class Clasic_Plane
    {
        private static int _count;
        private int _speed;
        private int _damage;
        private int _maxhealth;
        private int _level;

        protected static Random rng;

        public Color cl { get; protected set; }

        public Position p;

        public static int count
        {
            get => _count;

            private set => _count = Math.Clamp(value, 0, 50);
        }

        private int _health; // kalıtım ile türemiş sınıfa gider ama türetilmiş sınıf bu değişkene erişemez
        public int health
        {
            get => _health; // dışarıdan okunabilir 

            protected set => _health = Math.Clamp(value, 0, maxhealth); // türetilmiş sınıf hariç dışarıdan değiştirilemez
        }
   
        public virtual int maxhealth
        {
            get => _maxhealth;

            protected set => _maxhealth = Math.Clamp(value, 0, 200);
        }
    
        public virtual int damage
        {
            get => _damage;

            protected set => _damage = Math.Clamp(value, 1, 10);
        }
  
        public virtual int speed
        {
            get => _speed;

            protected set => _speed = Math.Clamp(value, 1, 3);
        }

        public int level
        {
            get => _level;

            protected set => _level = Math.Clamp(value, 1, 20);
        }

        static Clasic_Plane()
        {
            count = 0;
            rng = new Random();
        }

        public Clasic_Plane()
        {
            speed = 1;
            maxhealth = 75;
            health = maxhealth;
            damage = 1;

            p = new Position(rng.Next(1, 501), rng.Next(1, 501));

            cl = (Color)(rng.Next(0, 10));

            count++;
        }

        public virtual void TakeDamage()
        {

        }

        public virtual void Damage()
        {

        }

        public virtual void Die()
        {

        }

        public virtual void LevelUp()
        {

        }
    }

    class f_35 : Clasic_Plane
    {
        public override int damage { get => base.damage; protected set => base.damage = Math.Clamp(value, 0, 15); }
        public override int maxhealth { get => base.maxhealth; protected set => base.maxhealth = Math.Clamp(value, 0, 500); }
        public override int speed { get => base.speed; protected set => base.speed = Math.Clamp(value, 0, 6); }

        public f_35()
        {
            level = 1;
            maxhealth = 100;
            damage = 2;
            health = maxhealth;
            speed = 1;

            p = new Position(rng.Next(1, 501), rng.Next(1, 501));

            cl = (Color)(rng.Next(0, 10));
        }

        public override void Damage()
        {

        }

        public override void TakeDamage()
        {
            health -= 12;
        }

        public override void Die()
        {
            
        }

        public override void LevelUp()
        {
            
        }
    }

    class j_20 : Clasic_Plane
    {
        public override int damage { get => base.damage; protected set => base.damage = Math.Clamp(value, 0, 13); }
        public override int maxhealth { get => base.maxhealth; protected set => base.maxhealth = Math.Clamp(value, 0, 550); }
        public override int speed { get => base.speed; protected set => base.maxhealth = Math.Clamp(value, 0, 4); }

        public j_20()
        {
            damage = 1;
            level = 1;
            maxhealth = 110;
            health = maxhealth;

            p = new Position(rng.Next(1, 501), rng.Next(1, 501));

            cl = (Color)(rng.Next(0, 10));
        }

        public override void Damage()
        {

        }

        public override void TakeDamage()
        {

        }

        public override void Die()
        {

        }

        public override void LevelUp()
        {

        }
    }

    class su_57 : Clasic_Plane
    {
        public override int damage { get => base.damage; protected set => base.damage = Math.Clamp(value, 0, 16); }
        public override int maxhealth { get => base.maxhealth; protected set => base.maxhealth = Math.Clamp(value, 0, 450); }
        public override int speed { get => base.speed; protected set => base.maxhealth = Math.Clamp(value, 0, 5); }

        public su_57()
        {
            damage = 3;
            level = 1;
            maxhealth = 90;
            health = maxhealth;

            p.x = rng.Next(1, 501);
            p.y = rng.Next(1, 501);

            cl = (Color)(rng.Next(0, 10));
        }

        public override void Damage()
        {

        }

        public override void TakeDamage()
        {

        }

        public override void Die()
        {

        }

        public override void LevelUp()
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

        public void Local()
        {
            Console.WriteLine("O");
            Console.SetCursorPosition(x, y);
        }
    }
    enum Color
    {
        white, black, red, blue, green,
        yellow, pink, purple, gray, brown
    }
}
