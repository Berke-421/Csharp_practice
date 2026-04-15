using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_14
{
    class Class1
    {
        static void Main()
        {
            Sinema berke = new Sinema();

            berke.film = "Adam";
            berke.yönetmen = "Hüseyin çevik";
            berke.sure = 97;

            berke.izle();

            Console.WriteLine();

            Sinema nesne = new Sinema();

            nesne.film = "SDE";
            nesne.yönetmen = "çocuk adam";
            nesne.sure = 120;

            nesne.izle();

            Console.WriteLine();

            Sinema bicer = new Sinema();

            nesne.film = "sodıf";

            nesne.izle();

            Sinema b = new Sinema();
            b.izle();
        }
    }
    class Sinema
    {
        public string? film;
        public string? yönetmen;
        public byte sure;
        private static short sayac;

        public Sinema()
        {
            film = "'Girilmedi'";
            yönetmen = "'Girilmedi'";
            sure = 0;

            sayac++;
            Console.WriteLine($"Yeni film eklendi: toplamda {sayac} adet sayı oldu!");
        }

        public void izle()
        {
            Console.WriteLine($"{film} filmi izle! Süre: {sure}, yönetmen: {yönetmen}");
        }
    }
}
