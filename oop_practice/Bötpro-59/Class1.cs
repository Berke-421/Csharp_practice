using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_59
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class Sirket
    {
        private static int _count;
        public static int count
        {
            get => _count;

            private set => _count = Math.Clamp(value, 0, 100);
        }

        private static Random rng;

        private int levelmatik = 100;
        public Ulke bolge { get; protected set; }

        public abstract int para { get; protected set; }
        public abstract int calisan { get; protected set; }
        public abstract string? ad { get; protected set; }

        private int _level;
        public int level
        {
            get => _level;

            private set => _level = Math.Clamp(value, 0, 999);
        }

        private int _levelsinir;
        public int levelsinir
        {
            get => _levelsinir;

            private set => _levelsinir = Math.Clamp(value, 0, _level * levelmatik);
        }

        private int _skor;
        public int skor
        {
            get => _skor;

            private set => _skor = Math.Clamp(value, 0, 99999999);
        }
        public bool iflasettimi { get; protected set; }

        static Sirket()
        {
            rng = new Random();
            count = 0;
        }

        public Sirket()
        {
            level = 1;
            skor = 0;
            count++;
        }

        public void levelup()
        {
            level++;
            levelmatik += 50; 
        }

        public abstract void satinal();
        public abstract void İflaset();
        public abstract void HalkaArz();
        public abstract void Parakazan();
        public abstract void IsciAlVeyaKov();

    }

    class Teknokloji : Sirket
    {
        private string? _ad;
        private int _calisan;
        private int _para;
        public override string? ad { get => _ad; protected set => _ad = value; }
        public override int calisan { get => _calisan; protected set => _calisan = Math.Clamp(value, 0, 500000); }
        public override int para { get => _para; protected set => _para = Math.Clamp(value, 0, 70000); }

        public Teknokloji(string? AD)
        {
            this.ad = AD;
            calisan = 10;
            para = 100;
        }

        public override void satinal()
        {
            throw new NotImplementedException();
        }

        public override void İflaset()
        {
            throw new NotImplementedException();
        }

        public override void HalkaArz()
        {
            throw new NotImplementedException();
        }

        public override void Parakazan()
        {
            throw new NotImplementedException();
        }

        public override void IsciAlVeyaKov()
        {
            throw new NotImplementedException();
        }
    }

    class Enerji : Sirket
    {
        private string? _ad;
        private int _calisan;
        private int _para;
        public override string? ad { get => _ad; protected set => _ad = value; }
        public override int calisan { get => _calisan; protected set => _calisan = Math.Clamp(value, 0, 200000); }
        public override int para { get => _para; protected set => _para = Math.Clamp(value, 0, 90000); }

        public Enerji(string? AD)
        {
            this.ad = AD;
            calisan = 200;
            para = 9000;
        }

        public override void satinal()
        {
            throw new NotImplementedException();
        }

        public override void İflaset()
        {
            throw new NotImplementedException();
        }

        public override void HalkaArz()
        {
            throw new NotImplementedException();
        }

        public override void Parakazan()
        {
            throw new NotImplementedException();
        }

        public override void IsciAlVeyaKov()
        {
            throw new NotImplementedException();
        }
    }

    enum Ulke
    {
        Türkiye, Amerika, Almanya, Kanada, Fransa, Rusya, Birleşik_krallık, Azerbaycan, İran, Çin, Japonya, Güney_kore, Hindistan, İtalya, İspanya, İsveç,
        Yunanistan, Suudi_Arabistan, Mısır, Portekiz, Arjantin,

        Brezilya, Meksika, Şili, Peru, Kolombiya, Venezuela, Uruguay, Paraguay,
        Avustralya, Yeni_Zelanda,
        Norveç, Danimarka, Finlandiya, Hollanda, Belçika, Avusturya, İsviçre, Polonya, Çekya, Slovakya, Macaristan,
        Romanya, Bulgaristan, Sırbistan, Hırvatistan, Slovenya, Bosna_Hersek, Karadağ, Arnavutluk, Kosova,
        Gürcistan, Ermenistan, Kazakistan, Kırgızistan, Türkmenistan, Özbekistan, Tacikistan,
        Pakistan, Bangladeş, Nepal, Sri_Lanka, Endonezya, Malezya, Singapur, Tayland, Vietnam, Filipinler,
        Güney_Afrika, Nijerya, Kenya, Etiyopya, Fas, Tunus, Cezayir,
        Katar, Birleşik_Arab_Emirlikleri, Kuveyt, Bahreyn, Umman,
        İsrail, Ürdün, Lübnan
    }
}
