using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_17
{
    class Class1
    {
        static void Main(string[] args)
        {
            Not nesne = new Not("berke", 91);

            Not nesne2 = new Not("Ayşe", 67);

            Not.Ortalama();
        }
    }

    class Not
    {
        public string? ogrenci;
        public byte notu;
        public static List<byte> notlar = new List<byte>();

        private static byte sayac;

        public Not(string isim = "'Belirtilmedi'", byte not = 0)
        {
            ogrenci = isim;
            notu = not;

            notlar.Add(notu);

            sayac++;
            Console.WriteLine($"Toplamda {sayac} öğrenci");
        }

        public static void Ortalama()
        {
            int toplam = 0;

            for (int i = 0; i < notlar.Count; i++)
            {
                toplam += notlar[i];
            }

            double ort = toplam / notlar.Count;
            Console.WriteLine($"Ortalama: {ort}");
        }
    }
}
