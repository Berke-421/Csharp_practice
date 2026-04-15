using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_32
{
    class Class1
    {
        static void Main(string[] args)
        {
            Kure berke = new Kure(4.56);
        }
    }

    class Kure
    {
        private double _r;
        public double r
        {
            get => _r;

            set => _r = (value > 0) ? value : throw new Exception("Hata");
        }

        public Kure(double R)
        {
            Console.WriteLine("Yeni nesne oluşturuldu");
            r = R;
        }

        public double Hacim()
        {
            return (4 / 3) * (Math.PI * Math.Pow(r, 3));
        }

        public double YuzeyAlani()
        {
            return 4 * Math.PI * Math.Pow(r, 2);
        }
    }
}
