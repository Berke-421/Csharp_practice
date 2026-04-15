using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bötpro_25
{
    class Class1
    {
        static void Main(string[] args) 
        {
            Dikdortgen.genislik = 34;
            Dikdortgen.yukseklik = 46;

            int c = Dikdortgen.Alan();
            Console.WriteLine(c);

            int[] sayilar = { 23, 45, 12, 67, 34, 89, 11 };
            foreach(int i in sayilar) 
            {

            }

            List<string> ulkeler = new List<string>() { "Türkiye", "Almanya", "Fransa", "İtalya" };

            Dictionary<int, string> gdp = new Dictionary<int, string>();
            { gdp.Add(1, "Türkiye"); // burada Türkiye numarası 1 olarak atanır
                gdp.Add(2, "Almanya"); // almanya numarası 2 olarak atanır
                gdp.Add(3, "Fransa"); // fransa numarası 3 olarak atanır
                gdp.Add(4, "İtalya"); // italya numarası 4 olarak atanır
            }

            foreach(Dictionary<int, string> item in gdp)  // burada dictionary yapısı foreach ile gezilir.
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }
    }

    static class Dikdortgen
    {
        private static short _yukseklik; // sınıf içinde işlem yapılacak olan
        public static short yukseklik // sınıf dışında işlem yapılacak olan 
        {
            get => _yukseklik;

            set => _yukseklik = (value > 0) ? value : throw new ArgumentOutOfRangeException();
        }


        private static short _genislik;
        public static short genislik
        {
            get => _genislik;

            set => _genislik = (value > 0) ? value : throw new ArgumentOutOfRangeException();
        }

        public static int Alan()
        {
            return _yukseklik * _genislik;
        }

        public static int Cevre()
        {
            return 2 * (_yukseklik + _genislik);
        }
    }
}
