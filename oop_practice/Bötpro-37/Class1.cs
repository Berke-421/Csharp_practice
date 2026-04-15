using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_37
{
    class Class1
    {
        static void Main(string[] args)
        {
            Player berke = new Player();
        }
    }

    class Player
    {
        private short _puan;
        public short puan
        {
            get => _puan;

            private set => _puan = (value >= 0) ? value : (short)0; // sadece sınıf içinde metotlarla kontrol edilir // Dışarıdan sadece okunur, sınıf içinde değiştirilebilir.
        }

        private sbyte _can;
        public sbyte can
        {
            get => _can;

            set
            {
                if (value > 0 && value <= 10) 
                    _can = value;
                else if (value < 0) 
                    _can = 0;
                else if (value > 10) 
                    _can = 10;
            }
        }

        public Player()
        {
            Console.WriteLine("Oyuncu başladı");
            _can = 10;
            _puan = 0;
        }

        public void AtesEt(byte Guc)
        {

        }

        public sbyte DarbeAl(sbyte Guc)
        {
            _can -= Guc;
            return _can;
        }

        public short PuanKazan(short Miktar)
        {
            _puan += Miktar;
            return _puan;
        }
    }

    struct Position
    {
        public byte x;
        public byte y;

        public Position(byte X, byte Y)
        {
            x = X;
            y = Y;
        }

        public void Konum()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("*");
        }
    }
}
