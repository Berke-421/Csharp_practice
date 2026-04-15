using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_13
{
    class Class1
    {
        static void Main()
        {
            Kitap berke = new Kitap();

            berke.musteri = "Berke Biçer";
            berke.kitap = "Sefiller";
            berke.yazar = "Victor Hugo";
            berke.sayfa = 1700;
            berke.fiyat = 50;

            Console.WriteLine($"fiyat sayfa oranı: {berke.oran()}");
            berke.BilgiGoster();

            Console.WriteLine();

            Kitap nesne = new Kitap();

            nesne.musteri = "Hüseyin";
            nesne.kitap = "Pixar ve Ötesine";
            nesne.yazar = "Lawrence Levy";
            nesne.sayfa = 360;
            nesne.fiyat = 20;

            Console.WriteLine($"fiyat sayfa oranı: {nesne.oran()}");
            nesne.BilgiGoster();


            Kitap.deneme = "Naber";

            Kitap hat = new Kitap();
            hat.BilgiGoster();
        }
    }

    class Kitap
    {
        public string? musteri; // özellikler ve alanların yeri
        public string? kitap;
        public string? yazar;
        public static string? deneme;
        public short sayfa;
        public double fiyat;
        private static short sayac = 0;

        public Kitap()
        {
            sayac += 1;
            Console.WriteLine($"Yeni kitap eklendi. {sayac} adet oldu"); // kayıt işlem yeri

            musteri = "'Girilmedi'"; // varsayılan ayarlar yeri
            kitap = "'Girilmedi'";
            yazar = "'Girilmedi'";
            sayfa = 0;
            fiyat = 0;
        }

        public double oran() // oran yeri
        {
            return sayfa / fiyat;
        }

        public void BilgiGoster() // bilgilendirme yeri
        {
            Console.WriteLine($"yazarı {yazar} olan, {sayfa} sayfalık {kitap} kitabı okuyan {musteri} adında yeni bir müşteri eklendi");
        }


    }
}
