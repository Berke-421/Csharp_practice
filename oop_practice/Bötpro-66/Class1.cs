using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_66
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            Telefon berke = new Telefon();

            Console.WriteLine("Marka: " + berke.marka);
        }
    }

    public abstract class Cihaz
    {
        public abstract int fiyat {  get; protected set; } // cihazın fiyatı
        public abstract int hasar {  get; protected set; } // hasar değeri
        public abstract int maxhasar { get; protected set; } // maksimum hasar değeri

        private string? _isim;
        public string? isim // burada 
        {
            get => _isim;

            protected set => _isim = value?.Length <= 20 ? value : value?.Substring(0, 20); // isim uzunluğu max 20
        }

        private string? _marka;
        public string? marka
        {
            get => _marka;
            protected set => _marka = value; // burada marka uzunluğu için kısıtlama yok çünkü enum kullanılıyor ve markalar zaten belirli
        }

        private int _sarj; 
        public int sarj // şarj durumu her sınıf için aynı mantık ve kural geçerli
        {
            get => _sarj;
            protected set => _sarj = Math.Clamp(value, 0, 100); // şarj değeri 0 ile 100 arasında olmalı
        }

        private int _level;
        public int level
        {
            get => _level;

            protected set => _level = Math.Clamp(value, 1, 999); // seviye değeri 1 ile 999 arasında olmalı
        }

        private static int _Sayac;
        public static int Sayac // sayaç her sınıf için ortak özellik
        {
            get => _Sayac;

            private set => _Sayac = Math.Clamp(value, 0, 500); // sayaç değeri 0 ile 500 arasında olmalı
        }

        protected static Random rng; // rastgele sayı üreteci. Her sınıfın ortak kullanacağı araç
        protected static RandomDevice markatama; // rastgele marka atama aracı. protected çünkü türev sınıflar da kullanacak

        static Cihaz()
        {
            Sayac = 0; // sayaç başlangıç değeri
            rng = new Random(); // rastgele sayı üreteci başlatma
            markatama = new RandomDevice();
        }
        
        public Cihaz()
        {
            Sayac++; // her yeni cihaz oluşturulduğunda sayaç artar
            sarj = rng.Next(1, 100); // şarj değeri rastgele atanır çünkü her cihazın şarj durumu farklı olabilir
            // her sınıf için ortak başlangıç işlemleri burada yapılır
        }

        public static void Baslat() // ortak başlangıç metodu
        {

        }

        public int LevelUp() { return level++; } // seviye atlama metodu her sınıf için aynı mantıkta

        public abstract void Ac(); // cihazı açma metodu
        public abstract void Kapat(); // cihazı kapatma metodu
        public abstract void sarjEt(); // cihazı şarj etme metodu
        public abstract void hasaral(); // cihazın hasar alması metodu
    }

    public class Telefon : Cihaz
    {
        private int _hasar;
        private int _maxhasar;
        private int _fiyat;
        public override int fiyat { get => _fiyat; protected set => _fiyat = Math.Clamp(value, 0, 150); } // bin bazında fiyat
        public override int maxhasar { get => _maxhasar; protected set => _maxhasar = Math.Clamp(value, 100, 1000); } 
        public override int hasar { get => _hasar; protected set => _hasar = Math.Clamp(value, 0, maxhasar); }

        
        public Telefon()
        {
            // Telefon sınıfına özgü başlangıç işlemleri:
            marka = markatama.GetRandomPhone();
            fiyat = rng.Next(100, 1500); // fiyat rastgele atanır çünkü her telefonun fiyatı farklı olabilir
            maxhasar = 100;
            hasar = 0; // başlangıçta hasar 0 çünkü yeni cihaz
        }

        public override void Ac()
        {
            throw new NotImplementedException();
        }

        public override void hasaral()
        {
            throw new NotImplementedException();
        }

        public override void Kapat()
        {
            throw new NotImplementedException();
        }

        public override void sarjEt()
        {
            throw new NotImplementedException();
        }
    }

    public class Bilgisayar : Cihaz
    {
        private int _hasar;
        private int _maxhasar;
        private int _fiyat;

        public override int fiyat { get => _fiyat; protected set => _fiyat = Math.Clamp(value, 0, 150); } // bin bazında fiyat
        public override int maxhasar { get => _maxhasar; protected set => _maxhasar = Math.Clamp(value, 100, 1000); }
        public override int hasar { get => _hasar; protected set => _hasar = Math.Clamp(value, 0, maxhasar); }
        public Bilgisayar()
        {
            // Bilgisayar sınıfına özgü başlangıç işlemleri:
            marka = markatama.GetRandomComputer();
        }
        public override void Ac()
        {
            throw new NotImplementedException();
        }
        public override void hasaral()
        {
            throw new NotImplementedException();
        }
        public override void Kapat()
        {
            throw new NotImplementedException();
        }
        public override void sarjEt()
        {
            throw new NotImplementedException();
        }
    }

    public class RandomDevice
    {
        public string GetRandomPhone()
        {
            var modeller = Enum.GetValues<TelefonModel>(); // TelefonModel[]
            var choice = modeller[Random.Shared.Next(modeller.Length)];
            return choice.ToString();
        }

        public string GetRandomComputer()
        {
            var modeller = Enum.GetValues<BilgisayarModel>();
            var choice = modeller[Random.Shared.Next(modeller.Length)];
            return choice.ToString();
        }

        public string GetRandomTablet()
        {
            var modeller = Enum.GetValues<Tablet>();
            var choice = modeller[Random.Shared.Next(modeller.Length)];
            return choice.ToString();
        }
    }

    enum TelefonModel
    {
        Iphone, Samsung, Xiaomi, Oppo, Huawei, OnePlus, Nokia, Sony, LG, Motorola
    }

    enum BilgisayarModel
    {
        Dell, HP, Lenovo, Asus, Acer, MSI, Apple, Razer, Gigabyte, Samsung
    }

    enum Tablet
    {
        iPad, SamsungGalaxyTab, AmazonFire, MicrosoftSurface, LenovoTab, HuaweiMediaPad, AsusZenPad, AcerIconia, DellVenue, GoogleNexus
    }
}
