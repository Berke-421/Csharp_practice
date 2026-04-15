using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_72
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bötpro 72");
            Oyuncu berke = new Oyuncu();
            Console.WriteLine(berke.chi);
            berke.ChiArt();
            Console.WriteLine(berke.chi);
        }
    }

    public interface IOyuncu
    {
        int levelArt();
        int puanArt();
        void ozelguc();

        int level { get; }
        int puan { get; }
    }

    public abstract class Karakterler
    {
        public abstract string tür { get; } // türünü belirtlir sadece okuma amaçlıdır

        // absract özellikler her karakterde farklı olacağı için abstract olarak tanımlanmıştır
        public abstract int darbe { get; protected set; }
        public abstract int can { get; protected set; }
        public abstract int maxcan { get; protected set; }
        public abstract int enerji { get; protected set; }

        // static sayaç ile oluşturulan karakter sayısını takip ediyoruz
        private static int _sayac;
        public static int sayac
        {
            get => _sayac;
            private set => _sayac = Math.Clamp(value, 0, 100); // sadece ana sınıf tarafından değiştirilebilir
        }

        // her türev sınıf için ortak özellikler
        private int _chi;
        public int chi
        {
            get => _chi;
            private set => _chi = Math.Clamp(value, 1, 5); // herk karakter için aynı kural geçerli ve sadece ana sınıf tarafından değiştirilebilir
            // private ama ana sınıftaki metotta değiştirilip türev sınıfların değerini güncelleyebilir
        }

        private bool _yasiyormu;
        public bool yasiyormu
        {
            get => _yasiyormu;
            protected set => _yasiyormu = true; // sadece ana sınıf ve türev sınıflar tarafından değiştirilebilir
        }

        public static Random rng; // rastgele sayı üreticisi her sınıf için ortak araç

        static Karakterler()
        {
            sayac = 0; // static yapıcı ile sayaç başlangıç değeri atanıyor
            rng = new Random(); // static yapıcı ile rastgele sayı üretecisi başlatılıyor
        }

        public Karakterler()
        {
            chi = 1; // her karakter başlangıçta 1 chi ile başlar
            sayac++; // her karakter oluşturulduğunda sayaç 1 artar
        }

        // sadece türev alınan metotlardaki tüm işlemler her türev sınıf için ortak olduğundan burada tanımlanır
        public int ChiArt() // her sınıftan erişilebilen chi artırma metodu
        {
            // bu sayede chi artırma işlemi tek bir yerde yapılır ve tüm türev sınıflar için geçerli olur
            chi++;
            return chi; 
        }

        public abstract void saldir();
        public abstract void darbeal();
        public abstract void ol();
    }

    public class Oyuncu : Karakterler, IOyuncu
    {
        public override string tür => "Oyuncu";
        private int _darbe;
        private int _can;
        private int _maxcan;
        private int _enerji;
        public override int darbe { get => _darbe; protected set => _darbe = Math.Clamp(value, 1, 500); }
        public override int can { get => _can; protected set => _maxcan = Math.Clamp(value, 0, maxcan); }
        public override int maxcan { get => _maxcan; protected set => _maxcan = Math.Clamp(value, 50, 2000); }
        public override int enerji { get => _enerji; protected set => _enerji = Math.Clamp(value, 0, 40); }

        private int _level;
        private int _puan;
        public int level
        {
            get => _level;
            private set => _level = Math.Clamp(value, 1, 100);
        }
        public int puan
        {
            get => _puan;
            private set => _puan = Math.Clamp(value, 0, 999999);
        }

        public Oyuncu() // burada constructor ekliyoruz çünkü oyuncunun level ve puan değerleri başlangıçta 0 olmalı
        {
            level = 1;
            puan = 0;
        }

        public override void saldir()
        {
            throw new NotImplementedException();
        }

        public override void darbeal()
        {
            throw new NotImplementedException();
        }

        public override void ol()
        {
            throw new NotImplementedException();
        }

        public int levelArt()
        {
            level++;
            return level;
        }

        public int puanArt()
        {
            puan++;
            return puan;
        }

        public void ozelguc()
        {

        }
    }

    public class Normaldusman : Karakterler
    {
        public override string tür => "Oyuncu";
        private int _darbe;
        private int _can;
        private int _maxcan;
        private int _enerji;
        public override int darbe { get => _darbe; protected set => _darbe = Math.Clamp(value, 1, 550); }
        public override int can { get => _can; protected set => _can = Math.Clamp(value, 0, maxcan); }
        public override int maxcan { get => _maxcan; protected set => _maxcan = 9000; }
        public override int enerji { get => _enerji; protected set => _enerji = Math.Clamp(value, 0, 40); }

        public Normaldusman()
        {
            maxcan = rng.Next(50, 800);
            darbe = rng.Next(1, 550);
            can = maxcan;
            enerji = rng.Next(10, 40);
        }

        public override void saldir()
        {
            throw new NotImplementedException();
        }

        public override void darbeal()
        {
            throw new NotImplementedException();
        }

        public override void ol()
        {
            throw new NotImplementedException();
        }
    }


    public class Bossdusman : Karakterler
    {
        public override string tür => "Oyuncu";
        private int _darbe;
        private int _can;
        private int _maxcan;
        private int _enerji;
        public override int darbe { get => _darbe; protected set => _darbe = Math.Clamp(value, 1, 800); }
        public override int can { get => _can; protected set => _can = Math.Clamp(value, 0, maxcan); }
        public override int maxcan { get => _maxcan; protected set => _maxcan = 15000; }
        public override int enerji { get => _enerji; protected set => _enerji = Math.Clamp(value, 0, 60); }
        public Bossdusman()
        {
            maxcan = rng.Next(500, 1500);
            darbe = rng.Next(200, 800);
            can = maxcan;
            enerji = rng.Next(20, 60);
        }
        public override void saldir()
        {
            throw new NotImplementedException();
        }
        public override void darbeal()
        {
            throw new NotImplementedException();
        }
        public override void ol()
        {
            throw new NotImplementedException();
        }
    }
}
