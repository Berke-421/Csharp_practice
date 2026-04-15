using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_1
{
    class Class1
    {
        static void Main()
        {
            Diktortgen berke = new Diktortgen();
            berke.yukseklik = 32;
            berke.genislik = 56;

            Console.WriteLine("Alan = " + berke.alan());
            Console.WriteLine("Çevre = " + berke.cevre());
            Console.WriteLine("Oran = " + berke.oran());

            Diktortgen adam = new Diktortgen();
        }
    }

    class Diktortgen
    {
        public double yukseklik;
        public double genislik;

        public double alan()
        {
            return yukseklik * genislik;
        }

        public double cevre()
        {
            return 2 * (genislik + yukseklik);
        }

        public double oran()
        {
            return yukseklik / genislik;
        }
    }
}
