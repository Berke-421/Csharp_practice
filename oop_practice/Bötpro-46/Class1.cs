using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_46
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    class Son
    {
        private int _can;
        private int _damage;
        private int _money;
        private string? _name;

        public int can
        {
            get => _can;

            private set => _can = Math.Clamp(value, 0, 3);
        }

        public int money
        {
            get => _money;

            private set => _money = Math.Clamp(value, 0, 999999);
        }

        
        public int damage
        {
            get => _damage;

            private set => _damage = value;
        }

        public string? name
        {
            get => _name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("İsim boş olamaz");

                else
                    _name = value;
            }
        }
    }
}
