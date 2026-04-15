using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_55
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    class Classic_tank
    {
        private static int _count;
        public static int count
        {
            get => _count;

            private set => _count = Math.Clamp(value, 1, 100); // Türetilmiş sınıflarda count arttırılamaz bu kural sayesinde
        }

        protected static Random rng;
        public Color r { get; protected set; }

        public Position pst;

        private int _max_health;
        public virtual int max_health
        {
            get => _max_health;

            protected set => _max_health = Math.Clamp(value, 0, 1000);
        }

        private int _health;
        public int health
        {
            get => _health;

            protected set => _health = Math.Clamp(value, 0, max_health);
        }

        private int _damage;
        public virtual int damage
        {
            get => _damage;

            protected set => _damage = Math.Clamp(value, 0, 100);
        }

        private int _bodydamage;
        public int bodydamage
        {
            get => _bodydamage;

            protected set => _bodydamage = Math.Clamp(value, 1, 20);
        }

        private int _speed;
        public virtual int speed
        {
            get => _speed;

            protected set => _speed = Math.Clamp(value, 0, 6);
        }

        private int _level;
        public int level
        {
            get => _level;

            protected set => _level = Math.Clamp(value, 1, 30);
        }

        static Classic_tank()
        {
            count = 0;
            rng = new Random();
        }

        public Classic_tank()
        {
            max_health = 30;
            health = max_health;
            bodydamage = 3;
            damage = 2;
            level = 1;

            pst = new Position(rng.Next(1, 501), rng.Next(1, 501));

            r = (Color)(rng.Next(0, 10));

            count++;
        }

        public virtual void TakeDamage()
        {

        }

        public virtual void LevelUp()
        {

        }

        public virtual void Die()
        {

        }

        public virtual void Fire()
        {

        }
    }

    class Russia : Classic_tank
    {
        public override int max_health { get => base.max_health; protected set => base.max_health = Math.Clamp(value, 0, 1100); }
        public override int damage { get => base.damage; protected set => base.damage = Math.Clamp(value, 0, 200); }
        public override int speed { get => base.speed; protected set => base.speed = Math.Clamp(value, 0, 12); }

        public Russia()
        {
            max_health = 20;
            health = max_health;
            bodydamage = 2;
            damage = 4;

            r = (Color)(rng.Next(0, 10));

            pst = new Position(rng.Next(1, 501), rng.Next(1, 501));
        }

        public override void TakeDamage()
        {
           
        }

        public override void LevelUp()
        {
            
        }

        public override void Die()
        {
            
        }

        public override void Fire()
        {
            
        }
    }

    class Usa : Classic_tank
    {
        public override int max_health { get => base.max_health; protected set => base.max_health = Math.Clamp(value, 0, 1400); }
        public override int damage { get => base.damage; protected set => base.damage = Math.Clamp(value, 0, 180); }

        public Usa()
        {
            max_health = 20;
            health = max_health;
            bodydamage = 2;
            damage = 4;

            r = (Color)(rng.Next(0, 10));

            pst = new Position(rng.Next(1, 501), rng.Next(1, 501));
        }

        public override void TakeDamage()
        {

        }

        public override void LevelUp()
        {

        }

        public override void Die()
        {

        }

        public override void Fire()
        {

        }
    }

    class China : Classic_tank
    {
        public override int max_health { get => base.max_health; protected set => base.max_health = Math.Clamp(value, 0, 1100); }
        public override int damage { get => base.damage; protected set => base.damage = Math.Clamp(value, 0, 200); }

        public China()
        {
            max_health = 20;
            health = max_health;
            bodydamage = 2;
            damage = 4;

            r = (Color)(rng.Next(0, 10));

            pst = new Position(rng.Next(1, 501), rng.Next(1, 501));
        }
        public override void TakeDamage()
        {

        }

        public override void LevelUp()
        {

        }

        public override void Die()
        {

        }

        public override void Fire()
        {

        }
    }

    class Germany : Classic_tank
    {
        public override int max_health { get => base.max_health; protected set => base.max_health = Math.Clamp(value, 0, 1100); }
        public override int damage { get => base.damage; protected set => base.damage = Math.Clamp(value, 0, 200); }

        public Germany()
        {
            max_health = 20;
            health = max_health;
            bodydamage = 2;
            damage = 4;

            r = (Color)(rng.Next(0, 10));

            pst = new Position(rng.Next(1, 501), rng.Next(1, 501));
        }
        public override void TakeDamage()
        {

        }

        public override void LevelUp()
        {

        }

        public override void Die()
        {

        }

        public override void Fire()
        {

        }
    }

    struct Position
    {
        public int x;
        public int y;

        public Position(int X, int Y)
        {
            this.x = X;
            this.y = Y;
        }

        public void Local()
        {
            Console.WriteLine("O");
            Console.SetCursorPosition(x, y);
        }
    }

    enum Color
    {
        white, black, red, blue, yellow,
        green, gray, brown, pink, purple
    }
}
