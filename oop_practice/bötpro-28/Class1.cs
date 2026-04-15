using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bötpro_27
{
    class Class1
    {
        static void Main(string[] args)
        {
            Daire nesne1 = new Daire(4.23);

            double a = nesne1.Alan();
            Console.WriteLine(a);

            Daire nesne2 = new Daire(6.8);
            a = nesne2.Alan();
            Console.WriteLine(a);

            Daire nesne3 = new Daire(2.3425);
            a = nesne3.Cevre();
            Console.WriteLine(a);
        }
    }

    class Daire
    {
        private double r;
        public double R
        {
            get => r;

            set => r = (value > 0) ? value : throw new Exception();
        }

        private static short sayac = 0;

        public Daire(double R) // HATIRLATMA: SINIF ÇALIŞIRKEN İLK BURASI DEVREYE GİRER
        {
            this.r = R;
            sayac++;
            Console.WriteLine($"Yani daire oluşturuldu! Toplamda {sayac} adet daire var");
        }

        public double Alan()
        {
            return Math.PI * Math.Pow(r, 2);
        }

        public double Cevre()
        {
            return 2 * Math.PI * r;
        }
    }
}
