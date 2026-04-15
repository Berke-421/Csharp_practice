using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_67
{
    internal class Class1
    {
        static void Main(string[] args)
        {
        }
    }

    public abstract class Food
    {
        public abstract string name { get; } // yalnızca okunabilir ve yemeği belirler
        public abstract string? brand { get; } // yalnızca okunabilir ve yemeğin markasını belirler

        public abstract int price { get; protected set; } // yemeğin fiyatı. her yemeğin fiyatı farklı olabilir
        public abstract int taste { get; protected set; } // yemeğin lezzet puanı her yemeğin lezzeti farklı olabilir
        public abstract int expiry { get; protected set; } // yemeğin son kullanma tarihi (gün olarak) her yemeğin son kullanma tarihi farklı olabilir

        private int _consumed; // yemeğin tüketim yüzdesi
        public int consumed // yemeğin tüketim yüzdesinin özelliği
        {
            get => _consumed;
            private set => _consumed = Math.Clamp(value, 0, 100); // 0 ile 100 arasında sınırlama yüzdelik değer
        }

        private static int _count;
        public static int count // oluşturulan yemek sayısı
        {
            get => _count;
            private set => _count = Math.Clamp(value, 0, 1000); // 0 ile 1000 arasında sınırlama
        }

        protected static Random rng; // bütün sınıfın kullanacağı araç
        public static Dictionary<string, int> inventory { get; private set; } // yemeğin envanteri
        // anahtar: yemek adı, değer: miktar. örneğin: {"Elma", 5}, {"Ekmek", 10}
        // static çünkü tüm yemek nesneleri arasında paylaşılacak
        // set private çünkü sadece sınıf içinden değiştirilebilir
        // public çünkü dışarıdan okunabilir istiyoruz

        static Food()
        {
            rng = new Random(); // başlangıçta rastgele sayı üreteci oluştur
            count = 0; // yemek sayısını başlatır
            inventory = new Dictionary<string, int>(); // envanteri başlat
        }

        public Food()
        {
            count++;// her yeni yemek oluşturulduğunda sayacı artır
            consumed = 0; // başlangıçta tüketim yüzdesi sıfır çünkü yemek yeni alındı
        }

        public static void StartGame() { } // oyun başlangıcı için boş metot
        public static void PauseGame() { } // oyun duraklatma için boş metot
        public static void ResumeGame() { } // oyun devam ettirme için boş metot
        public static void ExitGame() { } // oyun sonu için boş metot

        public int consumeFood(int amount) // her yemeğin tüketim işlemi ortak olacak çünkü yemek tüketimi benzer
        {
            consumed += amount; // yemeğin tüketim yüzdesini artır
            return consumed; // güncellenmiş tüketim yüzdesini döndür
        }

        public abstract void spoilFood(); // yemeğin bozulma işlemi için soyut metot her yemeğin bozulma işlemi farklı olabilir
        public abstract int Eat(); // yemeğin yenme işlemi için soyut metot ve döndürülen değer her yemeğin lezzet puanı olabilir
        public abstract void sound(); // yemeğin ses çıkarma işlemi için soyut metot her yemeğin ses çıkarma işlemi farklı olabilir
    }

    public class Chocolate : Food
    {
        public override string name => "Chocolate"; // yalnızca okunabilir ve yemeği belirler

        private string? _brand;
        public override string? brand => _brand;

        // bunlar yemeğin özellikleri. private çünkü sadece bu sınıf içinde kullanılacaklar çünkü kendi içinde yönetilecekler
        private int _taste;
        private int _price; 
        private int _expiry;

        // fiyat 1 ile 120 arasında olmalı çünkü çikolata genellikle uygun fiyatlıdır
        public override int price { get => _price; protected set => _price = Math.Clamp(value, 1, 120); }

        // lezzet 300 ile 2000 arasında olmalı çünkü çikolata çok lezzetli
        public override int taste { get => _taste; protected set => _taste = Math.Clamp(value, 300, 2000); }

        // son kullanma tarihi 1 ile 400 gün arasında olmalı çünkü çikolata uzun ömürlüdür
        public override int expiry { get => _expiry; protected set => _expiry = Math.Clamp(value, 1, 400); } 

        public Chocolate()
        {
            price = rng.Next(1, 121); // rastgele fiyat belirle çünkü çikolata fiyatları değişken olabilir
            taste = rng.Next(300, 2001); // rastgele lezzet belirle lezzetleri farklı olabilir
            expiry = rng.Next(1, 401); // rastgele son kullanma tarihi herhangi tarih olabilir
            _brand = GetRandomBrand.GetRandomChocolate(); // rastgele marka ata
        }

        public override void spoilFood()
        {
            // Çikolatanın bozulma işlemi
        }

        public override int Eat()
        {
            // Çikolatanın yenme işlemi
            return taste;
        }

        public override void sound()
        {
            // Çikolatanın ses çıkarma işlemi
        }
    }

    public class Milk : Food
    {
        public override string name => "Milk"; // yalnızca okunabilir ve yemeği belirler
        private int _taste;
        private int _price;
        private int _expiry;

        // fiyat 200 ile 700 arasında olmalı çünkü süt genellikle orta fiyatlıdır
        public override int price { get => _price; protected set => _price = Math.Clamp(value, 200, 700); }

        // lezzet 100 ile 500 arasında olmalı çünkü süt hafif lezzetlidir
        public override int taste { get => _taste; protected set => _taste = Math.Clamp(value, 100, 500); }

        // son kullanma tarihi 1 ile 30 gün arasında olmalı çünkü süt çabuk bozulur
        public override int expiry { get => _expiry; protected set => _expiry = Math.Clamp(value, 1, 30); }

        public Milk()
        {
            price = rng.Next(200, 701); // rastgele fiyat belirle çünkü süt fiyatları değişken olabilir
            taste = rng.Next(100, 501); // rastgele lezzet belirle çünkü süt lezzetleri farklı olabilir
            expiry = rng.Next(1, 31); // rastgele son kullanma tarihi herhangi tarih olabilir
        }

        public override void spoilFood()
        {
            // Çikolatanın bozulma işlemi
        }

        public override int Eat()
        {
            // Çikolatanın yenme işlemi
            return taste;
        }

        public override void sound()
        {
            // Çikolatanın ses çıkarma işlemi
        }
    }

    public class GetRandomBrand
    {
        public static string? GetRandom() // geri döndürülen değer string olabilir null olabilir
        {
            Array values = Enum.GetValues<Milkbrand>(); // enum değerlerini al ve bir diziye ata
            object? value = values.GetValue(Random.Shared.Next(values.Length)); // rastgele bir değer seç
            return value?.ToString(); // deger null değilse stringe çevir ve döndür
            // milkbrand tipinde değişken oluştur ve eğer value milkbrand tipindeyse brand değişkenine ata
        }

        // aynı işlemi çikolata markası için yap
        public static string? GetRandomChocolate()
        {
            Array values = Enum.GetValues<Chocolatebrand>();
            object? value = values.GetValue(Random.Shared.Next(values.Length));
            return value?.ToString();
        }

        // aynı işemi pasta markası için yap
        public static string? GetRandomCake()
        {
            Array degerler = Enum.GetValues<cakeBrand>();
            object? deger = degerler.GetValue(Random.Shared.Next(degerler.Length));
            return deger?.ToString();
        }
    }

    public enum Milkbrand
    {
        Ulker, Pinar, Sutas, Dogus
    }

    public enum Chocolatebrand
    {
        Lindt, Godiva, Ferrero, Hersheys
    }

    public enum cakeBrand
    {
        Pastavilla, Divan, Mado, Tchibo
    }
}
