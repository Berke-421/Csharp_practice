using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_23
{
    class Hata : Exception
    {
        public Hata(string mesaj) : base(mesaj)
        {
            
        }
    }
    class Class1
    {
        static void Main(string[] args)
        {
            Dikdortgen berke = new Dikdortgen(12, 12);

            Console.WriteLine($"cevap: {berke.Alan()}");
        }
    }

    class Dikdortgen
    {
        private int yukseklik;
        public int Yukseklik
        {
            get => yukseklik;

            set
            {
                if (value < 0) 
                    throw new Hata("Hata: Yükseklik negatif olamaz");

                else 
                    yukseklik = value;
            }
        }

        private int genislik;
        public int Genislik
        {
            get => genislik;

            set
            {
                if (value < 0) 
                    throw new Hata("Hata: Genlişlik negatif olamaz");

                else 
                    genislik = value;
            }
        }

        private static byte sayac { get; set; }

        static Dikdortgen()
        {
            sayac = 0;
        }

        public Dikdortgen(int yukseklik, int genislik)
        {
            Yukseklik = yukseklik;
            Genislik = genislik;

            sayac += 1;
        }

        public int Alan()
        {
            return Yukseklik * Genislik;
        }
    }
}