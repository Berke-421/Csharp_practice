using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_16
{
    class Class1
    {
        static void Main(string[] args)
        {
            Araba berke = new Araba();

            berke.marka = "Tofaş";
            berke.model = "Doğan";

            berke.km = 40000;
            berke.hiz = 54;

            berke.BilgiGöster();

            berke.HizArttır(34);

            Console.WriteLine();

            Araba nesne = new Araba();

            nesne.marka = "Renault";
            nesne.model = "Clio";

            nesne.hiz = 80;
            nesne.km = 5622;

            nesne.HizAzalt(12);
            nesne.BilgiGöster();
        }
    }

    class Araba
    {
        public string? marka;
        public string? model;
        public short hiz;
        public int km;
        private static byte sayac;

        public Araba()
        {
            marka = "'Belirtilmedi'";
            model = "'Belirtilmedi'";
            hiz = 0;
            km = 0;

            sayac++;
            Console.WriteLine($"Yeni araç eklendi! Toplamda {sayac} araba oldu");
        }

        public void BilgiGöster()
        {
            Console.WriteLine($"{marka} {model} arabasına sahibim. Arabam {km} km yaptı");
        }

        public void HizArttır(short miktar)
        {
            hiz += miktar;

            Console.WriteLine($"Hız {miktar} KM/h daha arttırıldı");
        }

        public void HizAzalt(short miktar)
        {
            hiz -= miktar;

            Console.WriteLine($"Hız {miktar} KM/h azaltıldı");
        }
    }
}
