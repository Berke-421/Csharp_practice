using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_26
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    static class Dikdörtgen
    {
        private static short yukseklik;
        private static short genislik;

        public static int Alan(short y = 1, short g = 1)
        {
            yukseklik = y;
            genislik = g;
            return yukseklik * genislik;
        }

        public static int Cevre(short y = 1, short g = 1)
        {
            yukseklik = y;
            genislik = g;
            return 2 * (yukseklik + genislik);
        }
    }
}
