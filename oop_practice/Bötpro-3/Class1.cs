using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_3
{
    class Class1
    {
        static void Main()
        {
            Dikdörtgen berke = new Dikdörtgen();

            berke.yukseklik = 34;
            berke.genislik = 67;

            Console.WriteLine("Çevre = " + berke.cevre());
            Console.WriteLine("Alan = " + berke.alan());

            Console.WriteLine("-------------------------------------------");

            Dikdörtgen nesne = new Dikdörtgen();

            nesne.yukseklik = 21;
            nesne.genislik = 12;

            Console.WriteLine("Çevre = " + nesne.cevre());
            Console.WriteLine("Alan = " + nesne.alan());

            Console.WriteLine("-------------------------------------------");

            Dikdörtgen n = new Dikdörtgen();

            n.yukseklik = 197;
            n.genislik = 23;

            Console.WriteLine("Çevre = " + n.cevre());
            Console.WriteLine("Alan = " + n.alan());
        }
    }

    class Dikdörtgen
    {
        public double genislik;
        public double yukseklik;

        public double cevre()
        {
            return 2 * (genislik + yukseklik);
        }

        public double alan()
        {
            return genislik * yukseklik;
        }
    }
}
