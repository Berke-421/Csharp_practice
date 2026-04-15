using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_41
{
    class Class1
    {
        static void Main(string[] args)
        {
            Players_A n = new Players_A();

            n.konum.x = 5;
            n.konum.y = 5;

            ConsoleKeyInfo Key;

            while (true)
            {
                Key = Console.ReadKey(true);

                switch (Key.KeyChar)
                {
                    case 'w':
                        n.konum.y--;
                        n.mer.ey = n.konum.y;

                        Console.Clear();
                        break;

                    case 's':
                        n.konum.y++;
                        n.mer.ey = n.konum.y;

                        Console.Clear();
                        break;

                    case 'd':
                        n.konum.x++;
                        n.mer.ex = n.konum.x;

                        Console.Clear();
                        break;

                    case 'a':
                        n.konum.x--;
                        n.mer.ex = n.konum.x;

                        Console.Clear();
                        break;

                    case ' ':
                        n.mer.local_bullet();
                        break;

                    default:
                        break;
                }

                n.konum.Local();
            }
        }
    }

    class Players_A
    {
        private float _can;
        public float can
        {
            get => _can;

            set
            {
                if (value > 0 && value <= 5)
                    _can = value;

                else if (value <= 0)
                    _can = 0;

                else if (value > 5)
                    _can = 5;
            }
        }

        private short _money;
        public short money
        {
            get => _money;

            set
            {
                if (value >= 0)
                    _money = value;

                else
                    _money = 0;
            }
        }

        private sbyte Level;

        private static short team_success;

        private static sbyte count;

        private float Hasar;

        private static Random rng = new Random();

        public Position konum = new Position();

        public Bullet_position mer = new Bullet_position();

        private Color renk;

        static Players_A()
        {
            count = 0;
            team_success = 0;
        }

        public Players_A()
        {
            Hasar = 0.2f;

            renk = (Color)(rng.Next(0, 11));

            _can = 5;

            Level = 1;

            count++;
        }

        public void TakeDamage(sbyte counter)
        {
            _can -= counter;
        }

        public void Hit()
        {

        }
    }

    struct Position
    {
        public short x;
        public short y;

        public Position(short X, short Y)
        {
            x = Y;
            y = Y;
        }

        public void Local()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("Berke");
        }
    }

    struct Bullet_position
    {
        public short c;

        public short ex;
        public short ey;

        public short yedek_x;
        public short yedek_y;

        public void local_bullet()
        {
            Console.SetCursorPosition(ex - 1, ey - 1);
            Console.WriteLine("Merhaba");
        }
    }

    enum Color
    {
        red, blue, pink, green, yellow, brown, purple, white, black, gray, orange
    }
}
