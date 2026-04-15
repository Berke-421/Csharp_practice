using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_22
{
    public class YetersizBakiye : Exception
    {
        public YetersizBakiye(string mesaj) : base(mesaj)
        {

        }
    }
    class Class1
    {
        static void Main()
        {

        }
    }

    class Banka
    {
        public short No { get; set; }
        public int para { get; set; }
        public string? isim { get; set; }

        private static byte counter = 0;

        public Banka(short no = 00, int para = 00, string? isim = "Girilmedi")
        {
            this.No = no;
            this.isim = isim;
            this.para = para;

            counter++;
        }

        public int ParaEkle(int miktar)
        {
            para += miktar;
            return para;
        }

        public int ParaCikar(int miktar)
        {
            try
            {
                if (miktar > para) throw new YetersizBakiye("Hata: Yetersiz bakiye");

                else
                {
                    para -= miktar;
                    return para;
                }
            }

            catch(YetersizBakiye ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public void BilgiGoster()
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Kullanıcı adı: {isim}");
            Console.WriteLine($"Bakiye: {para}");
            Console.WriteLine($"Numara: {No}");
            Console.ResetColor();
        }

        public static void ToplamHesapSayisi()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Toplam banka hesabı: {counter}");
            Console.ResetColor();
        }
    }
}
