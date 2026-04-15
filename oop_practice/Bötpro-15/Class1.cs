using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_15
{
    class Class1
    {
        static void Main()
        {
            Banka nesne = new Banka("Berke", 7846, 456);

            nesne.ParaCek(450);

            nesne.ParaEkle(130);

            nesne.HesapBilgileriGöster();
        }
    }

    class Banka
    {
        public string? ad;
        public int bakiye;
        public short hesapNo;

        private static byte sayac;
        private static string? BankaAdı = "Biçer";

        public Banka(string isim, int baslangıçbakiyesi, short hesapnumarası)
        {
            ad = isim;
            bakiye = baslangıçbakiyesi;
            hesapNo = hesapnumarası;

            sayac++;
            Console.WriteLine($"yeni hesap eklendi! toplamda {sayac} adet hesap oldu");
        }

        public void ParaCek(int miktar)
        {
            if (bakiye >= miktar)
            {
                bakiye -= miktar;
                Console.WriteLine($"{miktar} TL başarıyla çekildi yeni bakiyeniz: {bakiye}");
            }

            else
            {
                Console.WriteLine("Yetersiz bakiye");
            }
        }

        public void ParaEkle(int miktar)
        {
            bakiye += miktar;
            Console.WriteLine($"{miktar} TL başarıyla eklendi yeni bakiyeniz {bakiye}");
        }

        public void HesapBilgileriGöster()
        {
            Console.WriteLine($"Hesap adı: {ad}");
            Console.WriteLine($"Bakiye: {bakiye}");
            Console.WriteLine($"Hesap No: {hesapNo}");
        }
    }
}
