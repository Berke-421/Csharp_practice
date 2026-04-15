using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_34
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    class yardımcı
    {
        private static byte _can;
        public static byte can
        {
            get => _can;

            set
            {
                if (value > 0 && value < 50)
                    _can = value;
                else if (value >= 50)
                    _can = 50;
                else if (value <= 0)
                    _can = 0;
            }
        }
        private static string? ad;

        public static Type_A Tip;

        private short _VurusGucu;
        public short VurusGucu
        {
            get => _VurusGucu;

            set => _VurusGucu = (value > 0 && value < 20) ? value : throw new Exception(" Hata ");
        }

        static yardımcı()
        {
            can = 50;
            ad = "Jester";
            Tip = Type_A.serseri;
        }

        public yardımcı()
        {
            VurusGucu = 100;
        }

        public short Vur(short guc)
        {
            return guc;
        }

        public short VurusGucuEkle(short guc)
        {
            if (guc > 40) throw new Exception(" Hata ");

            else _VurusGucu += guc;

            return _VurusGucu;
        }
    }

    class MantarAdam
    {
        private static byte _can;
        public static byte can
        {
            get => _can;

            set => _can = (value >= 0 && value <= 100) ? value : throw new Exception(" Hata ");
        }

        public static Type_A Tip { get; set; }
    }

    enum Type_A
    {
        serseri,
        okcu,
        büyücü,
        madenci
    }
}
