using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_39
{
    class Class1
    {
        static void Main(string[] args)
        {
            AnaOyuncu nesne = new AnaOyuncu();
        }
    }

    class AnaOyuncu
    {
        private double _can;
        public double can
        {
            get => _can;

            set
            {
                if (value > 0)
                    _can = value;

                else if (value <= 0)
                    _can = 0;
                else if (value > 5)
                    _can = 5;
            }
        }

        private double attackDamage;

        public AnaOyuncu()
        {
            can = 5;
            attackDamage = 0.5;
        }

        public void Attack(double counter)
        {
            
        }

        public void Damage(double counter)
        {
            can -= counter;
        }
    }
}