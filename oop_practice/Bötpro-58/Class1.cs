using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_58
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class Tank
    {
        public abstract string? name { get; protected set; }
        public abstract int HealthRegen { get; protected set; }
        public abstract int Health { get; protected set; }
        public abstract int MaxHealth { get; protected set; }
        public abstract int BodyDamage { get; protected set; }
        public abstract int BulletSpeed { get; protected set; }
        public abstract int BulletDamage { get; protected set; }
        public abstract int Reload { get; protected set; }
        public abstract int Speed { get; protected set; }

        private int _level;
        public int level
        {
            get => _level;

            private set => _level = Math.Clamp(value, 1, 45);
        }

        public Team tm { get; private set; }
        private static Random rng;
        private static int _count;
        public static int count
        {
            get => _count;

            private set => _count = Math.Clamp(value, 0, 60);
        } 

        static Tank()
        {
            rng = new Random();
            count = 0;
        }

        public Tank()
        {
            count++;
            tm = (Team)(rng.Next(0, 4));
            level = 1;
        }

        public static void Start()
        {
            Console.WriteLine("Welcome");
        }

        public void LevelUp()
        {
            level++;
        }
        public abstract void Move();
        public abstract void Fire();
        public abstract void takeDamage();
        public abstract void Die();
    }

    class LightTank : Tank
    {
        private int _healthregen;
        private int _health;
        private int _MaxHealth;
        private int _BodyDamage;
        private int _BulletSpeed;
        private int _BulletDamage;
        private int _Reload;
        private int _Speed;
        private string? _name;

        public override string? name { get => _name; protected set => _name = value; }
        public override int HealthRegen { get => _healthregen; protected set => _healthregen = Math.Clamp(value, 1, 10); }
        public override int Health { get => _health; protected set => _health = Math.Clamp(value, 0, MaxHealth); }
        public override int MaxHealth { get => _MaxHealth; protected set => _MaxHealth = Math.Clamp(value, 30, 300); }
        public override int BodyDamage { get => _BodyDamage; protected set => _BodyDamage = Math.Clamp(value, 0, 70); }
        public override int BulletSpeed { get => _BulletSpeed; protected set => _BulletSpeed =  Math.Clamp(value, 0, 10); }
        public override int BulletDamage { get => _BulletDamage; protected set => _BulletDamage = Math.Clamp(value, 0, 200); }
        public override int Reload { get => _Reload; protected set => _Reload = Math.Clamp(value, 0, 20); }
        public override int Speed { get => _Speed; protected set => _Speed = Math.Clamp(value, 0, 10); }

        public LightTank()
        {

        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Die()
        {
            throw new NotImplementedException();
        }

        public override void Fire()
        {
            throw new NotImplementedException();
        }

        public override void takeDamage()
        {
            throw new NotImplementedException();
        }
    }

    enum Team
    {
        blue, red, green, purple
    }
}
