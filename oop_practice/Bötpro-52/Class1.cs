using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_52
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    class Tank
    {

        private int _Health_regen;
        private int _Max_health;
        private int _Body_damage;
        private int _Bullet_speed;
        private int _Bullet_penetration;
        private int _Bullet_damage;
        private int _reload;
        private int _speed;
        public virtual int Healt_regen
        {
            get => _Health_regen;

            protected set => _Health_regen = Math.Clamp(value, 0, 14);
        }

        public virtual int Max_health
        {
            get => _Max_health;

            protected set => _Max_health = Math.Clamp(value, 1, 210);
        }

        public virtual int Body_damage
        {
            get => _Body_damage;

            protected set => _Body_damage = Math.Clamp(value, 1, 32);
        }

        public virtual int Bullet_Speed
        {
            get => _Bullet_speed;

            protected set => _Bullet_speed = Math.Clamp(value, 1, 35);
        }

        public virtual int Bullet_penetration
        {
            get => _Bullet_penetration;

            protected set => _Bullet_penetration = Math.Clamp(value, 1, 112);
        }

        public virtual int Bullet_damage
        {
            get => _Bullet_damage;

            protected set => _Bullet_damage = Math.Clamp(value, 1, 21);
        }

        public virtual int reload
        {
            get => _reload;

            protected set => _reload = Math.Clamp(value, 1, 14);
        }

        public virtual int speed // Bütün sınıflardan okunur ama sadece ana ve türetilmiş sınıflardan şayarlanmış kurallara göre değiştirilebilir
        {
            get => _speed;

            protected set => _speed = Math.Clamp(value, 1, 7);
        }

        public static int count { get; private set; } 

        static Tank()
        {
            count = 0;
        }

        public Tank()
        {
            speed = 1; reload = 1; Bullet_damage = 1; Bullet_penetration = 1;
            Body_damage = 1; Bullet_Speed = 1; Max_health = 30;

            count++;
        }

        public virtual void Fire()
        {
            Console.WriteLine("ta ta ta");
        }

        public virtual void Take_damage()
        {
            Console.WriteLine("RED");
        }

        public virtual void Move()
        {
            Console.WriteLine("Tank is moving");
        }

        public virtual void Die()
        {
            Console.WriteLine("Tank is gone");
        }
    }

    class Enemy : Tank
    {
        public Enemy()
        {
            speed = 1; reload = 2; Bullet_damage = 2; Bullet_penetration = 1;
            Body_damage = 2; Bullet_Speed = 1; Max_health = 35;
        }
    }
}
