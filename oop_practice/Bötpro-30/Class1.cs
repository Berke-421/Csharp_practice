using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bötpro_30
{
    class Class1
    {
        static void Main(string[] args)
        {
            Silindir adam = new Silindir();
        }
    }

    class Silindir
    {
        private static double _yukseklik; // özellik
        public static double yuklseklik // özellik
        {
            get => _yukseklik;

            set => _yukseklik = (value > 0) ? value : throw new Exception(" ");
        }

        private double _r;
        public double r
        {
            get => _r;

            set => _r = (value > 0) ? value : throw new Exception(" ");
        }
        public static bool baglantı { get; set; }
        static Silindir()
        {
            baglantı = true;
            // bağlantılar kurulur
        }

        public Silindir()
        {

        }

        public static double Hacim()
        {
            return Math.PI * Math.Pow(_r, 2) * _yukseklik;
        }

        public static double Cevre()
        {
            return 2 * Math.PI * _r * _yukseklik ;
        }
    }
}
