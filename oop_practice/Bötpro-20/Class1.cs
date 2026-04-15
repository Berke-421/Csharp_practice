using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bötpro_20;

namespace Bötpro_20
{
    class Class1
    {
        static void Main(string[] args)
        {
            int sayi = Mat.KareAl(8);
            Console.WriteLine("cevap: " + sayi);

            int sayi2 = Mat.KupAl(43);
            Console.WriteLine("cevap :" + sayi2);
        }
    }

    class Mat
    {
        public static int sayi { set; get; }
        public static int KareAl(int sayi1)
        {
            return sayi1 * sayi1;
        }

        public static int KupAl(int sayi2)
        {
            return sayi2 * sayi2 * sayi2;
        }
    }
}
