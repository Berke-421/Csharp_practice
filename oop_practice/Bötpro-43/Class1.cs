using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_43
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    class Tank
    {
        private string? _Nick;
        public string? Nick
        {
            get => _Nick;

            private set
            {
                _Nick = string.IsNullOrEmpty(value) ? throw new Exception(" Hata ") : value;
            }
        }

        public int max_healt { get; private set; }

        private int _healt;
        public int healt
        {
            get => _healt;

            private set
            {
                _healt = Math.Clamp(value, 0, max_healt);
            }
        }

        public short hasar { get; private set; }

        public short level { get; private set; }

        private int _score;
        public int score
        {
            get => _score;

            set => _score = Math.Clamp(value, 0, 1000000);
        }

        public byte speed { get; private set; } // dışarıdan başka sınıflar okusun diye yazılır bu get ve set.

        public static byte count { get; private set; } // içeriden değişir dışarıdan okunur.

        private static Random rng = new Random();

        public Team team { get; private set; }

        public Position p;

        public bullet_position bp;

        static Tank()
        {
            // oyuna bağlanılacak kodlar
        }

        public Tank()
        {
            count++;

            team = (Team)(rng.Next(0, 5)); level = 0; score = 0;

            hasar = 10; max_healt = 100; healt = 100; // clamp çalışacak

            p = new Position(); bp = new bullet_position();
        }

        public int TakeDamage()
        {
            return healt--;
        }

        public int TakeHealt()
        {
            return healt++;
        }
    }

    struct bullet_position
    {
        
    }

    struct Position
    {

    }
    enum Team
    {
        blue,
        red,
        green,
        purple
    }
}

// İstisna: can veri tiipi short yerine int denilmek zorunda kalınıldı. Burada veri kaplama biraz genişletildi.
