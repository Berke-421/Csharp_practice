using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_33
{
    class Class1
    {
        static void Main(string[] args)
        {
            Player nesne = new Player();

            Player.Basla();
            nesne.Vuruldu();
            nesne.Vuruldu();
            nesne.CanGoster();
        }
    }

    class Player
    {
        public static string? name;

        private static byte _can;
        public static byte can
        {
            get => _can;

            set
            {
                if (value < 100 && value > 0)
                    _can = value;

                else if (value <= 0)
                    value = 0;

                else
                    value = 100;
            }
        }

        static Player()
        {
            can = 100; // yapıcı metot içinde public olursa şart çalışır
        }

        public static void Basla()
        {
            Console.WriteLine("Oyun başladı");
        }

        public int Vuruldu()
        {
            return _can -= 5;
        }

        public int İyiles()
        {
            return _can += 5;
        }

        public void CanGoster()
        {
            Console.WriteLine(_can);
        }
    }
}
