using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_21
{
    class Class1
    {
        static void Main(string[] args)
        {
            int sonuc1 = TemelMat.topla(23, 556);
            int sonuc2 = TemelMat.cikar(34, 23);

            int sonuc3 = TemelMat.carp(32, 54);
            double sonuc4 = TemelMat.bol(35, 7);

            Console.WriteLine($"Cevaplar sırasıyla: {sonuc1}, {sonuc2}, {sonuc3} ve {sonuc4}");
        }
    }

    class TemelMat
    {
        public const double PI = 3.14;
        public const int Bicer = 421;

        public static int topla(int a, int b)
        {
            return a + b;
        }

        public static int cikar(int x, int y)
        {
            return x - y;
        }

        public static int carp(int k, int m)
        {
            return k * m;
        }

        public static double bol(double c, double d)
        {
            try
            {
                return c / d;
            }

            catch (DivideByZeroException e)
            {
                Console.WriteLine("Hata yakalandı: " + e.Message);
                return 0;
            }
        }
    }
}
