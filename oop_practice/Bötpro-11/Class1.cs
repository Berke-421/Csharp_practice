using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_11
{
    class Class1
    {
        static void Main()
        {
            Araba berke = new Araba();

            berke.araç = "Tofaş";
            berke.model = "Doğan";
            berke.hiz = 100;

            berke.arttir(20);

            Console.WriteLine($"hiz arttı: {berke.hiz}");

            berke.azalt(10);

            Console.WriteLine($"hiz azaldı: {berke.hiz}");
        }
    }

    class Araba
    {
        public string? araç;
        public string? model;
        public short hiz;

        public short arttir(short a)
        {
            return hiz += a;
        }

        public short azalt(short b)
        {
            return hiz -= b;
        }
    }
}
