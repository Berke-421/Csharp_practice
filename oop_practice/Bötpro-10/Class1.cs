using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_10
{
    class Class1
    {
        static void Main()
        {
            Banka berke = new Banka();

            berke.hesapAdi = "yokedici65";
            berke.bakiye = 120000;

            Console.WriteLine("Para eklemek için 1'e para çıkarmak için 0'a basınız");
            string? tercih = Console.ReadLine();

            switch (tercih)
            {
                case "1":
                    Console.WriteLine("Ne kadar para eklenecek");
                    int a = Convert.ToInt32(Console.ReadLine());
                    berke.paraYatır(a);
                    Console.WriteLine($"TL başarıyla yatırıldı yeni bakiyeniz: {berke.bakiye}");
                    break;

                case "0":
                    Console.WriteLine("Ne kadar para çekilecek");
                    int b = Convert.ToInt32(Console.ReadLine());
                    berke.paraCek(b);
                    Console.WriteLine($"TL başarıyla çekildi yeni bakiyeniz {berke.bakiye}");
                    break;

                default:
                    Console.WriteLine("Tercih girilmedi");
                    break;

            }
        }
    }

    class Banka
    {
        public string? hesapAdi;
        public int bakiye;

        public int paraYatır(int a)
        {
            return bakiye += a;
        }

        public int paraCek(int b)
        {
            return bakiye -= b;
        }
    }
}
