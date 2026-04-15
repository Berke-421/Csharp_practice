using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_6
{
    class Class1
    {
        static void Main()
        {
            Personel adam1 = new Personel();

            adam1.ad = "Hüseyin";
            adam1.tc = 123554465;
            adam1.numara = 456;

            adam1.bilgiver();

            Console.WriteLine();

            Personel adam2 = new Personel();

            adam2.tc = 342323453;
            adam2.ad = "Berke";
            adam2.numara = 001;

            adam2.bilgiver();

            Console.WriteLine();

            Personel adam3 = new Personel();

            adam3.ad = "Kerem";
            adam3.tc = 224343346;
            adam3.numara = 100;

            adam3.bilgiver();
        }
    }

    class Personel
    {
        public int tc;
        public string? ad;
        public int numara;

        public void bilgiver()
        {
            Console.WriteLine($"T.C. kimlik: {tc} ,ad: {ad}, numara kaydı: {numara}");
        }

    }
}
