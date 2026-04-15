using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bötpro_57
{
    class Class1
    {
        static void Main(string[] args)
        {
            // 1.nesne
            Car berke = new Car("Subaru", "Impreza", 2007);

            // 2.nesne
            Car bicer = new Car("Renault", "Clio", 2014);

            // 3.nesne
            Car Naber = new Car("Tofaş", "Doğan", 1995);
        }
    }

    class Car
    {
        private string? _Marka;
        public string? Marka
        {
            get => _Marka;

            private set => _Marka = value?.Length < 15 ? value : value?.Substring(0, 15);
        }

        private string? _Model;
        public string? Model
        {
            get => _Model;

            private set => _Model = value?.Length < 20 ? value : value?.Substring(0, 20);
        }
        public int yil { get; private set; }
        public Color renk { get; private set; }

        private static Random rng;

        private static int _count;
        public static int count
        {
            get => _count;

            private set => _count = Math.Clamp(value, 0, 40);
        }

        static Car()
        {
            count = 0;
            rng = new Random();
        }

        public Car(string MARKA, string MODEL, int YIL)
        {
            renk = (Color)(rng.Next(0, 3));

            this.Marka = MARKA;
            this.Model = MODEL;
            this.yil = YIL;

            count++;
        }

        public static void Enter()
        {

        }

        public void sur()
        {

        }

        public void durdur()
        {

        }
    }

    enum Color
    {
        red, green, blue
    }
}
