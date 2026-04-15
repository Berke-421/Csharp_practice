using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_73
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bötpro 73");
        }
    }


    public interface Komik
    {
        string nasilbiri { get; }

    }

    public abstract class Doktorlar
    {
        public abstract string uzmanlik { get; } // türünü belirtlir sadece okuma amaçlıdır kullanıcıya bilgi vermek içindir
        public abstract int maas { get; protected set; } // maaş her doktor türünde farklı olacağı için abstract olarak tanımlanmıştır
        public abstract int enerji { get; protected set; } // enerji her doktor türünde farklı olacağı için abstract olarak tanımlanmıştır
        public abstract int tecrube { get; protected set; } // tecrübe her doktor türünde farklı olabilir

        private int mutluluk;
        public int Mutluluk
        {
            get => mutluluk;
            protected set => mutluluk = Math.Clamp(value, 0, 100); // sadece ana sınıf ve türev sınıflar tarafından değiştirilebilir
        }

        private bool _istifaettimi;
        public bool istifaettimi
        {
            get => _istifaettimi;
            private set => _istifaettimi = value; // sadece ana sınıf tarafından değiştirilebilir
        }

        private bool _izinlimi;
        public bool izinlimi
        {
            get => _izinlimi;
            private set => _izinlimi = value; // sadece ana sınıf ve türev sınıflar tarafından değiştirilebilir
        }

        private int _hastalar;
        public int hastalar
        {
            get => _hastalar;
            private set => _hastalar = Math.Clamp(value, 0, 100); // sadece ana sınıf ve türev sınıflar tarafından değiştirilebilir
        }

        private static int _doktorsayac;
        public static int doktorsayac { get => _doktorsayac; private set => _doktorsayac = Math.Clamp(value, 0, 250); }

        public readonly string? hastaneismi; // her doktorun bağlı olduğu hastane ismi değiştirilemez

        protected static Random rng;

        static Doktorlar()
        {
            doktorsayac = 0; // static yapıcı ile sayaç başlangıç değeri atanıyor
            rng = new Random(); // static yapıcı ile rastgele sayı üretecisi başlatılıyor
        }

        public Doktorlar()
        {
            doktorsayac++; // her yeni doktor nesnesi oluşturulduğunda sayaç artırılıyor
            istifaettimi = false; // başlangıçta istifa etmemiştir
            izinlimi = false; // başlangıçta izinde değildir
            mutluluk = rng.Next(30, 95); // başlangıç mutluluğu rastgele 30-95 arasında atanır
        }

        public static void Basla() { }
        public static void Bitir() { }

        public void IzınAl()
        {
            izinlimi = true;
            mutluluk += 10; // izne çıkan doktorun mutluluğu artar çünkü çalışma stresi azalır
        }

        public void IstenAyril()
        {
            istifaettimi = true;
            mutluluk -= 20; // işten ayrılan doktorun mutluluğu azalır çünkü işsizlik stresi başlar
        }

        public int HastaKabulEt()
        {
            hastalar++;
            return hastalar;
        }

        public abstract void UzmanlikAlaninaGoreIsYap(); // her doktor türü için farklı işlemler yapılabilir
        public abstract void MaasAl(); // her doktor türü için maaş alma işlemi farklı olabilir
        public abstract void EnerjiTuket(); // her doktor türü için enerji tüketimi farklı olabilir
        public abstract void TecrubeKazan(); // her doktor türü için tecrübe kazanma işlemi farklı olabilir
    }

    public class Kulakburunbogaz : Doktorlar
    {
        public override string uzmanlik => "kulak burun boğazcı";

        private int _maas; private int _enerji; private int _tecrube;
        public override int maas { get => _maas; protected set => Math.Clamp(value, 100, 1200); }
        public override int enerji { get => _enerji; protected set => Math.Clamp(value, 20, 100); }
        public override int tecrube { get => _tecrube; protected set => Math.Clamp(value, 1, 20); }

        public Kulakburunbogaz()
        {
            maas = rng.Next(300, 700);
            enerji = rng.Next(10, 80);
            tecrube = rng.Next(1, 10);
        }

        public override void UzmanlikAlaninaGoreIsYap()
        {
            throw new NotImplementedException();
        }

        public override void MaasAl()
        {
            throw new NotImplementedException();
        }

        public override void EnerjiTuket()
        {
            throw new NotImplementedException();
        }

        public override void TecrubeKazan()
        {
            throw new NotImplementedException();
        }
    }

    public class kardiyolog : Doktorlar
    {
        public override string uzmanlik => "kulak burun boğazcı";

        private int _maas; private int _enerji; private int _tecrube;
        public override int maas { get => _maas; protected set => Math.Clamp(value, 200, 2000); }
        public override int enerji { get => _enerji; protected set => Math.Clamp(value, 20, 100); }
        public override int tecrube { get => _tecrube; protected set => Math.Clamp(value, 1, 20); }

        public kardiyolog()
        {
            maas = rng.Next(300, 700);
            enerji = rng.Next(10, 80);
            tecrube = rng.Next(1, 10);
        }

        public override void UzmanlikAlaninaGoreIsYap()
        {
            throw new NotImplementedException();
        }

        public override void MaasAl()
        {
            throw new NotImplementedException();
        }

        public override void EnerjiTuket()
        {
            throw new NotImplementedException();
        }

        public override void TecrubeKazan()
        {
            throw new NotImplementedException();
        }
    }
    enum Kisilik
    {
        ofkeli, sakin, şaklaban, duygusal, komik, soğukkanlı
    }
}
