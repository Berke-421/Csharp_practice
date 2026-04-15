using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_42
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    static class Aeternium
    {
        public static string? UlkeAdı { get; private set; }
        public static sbyte metro { get; private set; }
        public static int gdp { get; private set; }

        private static byte _fabrika;
        public static byte fabrika
        {
            get => _fabrika;

            private set
            {
                if (value > 0)
                    _fabrika = value;
                else
                    fabrika = 0;
            }
        }

        public static short gemi { get; private set; }

        public static short nufus { get; private set; }

        static Aeternium()
        {
            // kayıt dosyaları bağlantı kurur...
            _fabrika = 12;
            gemi = 150;
            gdp = 1750;
            metro = 5;
            nufus = 5760;
        }

        public static void Baslat()
        {

        }

        public static int EkonomiGuclen()
        {
            return gdp++;
        }

        public static int EkonomiZayıfla()
        {
            return gdp--;
        }
    }

    struct Konum
    {

    }
}
