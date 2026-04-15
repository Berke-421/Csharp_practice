using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_29
{
    class Class1
    {
        static void Main(string[] args)
        {
            User adam = new User("Berke");
        }
    }

    class User
    {

        private string? _KullaniciAdi; // özellik
        public string? KullaniciAdi // özellik
        {
            get => _KullaniciAdi;

            set => _KullaniciAdi = (string.IsNullOrEmpty(value) || value.Length < 1)
                ? value 
                : 
                throw new Exception("");
        }

        public Avatar Profil; // özellik

        private static byte sayac; // özellik

        static User()
        {
            sayac = 0;
            Console.WriteLine("sohbet odasıyla verileri bağlantıları yapacak olan kodlar");
            // sohbet odasıyla verileri bağlantıları yapacak olan kodlar
        }

        public User(string ad)
        {
            _KullaniciAdi = ad;
            sayac++;
            Console.WriteLine($"{_KullaniciAdi} katıldı");
        }

        public string Mesaj() // metot
        {
            return "";
        }

        public bool OyVer() // metot
        {
            return true;
        }

        public bool YokSay() // metot
        {
            return true;
        }

        ~User()
        {
            // Bilgiler kaldırılır
        }
    }

    enum Avatar : byte
    {
        Ar,
        Br,
        Cr,
        Dr,
        Er,
        Fr,
        Gr,
        Hr,
        Ir
    }
}
