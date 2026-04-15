using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_35
{
    class Class1
    {
        static void Main(string[] args)
        {
            Tank nesne1 = new Tank(Type_.Japan) { konum = new Yon(1, 2) };

            Tank nesne2 = new Tank(Type_.Usa) { konum = new Yon(1, 1) };
            nesne2.can += 2;
            nesne2.konum.x = 12;

            Console.WriteLine(nesne1.TankAdı); // japon

            Console.WriteLine(nesne2.TankAdı); // amerika
        }
    }

    class Tank
    {
        public byte can { get; set; } // property (Özellik)

        private byte VurusGucu; // Field (Alan)

        private int _speed;
        public int speed
        {
            get => _speed;

            set => _speed = Math.Clamp(value, -12, 12);
        }

        public Type_ typee;

        private static byte sayac; // nesneye bağlı kalmadan direkt sınıfa bağlı olarak değişken hesaplar

        public string? TankAdı { get; private set; } // her nesne için kendi tankın adı olur

        public Yon konum; // struct veri tipi

        private static readonly Random rng = new Random(); // daha az maliyetli olsun diye static kullanılır bellek açısından daha az yer kaplar

        public static byte toplamTank { get; private set; }

        public Tank(Type_ type)
        {
            toplamTank++;

            this.typee = type;

            switch (type)
            {
                case Type_.Usa:

                    List<string> tankadı7 = new List<string>() { "Sherman", "stuart", "m121"};
                    int a = rng.Next(0, 3); // static olması sayesinde sadece bir kez çalışır sınıfa aittir nesneye ait değildir
                    TankAdı = tankadı7[a];

                    can = 75;
                    VurusGucu = 10;
                    speed = 2;
                    break;

                case Type_.Russia:

                    List<string> tankadı8 = new List<string>() { "T-34", "KV-1", "T-90" };
                    int a1 = rng.Next(0, 3);
                    TankAdı = tankadı8[a1];

                    can = 90;
                    VurusGucu = 12;
                    speed = 4;
                    break;

                case Type_.china:

                    List<string> tankadı9 = new List<string>() { "Type 59", "Type 99", "T-34" };
                    int a2 = rng.Next(0, 3);
                    TankAdı = tankadı9[a2];

                    can = 85;
                    VurusGucu = 9;
                    speed = 2;
                    break;

                case Type_.British:

                    List<string> tankadı1 = new List<string>() { "Churchill", "Cromwell", "Challenger 2" };
                    int a3 = rng.Next(0, 3);
                    TankAdı = tankadı1[a3];

                    can = 60;
                    VurusGucu = 10;
                    speed = 1;
                    break;

                case Type_.Germany:

                    List<string> tankadı2 = new List<string>() { "Panzer IV", "Tiger I", "Panther" };
                    int a4 = rng.Next(0, 3);
                    TankAdı = tankadı2[a4];
                    can = 100;

                    VurusGucu = 13;
                    speed = 3;
                    break;

                case Type_.France:

                    List<string> tankadı3 = new List<string>() { "dujevu", "renault-34", "ef-2" };
                    int a5 = rng.Next(0, 3);
                    TankAdı = tankadı3[a5];

                    can = 55;
                    VurusGucu = 7;
                    speed = 1;
                    break;

                case Type_.Japan:

                    List<string> tankadı4 = new List<string>() { "Chi-nu", "type 32", "chi-ri" };
                    int a6 = rng.Next(0, 3);
                    TankAdı = tankadı4[a6];

                    can = 45;
                    VurusGucu = 12;
                    speed = 3;
                    break;

                case Type_.Italy:

                    List<string> tankadı5 = new List<string>() { "cvr-435", "fiat-2000", "p-240" };
                    int a7 = rng.Next(0, 3);
                    TankAdı = tankadı5[a7];

                    can = 70;
                    VurusGucu = 6;
                    speed = 4;
                    break;
            }
        }

        static Tank()
        {
            Console.WriteLine("Static yapıcı metot çalıştı");
            toplamTank = 0;
        }

        public static void OyunuBaslat()
        {
            Console.WriteLine("Oyun başladı");        
            // haritayı oluşturacaklar kodlar buraya yazılır
        }

        public void Dog()
        {

        }

        public void AtesEt()
        {

        }
    }

    struct Yon
    {
        public byte x; // özellik
        public byte y;

        public Yon(byte X, byte Y) // yapıcı metot
        {
            x = X;
            y = Y;
        }

        public void Konum(dynamic A) // metot
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(A);
        }
    }
    enum Type_
    {
        Usa,
        Russia,
        china,
        British,
        Germany,
        France,
        Japan,
        Italy
    }
}
