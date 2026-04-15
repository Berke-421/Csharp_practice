using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_63
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class Villager
    {
        public abstract int gold { get; protected set; } // her köylünün altın miktarı farklı olabilir
        public abstract int health { get; protected set; } // her köylünün sağlık puanı farklı olabilir
        public abstract int hit { get; protected set; } // her köylünün vurma gücü farklı olabilir


        private static int _count; // bütün köylülerin sayısı
        public static int count
        {
            get => _count;

            private set => _count = Math.Clamp(value, 0, 35);
        }


        private int _level;
        public int level //bütün köylülerin seviyesi 1 ile 50 arasında olacak ve levelup metodu ile artırılacak
        {
            get => _level;

            private set => _level = Math.Clamp(value, 1, 50);
            // bu özellik türev sınıfta bulunur ama yalnızca ana sınıf tarafından set edilebilir
            // ve set edildiğinde zaten türev sınıfının level özelliği de etkilenir yani değişir
        }

        protected static Random rng; // türev sınıfların kullanacağı ortak rastgele sayı üreteci

        static Villager() // static yapıcı
        {
            count = 0; // başlangıçta köylü sayısı 0
            rng = new Random(); // rastgele sayı üreteci oluşturuluyor
        }

        public Villager()
        {
            level = 1; // başlangıçta seviye 1
            count++; // yeni bir köylü oluşturulduğunda sayıyı artır
        }

        public static void Start() { }

        public void levelup() { level++; } // bütün türev sınıflar için aynı metot hepsinde aynı işlev ile kalıtım alacak
        public void sleep() { } // bütün köylüler aynı şekilde uyuyacak

        public abstract void speak(); // her köylü farklı şekilde konuşabilir
        public abstract void attack(); // her köylü farklı şekilde saldırabilir
        public abstract void run(); // her köylü farklı şekilde kaçabilir
    }

    class Merchant : Villager // tüccar köylü sınıfı
    {
        private int _gold;
        private int _health;
        private int _hit;
        // tüccar köylüye özel sınırlamalar
        public override int gold { get => _gold; protected set => _gold = Math.Clamp(value, 0, 20000); }
        public override int health { get => _health; protected set => _health = Math.Clamp(value, 0, 100); }
        public override int hit { get => _hit; protected set => _hit = Math.Clamp(value, 2, 8); }

        public Merchant()
        {
            // tüccar köylü başlangıç değerleri
            gold = rng.Next(0, 10001);
            hit = rng.Next(2, 9);
            health = 100;
        }

        // tüccar köylünün kendi davranışları
        public override void speak()
        {
            throw new NotImplementedException();
        }

        public override void attack()
        {
            throw new NotImplementedException();
        }

        public override void run()
        {
            throw new NotImplementedException();
        }
    }

    class Warrior : Villager
    {
        private int _gold;
        private int _health;
        private int _hit;
        public override int gold { get => _gold; protected set => _gold = Math.Clamp(value, 0, 5000); }
        public override int health { get => _health; protected set => _health = Math.Clamp(value, 0, 200); }
        public override int hit { get => _hit; protected set => _hit = Math.Clamp(value, 8, 32); }

        public Warrior()
        {
            gold = rng.Next(0, 5001);
            hit = rng.Next(8, 33);
            health = 200;
        }

        public override void speak()
        {
            throw new NotImplementedException();
        }

        public override void attack()
        {
            throw new NotImplementedException();
        }

        public override void run()
        {
            throw new NotImplementedException();
        }
    }
}
