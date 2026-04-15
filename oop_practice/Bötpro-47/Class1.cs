using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_47
{
    class Class1
    {
        static void Main(string[] args)
        {
            Hayvan nesne = new Hayvan();

            nesne.damage = 3432;
            nesne.SesÇıkar();

            //--------------------------------------

            Kedi berke = new Kedi();

            berke.damage = 213;
            berke.SesÇıkar();
        }
    }

    class Hayvan
    {
        public int damage;

        public void SesÇıkar()
        {
            Console.WriteLine("Hayvan sesi");
        }
    }

    class Kedi : Hayvan
    {
        // kalıtım ile özellikler buraya aktarılır

        // kalıtım ile metotlar buraya aktarılır
    }
}
