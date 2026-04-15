using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_64
{
    class Class1
    {
        static void Main(string[] args)
        {
            // Test area
        }
    }

    abstract class SpaceShip
    {
        public abstract int health { get; protected set; }
        public abstract int maxhealth { get; protected set; }

        public abstract int shield { get; protected set; }
        public abstract int damage { get; protected set; }


        private int _level;
        public int level
        {
            get => _level;

            private set => _level = Math.Clamp(value, 1, 60);
        }

        private string? _name;
        public string? name
        {
            get => _name;

            private set => _name = value?.Length <= 15 ? value : value?.Substring(0, 15);
        }

        private int _score;
        public int score
        {
            get => _score;

            private set => _score = Math.Clamp(value, 0, 99999999);
        }

        private int _border;
        public int border
        {
            get => _border;

            private set => _border = Math.Clamp(value, 100, 60000);
        }

        private static int up;

        public bool IsDie { get; private set; }

        private static int _count;
        public static int count { get => _count; private set => _count = Math.Clamp(value, 0, 35); }

        public static Dictionary<string, int> tablo { get; private set; }

        static SpaceShip()
        {
            tablo = new Dictionary<string, int>();
            count = 0;
            up = 2;
        }

        public SpaceShip()
        {
            count++;
            level = 1;
            score = 0;
            IsDie = false;
            border = 100;

            tablo.Add(name!, score);
        }

        public static void Start() { }

        public void Die() { IsDie = true; }

        public void LevelUp()
        {
            /** 
            
            if(score > border)
            {
                border *= up;
                level += 1;
            }
            
            **/
        }

        public void entername() 
        {
            name = Console.ReadLine();
        }
        public void exitgame() { }

        public abstract void laserattack();
        public abstract void move();
        public abstract void takedamage();
    }

    class Fighter : SpaceShip
    {
        private int _health;
        private int _maxhealth;
        private int _shield;
        private int _damage;
        public override int health { get => _health; protected set => _health = Math.Clamp(value, 0, maxhealth); }
        public override int maxhealth { get => _maxhealth; protected set => _maxhealth = Math.Clamp(value, 200, 9000); }
        public override int shield { get => _shield; protected set => _shield = Math.Clamp(value, 5, 200); }
        public override int damage { get => _damage; protected set => _damage = Math.Clamp(value, 4, 90); }

        public Fighter()
        {

        }

        public override void move()
        {
            throw new NotImplementedException();
        }

        public override void laserattack()
        {
            throw new NotImplementedException();
        }

        public override void takedamage()
        {
            throw new NotImplementedException();
        }
    }
}
