using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_24
{
    class Class1
    {
        static void Main(string[] args)
        {
            Dikdörtgen nesne1 = new Dikdörtgen(); // nesne1 adında bir nesne oluşturup dikdörtgen sınıfına bağladık
            nesne1.Yukseklik = 34; // nesne1 değişkeninin sınıfından yukseklik özelliğinin değeri atanır
            nesne1.Genislik = 78; //nesne 1 değişkenin sınıfından genişlik özelliğinin değeri atanır

            Console.WriteLine($"Alan = {nesne1.Alan()} | Çevre = {nesne1.Cevre()}");
            //nesne1 değişkeninin sınıfındaki alan() metoduna ulaşılır ve nesne1 değişkeninin sınıfındaki alan() metoduna ulaşılır

            Console.WriteLine();

            Dikdörtgen nesne2 = new Dikdörtgen();

            nesne2.Yukseklik = 43;
            nesne2.Genislik = 88;

            Console.WriteLine($"Alan = {nesne2.Alan()} | Çevre = {nesne2.Cevre()}");

            Dikdörtgen dene = new Dikdörtgen();

            dene.Yukseklik = 45;
            dene.Genislik = 3;

            Console.WriteLine($"Alan = {dene.Alan()} | Çevre = {dene.Cevre()}");
        }
    }

    class Dikdörtgen
    {
        private short yukseklik;
        public short Yukseklik
        {
            get => yukseklik; // get { return yukseklik; } versiyonunun farklı hali

            set => yukseklik = value > 0
                ? value
                : throw new ArgumentOutOfRangeException(nameof(Yukseklik), "Yükseklik pozitif olmalı");
        }

        private short genislik;
        public short Genislik
        {
            get => genislik;

            set => yukseklik = value > 0
                ? value
                : throw new ArgumentOutOfRangeException(nameof(Genislik), "Ge");
        }

        private static byte counter; // sadece kendi sınıfı için erişimi olan sınıfa bağlı (statik) sayaç özelliği. Bu sayede nesneye bağlı kalmadan her nesnede sayaç 1 artar

        public Dikdörtgen() // Dikdörtgen sınıfının yapıcı metodudur. Her nesne oluşturulduğunda ilk işlemler yapılır
        {
            yukseklik = 1; // yuksekliğin varsayılan ayarı
            genislik = 1; // genişliğin varsayılan ayarı

            counter++; // her nesnede sayaç 1 artacak
            Console.WriteLine($"Yeni dikdörtgen oluşturuldu! Toplamda {counter} adet dikdörtgen var"); // her nesne oluşturulduğunda verilecek mesaj
        }

        public int Alan() // dikdörtgen sınıfının Alan() adlı metodu
        {
            return (int)(yukseklik * genislik); // Alanı hesaplayan kod
        }

        public int Cevre()
        {
            return (int)(2 * (yukseklik + genislik)); // Çevreyi hesaplayan kod
        }
    }
}
