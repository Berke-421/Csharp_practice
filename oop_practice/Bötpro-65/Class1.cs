using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_65
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            Novel berke = new Novel();
            Console.WriteLine(berke.productivity);
            berke.productivityUP();
            Console.WriteLine(berke.productivity);
            Console.WriteLine(berke.Mscore);
        }
    }

    abstract class Book
    {
        public abstract int Page { get; protected set; } // her kitabın sayfası farklı olabilir
        public abstract int energy { get; protected set; } // her kitabın enerji gereksinimi farklı olabilir
        public abstract int focus { get; protected set; } // her kitabın odaklanma gereksinimi farklı olabilir
        public abstract string name { get; protected set; } // her kitabın adı farklı olabilir
        public abstract string type { get; } // her kitabın türü farklı olabilir
        public abstract int tka { get; } // her kitabın türüne göre tka değeri farklı olabilir


        private int _productivity; // ortak özellik çünkü her kitap için üretkenlik önemli ve aynı aralıkta tutulacak
        public int productivity // ortak özellik
        {
            get => _productivity; // herkes için okunabilir

            private set => _productivity = Math.Clamp(value, 0, 100); // herkes için 0-100 aralığında tutulacak
        }

        private int _Mscore; // her kitap için ortak özellik çünkü herkes için skor önemli ve aynı aralıkta tutulacak
        public int Mscore // her sınıfta vardır bu özellik ve herkes için okunabilir ama sadece ana sınıf içinden değiştirilebilir
        {
            get => _Mscore;

            private set => _Mscore = Math.Clamp(value, 0, 999999); // herkes için 0-999999 aralığında tutulacak
        }

        private static int _count;
        public static int count // kaç tane kitap nesnesi oluşturulduğunu tutar
        {
            get => _count;

            private set => _count = Math.Clamp(value, 0, 1000);
        }

        protected static Random rng; // tüm sınıfın kullanacağı ortak araç 

        static Book() // static yapıcı tüm türev sınıflar için bir kez çağrılır
        {
            count = 0; // kitap sayacı başlangıç değeri
            rng = new Random(); // rastgele sayı üreteci oluşturulur
        }

        public Book() // her türev sınıf için çağrılır
        {
            count++; // her yeni nesne oluşturulduğunda sayacı artır
            Mscore = 0; // başlangıç skoru
            productivity = 0; // başlangıç üretkenlik değeri
        }

        public static void start() { } // süreci başlatır

        public int scoreUP() // skoru artırır her sınıf için ortak araç
        {
            Mscore++;
            return Mscore;
        }

        public int productivityUP() // üretkenliği artırır her sınıf için aynı işleve sahip ortak metot
        {
            productivity++; // üretkenliği 1 artır
            return productivity; // yeni üretkenlik değerini döndür
        }

        public void startreading() // her türev sınıf için ortak araç
        {

        }

        public abstract void read(); // her türev sınıf için farklı implementasyon gerektirir çünkü okuma şekli farklı olabilir
        public abstract void think(); // her türev sınıf için farklı implementasyon gerektirir çünkü düşünme şekli farklı olabilir
        public abstract void learn(); // her türev sınıf için farklı implementasyon gerektirir çünkü öğrenme şekli farklı olabilir
    }

    class Novel : Book // türev sınıf roman 
    {
        private int _page; // türevin kendi belleği
        private int _focus;
        private int _energy;
        private string _name = null!; // null ataması yapılmayacak ancak derleyici uyarısı vermemesi için gerekli
        public override int Page { get => _page; protected set => _page = Math.Clamp(value, 150, 2000); }
        public override int energy { get => _energy; protected set => _energy = Math.Clamp(value, 5, 25); }
        public override int focus { get => _focus; protected set => _focus = Math.Clamp(value, 10, 30); }
        public override string name { get => _name; protected set => _name = value.Length <= 15 ? value : value.Substring(0, 15); }

        public override string type => "Novel";
        public override int tka => 10;

        public Novel(string name = "")
        {
            this.name = name;
            // random ile özelliklere rastgele değer ataması yapılır her türev sınıf için ortak araçtır random rng;
        }

        public override void read()
        {
            throw new NotImplementedException();
        }

        public override void think()
        {
            throw new NotImplementedException();
        }

        public override void learn()
        {
            throw new NotImplementedException();
        }
    }
}

