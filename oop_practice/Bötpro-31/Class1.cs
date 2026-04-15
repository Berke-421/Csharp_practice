using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_31
{
    public class PaydaHatası : Exception
    {
        public PaydaHatası(string mesaj) : base(mesaj)
        {

        }
    }
    class Class1
    {
        static void Main(string[] args)
        {
            Mat.Topla(3, 4);
        }
    }

    static class Mat
    {
        public static int Topla(int a, int b) { return a + b; }

        public static int Cıkar(int a, int b) { return a - b; }

        public static int carp(int a, int b) { return a * b; }

        public static double bol(int a, int b)
        {
            try
            {
                if (b == 0)
                {
                    throw new PaydaHatası("Payda sıfır olamaz");
                }

                else return a / b;
            }

            catch(PaydaHatası ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return 0;
            }

        }
    }
}
