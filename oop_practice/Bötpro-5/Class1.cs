using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_5
{
    class Class1
    {
        static void Main()
        {
            Console.WriteLine("Daire hesaplama:");
            Daire berke = new Daire();

            berke.r = 5.63;
            Console.WriteLine($"Alan = {berke.alan()}");

            Console.WriteLine();

            Console.WriteLine("Dikdörtgen hesaplama:");
            Diktorgen berke2 = new Diktorgen();

            berke2.yuks = 36;
            berke2.gen = 41;

            Console.WriteLine($"Alan = {berke2.alan()}. Çevre = {berke2.cevre()}");

            Console.WriteLine();

            Console.WriteLine("Küp hesaplama:");
            Kup nesne = new Kup();

            nesne.r = 7.94;

            Console.WriteLine($"Yüzey alanı = {nesne.yuzeyalani()}. Hacim = {nesne.hacim()}");

            Console.WriteLine();

            Console.WriteLine("Kare hesaplama");
            Kare bicer = new Kare();

            bicer.kenar = 23;
            Console.WriteLine($"Alan = {bicer.alan()}. Çevre = {bicer.cevre()}");

            Console.WriteLine();

            Console.WriteLine("Üçgen hesaplama");
            Ucgen gunes = new Ucgen();

            gunes.yuks = 34;
            gunes.tabankenar = 67;
            gunes.kenar1 = 23;
            gunes.kenar2 = 28;

            Console.WriteLine($"Alan = {gunes.alan()}. Çevre = {gunes.cevre()}");

            Console.WriteLine();

            Console.WriteLine("Silindir hesaplama");
            Silindir yatak = new Silindir();

            yatak.yuks = 37;
            yatak.r = 4.56;

            Console.WriteLine($"Yüzey alanı = {yatak.yuzeyalanı()}. Hacim = {yatak.hacim()}");
        }
    }

    class Daire
    {
        public double r;

        public double alan()
        {
            return Math.PI * Math.Pow(r, 2);
        }

        public double cevre()
        {
            return 2 * Math.PI * r;
        }
    }

    class Diktorgen
    {
        public double yuks;
        public double gen;

        public double alan()
        {
            return yuks * gen;
        }

        public double cevre()
        {
            return 2 * (gen + yuks);
        }
    }

    class Kup
    {
        public double r;

        public double yuzeyalani()
        {
            return 4 * Math.PI * Math.Pow(r, 2);
        }

        public double hacim()
        {
            return (4 / 3) * Math.PI * Math.Pow(r, 3);
        }
    }

    class Kare
    {
        public double kenar;

        public double alan()
        {
            return Math.Pow(kenar, 2);
        }

        public double cevre()
        {
            return 4 * kenar;
        }
    }

    class Ucgen
    {
        public double tabankenar;
        public double kenar1;
        public double kenar2;
        public double yuks;

        public double alan()
        {
            return (yuks * tabankenar) / 2;
        }

        public double cevre()
        {
            return tabankenar + kenar1 + kenar2;
        }
    }

    class Silindir
    {
        public double r;
        public double yuks;

        public double yuzeyalanı()
        {
            return 2 * Math.PI * r * yuks;
        }

        public double hacim()
        {
            return Math.PI * Math.Pow(r, 2) * yuks;
        }
    }
}
