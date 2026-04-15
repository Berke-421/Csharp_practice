using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_4
{
    class Class1
    {
        static void Main()
        {
            Console.WriteLine("------------------------------------------Dikdörtgen-----------------------------------------");

            Dikdortgen berke = new Dikdortgen();

            berke.yukseklik = 46;
            berke.genislik = 58;

            Console.WriteLine($"Alan = {berke.alan()}");
            Console.WriteLine($"Çevre = {berke.cevre()}");

            Console.WriteLine("---------------------------------------------------");

            Dikdortgen nesne1 = new Dikdortgen();

            nesne1.genislik = 99;
            nesne1.yukseklik = 2;

            Console.WriteLine($"Alan = {nesne1.alan()}");
            Console.WriteLine($"Çevre = {nesne1.cevre()}");

            Console.WriteLine("-------------------------------------------Daire-----------------------------------------");

            Daire bicer = new Daire();

            bicer.r = 4.32;

            Console.WriteLine($"Alan = {bicer.Alan()}");
            Console.WriteLine($"Çevre = {bicer.cevre()}");

            Console.WriteLine("---------------------------------------------------");

            Daire nesne2 = new Daire();

            nesne2.r = 7.64;

            Console.WriteLine($"Alan = {nesne2.Alan()}");
            Console.WriteLine($"Çevre = {nesne2.cevre}");


        }
    }

    class Dikdortgen
    {
        public double yukseklik;
        public double genislik;

        public double alan()
        {
            return yukseklik * genislik;
        }

        public double cevre()
        {
            return 2 * (yukseklik + genislik);
        }
    }

    class Daire
    {
        public double r;

        public double Alan()
        {
            return Math.PI * r * r;
        }

        public double cevre()
        {
            return 2 * Math.PI * r;
        }
    }
}
