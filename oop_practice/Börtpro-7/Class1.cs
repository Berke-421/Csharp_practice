using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Börtpro_7
{
    class Class1
    {
        static void Main()
        {
            Kitap berke = new Kitap();
            Console.Write("Kitap adı: ");
            berke.kitapadi = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Sayfa sayısı: ");
            berke.sayfa = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Yazar adı: ");
            berke.yazar = Console.ReadLine();

            Console.WriteLine();

            berke.bilgigoster();
        }
    }

    class Kitap
    {
        public string? kitapadi;
        public string? yazar;
        public short sayfa;

        public void bilgigoster()
        {
            Console.WriteLine($"yazarı {yazar} olan, {sayfa} sayfalık {kitapadi} kitabını okuyorum :)");
        }
    }
}
