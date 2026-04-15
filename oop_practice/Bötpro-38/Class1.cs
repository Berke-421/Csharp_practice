using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_38
{
    class Class1
    {
        static void Main(string[] args)
        {
            Araba_NPC n1 = new Araba_NPC();
            Console.WriteLine($"renk: {n1.renk}, hız: {n1.max_hız}");

            Araba a1 = new Araba(Marka.audi, Color.siyah);
            Araba a2 = new Araba(Marka.nissan, Color.mavi);
            Araba a3 = new Araba(Marka.volvo, Color.kırmızı);

        }
    }

    class Araba_NPC
    {
        private short _puan;
        public short puan
        {
            get => _puan;

            private set
            {
                if (value <= 0)
                    _puan = 0;

                else if (value > 0)
                    _puan = value;
            }
        }

        private short _speed;
        public short speed
        {
            get => _speed;

            private set
            {
                if (value <= 0)
                    _speed = 0;

                else if (value > max_hız)
                    _speed = max_hız;

                else
                    _speed = value;
            }
        }

        public Color renk { get; private set; }

        private Position yon;
        public static byte sayac { get; private set; }

        private static Random rng = new Random();

        private List<short> oto_hiz = new List<short>() {90, 120, 150, 170, 220};

        public short max_hız { get; private set; }

        private short a;
        private short b;
        public Araba_NPC()
        {
            a = (short)(rng.Next(0, 5));
            max_hız = oto_hiz[a];

            b = (short)(rng.Next(0, 13));
            renk = (Color)b;

            speed = 0;
        }

        public void Gaza(short miktar)
        {
            speed += miktar;
        }

        public void Fren(short miktar)
        {
            speed -= miktar;
        }
    }

    struct Position
    {
        public int x;
        public int y;

        public Position(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public void location()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Nesne");
        }
    }

    enum Color
    {
        kırmızı, sarı, yeşil, mavi, pembe,
        turuncu, siyah, beyaz, gri, mor,
        lacivert, kahverengi, turkuaz, krem
    }

    class Araba
    {
        public Marka m { get; private set; }
        public Color renk { get; private set; }

        public Araba(Marka a = Marka.unkown, Color b = Color.beyaz)
        {
            this.m = a;
            this.renk = b;
        }
    }

    enum Marka
    {
        audi, nissan, volvo, unkown
    }

}

