using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_1
{
    class Class2
    {
        static void Main()
        {
            Silindir berke = new Silindir();

            berke.r = 5.89;
            berke.yukseklik = 34;

            Console.WriteLine("Hacim = " + berke.Hacim());
            Console.WriteLine("Yüzey alanı = " + berke.yuzeyalani());

            Console.WriteLine("--------------------------------------------------------------");

            Silindir bicer = new Silindir();

            bicer.r = 2.13;
            bicer.yukseklik = 89;
            Console.WriteLine("Hacim = " + bicer.Hacim());
            Console.WriteLine("Yüzey alanı = " + bicer.yuzeyalani());
        }
    }

    class Silindir
    {
        private double r;
        public double yukseklik;

        public double Hacim()
        {
            return Math.PI * r * r * yukseklik;
        }

        public double yuzeyalani()
        {
            return 2 * Math.PI * r * yukseklik;
        }
    }
}
