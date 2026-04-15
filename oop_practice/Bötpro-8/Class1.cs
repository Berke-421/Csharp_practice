using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_8
{
    class Class1
    {
        static void Main()
        {
            while (true)
            {
                Hesap berke = new Hesap();

                Console.Write("ilk sayıyı giriniz: ");
                berke.a = Convert.ToInt32(Console.ReadLine());

                if (berke.a == 00) break;

                Console.WriteLine();

                Console.Write("İkinci sayıyı giriniz:");
                berke.b = Convert.ToInt32(Console.ReadLine());

                if (berke.b == 00) break;

                Console.WriteLine("Hangi işlemi yapacaksınız:");
                Console.WriteLine("+ tuşu: Toplama");
                Console.WriteLine("- tuşu: çıkarma");
                Console.WriteLine("* tuşu: çarpma");
                Console.WriteLine("/ tuşu bölme");

                char tercih = Convert.ToChar(Console.ReadLine());

                switch (tercih)
                {
                    case '+':                      
                        Console.WriteLine($"Cevap: {berke.topla()}");
                        break;

                    case '-':                      
                        Console.WriteLine($"Cevap: {berke.cikar()}");
                        break;

                    case '*':                     
                        Console.WriteLine($"Cevap: {berke.carp()}");
                        break;

                    case '/':
                        Console.WriteLine($"Cevap: {berke.bol()}");
                        break;

                    default:
                        Console.WriteLine("Tercih girilmedi");
                        break;
                }

                
            }
        }
    }

    class Hesap
    {
        public int a;
        public int b;

        public int topla()
        {
            return a + b;
        }

        public int cikar()
        {
            return a - b;
        }

        public int carp()
        {
            return a * b;
        }

        public double bol()
        {
            return (double)a/ b;
        }
    }
}
