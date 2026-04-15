using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_70
{
    internal class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    public interface Iserseri
    {
        void kufurEt() { Console.WriteLine("********"); } // küfür etme yeteneği
        void Dov(); // dövüşme yeteneği
        void hirsizlikYap(); // hırsızlık yapma yeteneği

        string? serserininAdi { get; } // yalnızca okunabilir ancak implementasyonda set edilebilir
    }

    public interface IMath
    {
        int topla(int a, int b); // içine iki sayı alır ve toplar bu mümkündür interfacede
        int cikar(int a, int b);
        int carp(int a, int b);
        int bol(int a, int b);

        string? operation { get; } // yalnızca okunabilir ancak implementasyonda set edilebilir
        // yapılacak operasyon adını tutar
    }

    public class Profesor : IMath
    {
        // profesör serserilik yapmaz bu yüzden Iserseri interfaceni implemente etmiyoruz
        // implementasyonları yapıyoruz çünkü interfacede default implementation yok
        public int topla(int a, int b)
        {
            return a + b;
        }

        public int cikar(int a, int b)
        {
            return a - b;
        }

        public int carp(int a, int b)
        {
            return a * b;
        }

        public int bol(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Bölen sıfır olamaz.");
            }

            return a / b;
        }

        public string? operation { get; protected set; }

        // bu özellikleri ekledikten sonra profesöre istediğimiz metotoları ve özellikleri ekleyebiliriz. işte interface budur
        // interface sayesinde profesör sınıfı matematiksel işlemler yapabilir hale geldi
        // serserilik ile alakalı interface de var ama bunu profesöre eklemiyoruz çünkü profesör serserilik yapmaz
        // bu durum bize interface'nin mantığını gösterir çünkü interface sayesinde sadece gerekli yetenekleri sınıfa ekleyebiliyoruz
        // tıpkı araba modifiye etmek gibi. sadece gerekli uygun görülen parçaları ekliyorsun
        // illa her seferinde interface kullanmak zorunda değilsin nerede uygun görürsen hazırla ve kullan
    }
}
