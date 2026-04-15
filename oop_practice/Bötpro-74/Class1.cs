using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_74
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            Cafe nesne = new Cafe();
            Console.WriteLine("Özellikler");
            Console.WriteLine("İsim: " + nesne.isim);
            Console.WriteLine("Mutluluk: " + nesne.mutluluk);
            Console.WriteLine("Can: " + nesne.can);
            Console.WriteLine("Tür: " + nesne.tur);
            Console.WriteLine("Yaş: " + nesne.yas);
        }
    }

    public interface Iortak { public string tur2 { get; } }

    public interface Ibelali
    {
        public int ekstravurus { get; }
        public void ozelVurus();
        public void kufurEt();
    }

    public interface Iefendi
    {
        public void nezaketGoster();
        public void yardimEt();
    }

    public abstract class NPC
    {
        public abstract string? tur { get; }
        public abstract int yas { get; protected set; }
        public abstract int vurusgucu { get; protected set; }
        public abstract int can { get; protected set; }

        private bool _oldumu;
        public bool oldumu { get => _oldumu; protected set => _oldumu = value; }

        private string? _isim;
        public string? isim
        {
            get => _isim;
            private set => _isim = value;
        }

        private int _mutluluk;
        public int mutluluk
        {
            get => _mutluluk;
            protected set => _mutluluk = Math.Clamp(value, 0, 100);
        }

        private static Name nameGenerator;

        private static int _sayac;
        public static int sayac { get => _sayac; private set => _sayac = Math.Clamp(value, 0, 30); }

        protected static readonly Random rng;

        static NPC()
        {
            rng = new Random();        
            sayac = 0;
            nameGenerator = new Name();
        }

        public NPC()
        {
            mutluluk = rng.Next(0, 100);
            oldumu = false;
            sayac++;
            isim = nameGenerator.GetRandomName();
        }

        public static void startGame() { }
        public static void endGame() { }

        public int dovus()
        {
            return mutluluk--;
        }

        public void isimAta()
        {

        }

        public abstract void konus();
        public abstract void hareketEt();
        public abstract void kac();
        public abstract bool ol();
    }

    public class Bar : NPC, Ibelali, Iortak
    {
        public override string? tur => "Bar";

        private int _yas; private int _vurusgucu; private int _can;
        public override int yas { get => _yas; protected set => _yas = Math.Clamp(value, 20, 65); }
        public override int vurusgucu { get => _vurusgucu; protected set => _vurusgucu = Math.Clamp(value, 3, 10); }
        public override int can { get => _can; protected set => _can = Math.Clamp(value, 50, 100); }

        public int ekstravurus => 5;
        public string tur2 => "Belalı Bar";
        public void ozelVurus()
        {
            Console.WriteLine("Özel Vuruş Gerçekleştirildi!");
        }

        public void kufurEt()
        {
            Console.WriteLine("Küfür Edildi!");
        }

        public Bar()
        {
            yas = rng.Next(20, 66);
            vurusgucu = rng.Next(3, 11);
            can = rng.Next(50, 101);
        }

        public override void konus()
        {
            Console.WriteLine("konuşuyor.");
        }

        public override void hareketEt()
        {
            Console.WriteLine("hareket ediyor.");
        }

        public override void kac()
        {
            Console.WriteLine("kaçıyor.");
        }

        public override bool ol()
        {
            oldumu = true;
            mutluluk = 0;
            Console.WriteLine("sert şekilde öldü.");
            return oldumu;
        }
    }

    public class Cafe : NPC, Iefendi, Iortak
    {
        public override string? tur => "Cafe";

        private int _yas; private int _vurusgucu; private int _can;
        public override int yas { get => _yas; protected set => _yas = Math.Clamp(value, 15, 50); }
        public override int vurusgucu { get => _vurusgucu; protected set => _vurusgucu = Math.Clamp(value, 1, 7); }
        public override int can { get => _can; protected set => _can = Math.Clamp(value, 30, 100); }

        public string tur2 => "Efendi";
        public void nezaketGoster()
        {
            Console.WriteLine("Nezaket Gösterildi!");
            mutluluk += 10;
        }

        public void yardimEt()
        {
            Console.WriteLine("Yardım Edildi!");
            mutluluk += 5;
        }

        public Cafe()
        {
            yas = rng.Next(15, 51);
            vurusgucu = rng.Next(1, 8);
            can = rng.Next(30, 101);
        }

        public override void konus()
        {
            Console.WriteLine("konuşuyor.");
        }

        public override void hareketEt()
        {
            Console.WriteLine("hareket ediyor.");
        }

        public override void kac()
        {
            Console.WriteLine("kaçıyor.");
        }

        public override bool ol()
        {
            oldumu = true;
            mutluluk = 0;
            Console.WriteLine("nazik şekilde öldü.");
            return oldumu;
        }
    }

    public class Restoran : NPC, Iefendi, Ibelali, Iortak
    {
        public override string? tur => "restoran";

        private int _yas; private int _vurusgucu; private int _can;
        public override int yas { get => _yas; protected set => _yas = Math.Clamp(value, 15, 50); }
        public override int vurusgucu { get => _vurusgucu; protected set => _vurusgucu = Math.Clamp(value, 1, 7); }
        public override int can { get => _can; protected set => _can = Math.Clamp(value, 30, 100); }

        public string tur2 => "Efendi ve Belalı"; public int ekstravurus => 3;
        public void nezaketGoster()
        {
            Console.WriteLine("Nezaket Gösterildi!");
            mutluluk += 10;
        }

        public void yardimEt()
        {
            Console.WriteLine("Yardım Edildi!");
            mutluluk += 5;
        }

        public void ozelVurus()
        {
            Console.WriteLine("Özel Vuruş Gerçekleştirildi!");
        }

        public void kufurEt()
        {
            Console.WriteLine("Küfür Edildi!");
        }


        public Restoran()
        {
            yas = rng.Next(15, 51);
            vurusgucu = rng.Next(1, 8);
            can = rng.Next(30, 101);
        }

        public override void konus()
        {
            Console.WriteLine("konuşuyor.");
        }

        public override void hareketEt()
        {
            Console.WriteLine("hareket ediyor.");
        }

        public override void kac()
        {
            Console.WriteLine("kaçıyor.");
        }

        public override bool ol()
        {
            oldumu = true;
            mutluluk = 0;
            Console.WriteLine("normal şekilde öldü.");
            return oldumu;
        }
    }

    public class Name
    {
        private static readonly Random rng;
        private static List<string> isimler;

        private int a;
        private int b;

        private ErkekIsimleriGrup1 erkek1;
        private ErkekIsimleriGrup2 erkek2;

        private KadinIsimleriGrup1 kadin1;
        private KadinIsimleriGrup2 kadin2;

        private Soyisimler soyisim;

        static Name()
        {
            rng = new Random();
            isimler = new List<string>();
        }

        public Name()
        {
            // a erkek cinsiyeti ihtimalidir, b ise tek veya çift isim olma ihtimalidir
            a = rng.Next(0, 2); b = rng.Next(0, 2);
        }
        public string GetRandomName()
        {
            while (true)
            {
                if (b == 0)
                {
                    if (a == 0)
                    {
                        erkek1 = (ErkekIsimleriGrup1)rng.Next(Enum.GetNames(typeof(ErkekIsimleriGrup1)).Length);
                        soyisim = (Soyisimler)rng.Next(Enum.GetNames(typeof(Soyisimler)).Length);
                        return isimkontrol($"{erkek1.ToString()} {soyisim}");
                    }
                    else if (a == 1)
                    {
                        kadin1 = (KadinIsimleriGrup1)rng.Next(Enum.GetNames(typeof(KadinIsimleriGrup1)).Length);
                        soyisim = (Soyisimler)rng.Next(Enum.GetNames(typeof(Soyisimler)).Length);
                        return isimkontrol($"{kadin1.ToString()} {soyisim}");
                    }
                }

                else if (b == 1)
                {
                    if (a == 0)
                    {
                        erkek1 = (ErkekIsimleriGrup1)rng.Next(Enum.GetNames(typeof(ErkekIsimleriGrup1)).Length);
                        erkek2 = (ErkekIsimleriGrup2)rng.Next(Enum.GetNames(typeof(ErkekIsimleriGrup2)).Length);
                        soyisim = (Soyisimler)rng.Next(Enum.GetNames(typeof(Soyisimler)).Length);
                        return isimkontrol($"{erkek1} {erkek2} {soyisim}");
                    }
                    else if (a == 1)
                    {
                        kadin1 = (KadinIsimleriGrup1)rng.Next(Enum.GetNames(typeof(KadinIsimleriGrup1)).Length);
                        kadin2 = (KadinIsimleriGrup2)rng.Next(Enum.GetNames(typeof(KadinIsimleriGrup2)).Length);
                        soyisim = (Soyisimler)rng.Next(Enum.GetNames(typeof(Soyisimler)).Length);
                        return isimkontrol($"{kadin1} {kadin2} {soyisim}");
                    }
                }

                break;
            }

            return "Isim Bulunamadi";
        }

        private string isimkontrol(string isim)
        {
            while (true)
            {
                if (isimler.Contains(isim)) { continue; }
                isimler.Add(isim);
                return isim;
            }
        }
    }

    public enum ErkekIsimleriGrup1
    {
        Ahmet,
        Mehmet,
        Mustafa,
        Ali,
        Hasan,
        Huseyin,
        Ibrahim,
        Yusuf,
        Omer,
        Murat,
        Emre,
        Burak,
        Serkan,
        Onur,
        Kaan,
        Tolga,
        Kerem,
        Baris,
        Sinan,
        Volkan,
        Cenk,
        Furkan,
        Can,
        Batuhan,
        Enes
    }

    public enum ErkekIsimleriGrup2
    {
        Deniz,
        Berk,
        Ugur,
        Eren,
        Hakan,
        Tuncay,
        Yasin,
        Selim,
        Cem,
        Ilker,
        Alper,
        Arda,
        Koray,
        Ozan,
        Poyraz,
        Sarp,
        Taylan,
        Kivanc,
        Levent,
        Aydin,
        Serhat,
        Gokhan,
        Orhan,
        Yigit,
        Kadir
    }

    public enum KadinIsimleriGrup1
    {
        Ayse,
        Fatma,
        Emine,
        Hatice,
        Zeynep,
        Elif,
        Merve,
        Busra,
        Esra,
        Sibel,
        Hande,
        Seda,
        Derya,
        Gizem,
        Cansu,
        Asli,
        Melike,
        Ebru,
        Ozlem,
        Pelin,
        Tugba,
        Aylin,
        Selin,
        Yasemin,
        Irem
    }

    public enum KadinIsimleriGrup2
    {
        Nazli,
        Nisa,
        Rabia,
        Hilal,
        Nurgul,
        Sevgi,
        Songul,
        Pinar,
        Banu,
        Burcu,
        Ceren,
        Ece,
        Damla,
        Beyza,
        Didem,
        Hacer,
        Dilek,
        Gonca,
        Sema,
        Gulsah,
        Nilay,
        Rukiye,
        Sevil,
        Yelda,
        Zehra
    }

    public enum Soyisimler
    {
        Yilmaz,
        Kaya,
        Demir,
        Celik,
        Sahin,
        Yildiz,
        Yucel,
        Aydin,
        Arslan,
        Koc,
        Kurt,
        Ozdemir,
        Polat,
        Aslan,
        Karaca,
        Dogan,
        Can,
        Eren,
        Tekin,
        Guler,
        Sari,
        Aksoy,
        Bozkurt,
        Cakir,
        Kaplan,
        Korkmaz,
        Ozkan,
        Turan,
        Gokturk,
        Karadag,
        Yavuz,
        Gungor,
        Altintas,
        Toprak,
        Keskin,
        Uysal,
        Sezer,
        Ergun,
        Kocak,
        Ates,
        Bayram,
        Avci,
        Gunes,
        Ozturk,
        Tas,
        Bulut,
        Saglam,
        Kalkan,
        Ulusoy,
        Duman,
        Acar,
        Unal,
        Ersoy,
        Sancak,
        Cetin,
        Isik,
        Altun,
        Akdag,
        Ceylan
    }
}
