using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_12
{
    class Class1
    {
        static void Main(string[] args)
        {
            Kitap berke = new Kitap();
            berke.kitap = "Sefiller";
            berke.yazar = "Victor Hugo";
            berke.sayfa = 1700;

            berke.bilgigoster();

            Console.WriteLine();

            Kitap bicer = new Kitap();
            bicer.kitap = "Cesur Yeni Dünya";
            bicer.yazar = "Aldous Huxley";
            bicer.sayfa = 250;

            bicer.bilgigoster();

            Console.WriteLine();

            Kitap nesne = new Kitap();
            nesne.bilgigoster();
        }
    }

    class Kitap
    {
        public string? kitap;
        public string? yazar;
        public short sayfa;

        public Kitap() // VARSAYILAN AYARLAR
        {
            Console.WriteLine("Yeni kitap eklendi");

            kitap = "'Bilinmiyor'";
            yazar = "'Bilinmiyor'";
            sayfa = 0;
        }

        public void bilgigoster()
        {
            Console.WriteLine($"yazarı {yazar} olan {sayfa} sayfalık olan {kitap} kitabı okuyorum :)");
        }
    }
}
