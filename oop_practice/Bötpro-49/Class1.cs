using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_49
{
    class Class1
    {
        static void Main(string[] args)
        {
            Tank a = new Tank();
            Console.WriteLine(a.damage);
            a.Shot();

            //---------------------------------

            Dusman berke = new Dusman();
            Console.WriteLine(berke.damage);
            berke.Shot();
        }
    }

    class Tank // base sınıf yani ana sınıf 
    {
        public int damage { get; protected set; } // Dışarıdan başka sınıflarda okunabilir ama sadece ana sınıf ve türetilmiş sınıflarda değiştirilebilir

        public void Shot() { }

        public Tank()
        {
            this.damage = 1;
        }
    }

    class Dusman : Tank // türetilmiş sınıf
    {
        // kalıtım ile özellikler buraya aktarıldı

        // kalıtım ile metotlar buraya aktarıldı

        public Dusman()
        {
            this.damage = 2;
        }

    }
}
