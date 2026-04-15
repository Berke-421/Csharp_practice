using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_75
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            Func<string, int> say = kelime => kelime.Length;
        }
    }

    public interface ICanli
    {
        string tur { get; }
        void nefesAl();
    }

    public abstract class Gezegen
    {
        public abstract string? tur { get; } // yalnızca okunabilir tür
        public abstract double? radius { get; protected set; } // yarıçap sadece türev sınıflarda set edilebilir
        public abstract int yercekimi { get; protected set; } // yerçekimi sadece türev sınıflarda set edilebilir
        public abstract double? sicaklik { get; protected set; } // sıcaklık sadece türev sınıflarda set edilebilir
        public abstract int uyduSayisi { get; protected set; } // uydu sayısı sadece türev sınıflarda set edilebilir

        private int _level;
        public int level
        {
            get => _level;
            set => _level = Math.Clamp(value, 1, 9999); // level değeri 1 ile 10 arasında olmalı
        }

        private bool _yasamVarMi;
        public bool yasamVarMi { get=> _yasamVarMi; set => _yasamVarMi = value; }

        private static int _sayac;
        public static int sayac { get => _sayac; set => _sayac = Math.Clamp(value, 0, 15); }
        protected static readonly Random rng;

        static Gezegen()
        {
            _sayac = 0;
            rng = new Random();
        }

        public Gezegen()
        {
            _level = 1;
            _yasamVarMi = false;
            _sayac++;
        }

        public static void baslat()
        {

        }

        public static void bitir()
        {

        }

        public void yokol()
        {
            sayac--;
            level = 0;
            yasamVarMi = false;
        }

        public abstract void bilgileriGoster();
        public abstract void don();
        public abstract void dogalafet();
        public abstract void yasamVarMiKontrol();
    }

    public class GazGezegeni : Gezegen
    {
        public override string? tur => "Gaz gezegeni";

        private double _radius; private int _yercekimi; private double _sicaklik; private int _uyduSayisi;
        public override double? radius { get => _radius; protected set => _radius = Math.Clamp((double)value!, 0, 100); }
        public override int yercekimi { get => _yercekimi; protected set => _yercekimi = Math.Clamp(value, 100, 400); }
        public override double? sicaklik { get => _sicaklik; protected set => _sicaklik = Math.Clamp((double)value!, -200, 200); }
        public override int uyduSayisi { get => _uyduSayisi; protected set => _uyduSayisi = Math.Clamp(value, 0, 70); }

        public GazGezegeni()
        {
            radius = rng.NextDouble() * (100 - 0) + 0;
            yercekimi = rng.Next(100, 400);
            sicaklik = rng.NextDouble() * (200 - (-200)) + (-200);
            uyduSayisi = rng.Next(0, 70); 
            sicaklik = rng.Next(-200, 200);
        }

        override public void bilgileriGoster()
        {
            Console.WriteLine($"Tür: {tur}\nYarıçap: {radius} km\nYerçekimi: {yercekimi} m/s²\nSıcaklık: {sicaklik} °C\nUydu Sayısı: {uyduSayisi}\nYaşam Var Mı: {yasamVarMi}\nLevel: {level}\n");
        }

        override public void don()
        {
            Console.WriteLine($"{tur} dönüyor...");
        }

        override public void dogalafet()
        {
            Console.WriteLine($"{tur} üzerinde dev fırtınalar kopuyor!");
        }

        public override void yasamVarMiKontrol()
        {
            throw new NotImplementedException();
        }
    }
}