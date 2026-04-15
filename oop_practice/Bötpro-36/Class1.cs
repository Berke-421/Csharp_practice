using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_36
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    class Ucak
    {
        private sbyte _can;
        private sbyte can
        {
            get => _can;

            set
            {
                if (value >= 0 && value <= 100) 
                    _can = value;

                else if (value < 0) 
                    _can = 0;

                else if (value > 100) 
                    _can = 100;
            }
        }

        private byte speed;

        public Model tip;

        public Position Yon; // duvara çarpmaması için get; set; kullanılması gerekir çünkü artık nasıl değer alacağı bir veri olur

        private byte darbe;

        public Ucak(Model model)
        {
            this.tip = model;

            switch (tip)
            {
                case Model.f35:
                    darbe = 5;
                    can = 80;
                    speed = 3;
                    break;

                case Model.f22:
                    darbe = 6;
                    can = 100;
                    speed = 2;
                    break;

                case Model.su57:
                    darbe = 5;
                    can = 85;
                    speed = 2;
                    break;

                case Model.j20:
                    darbe = 6;
                    can = 90;
                    speed = 2;
                    break;

                case Model.j35:
                    darbe = 4;
                    can = 80;
                    speed = 3;
                    break;

                default:
                    break;
            }
        }

        public sbyte DarbeAl(sbyte darbe)
        {
            can -= darbe;
            return can;
        }

        public sbyte CanKazan(sbyte Can)
        {
            can += 10;
            return can;
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

        public void KonumGoster()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Uçak");
        }
    }
    enum Model
    {
        f35,
        f22,
        su57,
        j20,
        j35,
    }
}
