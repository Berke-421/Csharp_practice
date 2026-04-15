using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_40
{
    class Class1
    {
        static void Main(string[] args)
        {
            Minyon a = new Minyon();
            a.konum.x = 2;
            a.konum.y = 3;
        }
    }

    class Minyon
    {
        private float _can;
        public float can
        {
            get => _can;

            set => _can = Math.Clamp(value, 0, 100);
        }

        private float Damage;

        public Position konum;
        private static short doğ;

        private Renk renk;

        private static Random rng = new Random();

        private static sbyte sayac;

        private int ata;

        static Minyon()
        {
            sayac = 0;
            doğ = 1;
        }
        public Minyon()
        {
            doğ++;
            ata = rng.Next(0, 5);
            renk = (Renk)ata;

            Damage = 0.5f;

            konum = new Position(0, doğ);

            sayac++;
        }

        public void attack(float counter)
        {

        }

        public void TakeDamage(float counter)
        {

        }
    }

    struct Position // pozisyon çünkü hafızada az yer kaplıyor ve performans için struct daha iyi
    {
        public short x;
        public short y;

        public Position(short X, short Y)
        {
            x = X;
            y = Y;
        }

        public void Local()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("nesne");
        }
    }

    enum Renk
    {
        kırmızı, sarı, yeşil, siyah, beyaz
    }
}
