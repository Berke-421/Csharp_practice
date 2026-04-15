using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_48
{
    class Class1
    {
        static void Main(string[] args)
        {
            Araba berke = new Araba();

            berke.isim = "kara";
            berke.Hızlan();

            //---------------------------

            Toyata bicer = new Toyata();

            bicer.isim = "ADAM";
            bicer.Hızlan();

            //----------------------------

            BMW naber = new BMW();

            naber.isim = "saıojd";
            naber.Hızlan();
        }
    }

    class Araba
    {
        public string? isim;
        
        public void Hızlan()
        {

        }
    }

    class Toyata : Araba
    {
        // kalıtım ile özellikler buraya aktarılır

        // kalıtım ile buraya metotlar aktarılır
    }

    class BMW : Araba
    {
        // kalıtım ile özelliker buraya aktarılır

        // kalıtım ile buraya metotlar aktarılır
    }
}
