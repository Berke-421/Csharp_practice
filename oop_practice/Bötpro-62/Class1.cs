using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Bötpro_62
{
    class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    abstract class Vehicle
    {
        public string? brand { get; protected set; }

        private static int _count;
        public static int count
        {
            get => _count;

            private set => _count = Math.Clamp(value, 0, 22);
        }

        public abstract int fuel { get; protected set; }
        public abstract int speed { get; protected set; }
        public abstract int gear { get; protected set; }

        private int _level;
        public int level
        {
            get => _level;

            private set => _level = Math.Clamp(value, 1, 1000);
        }

        protected static Random gnr;

        static Vehicle()
        {
            gnr = new Random();
            count = 0;
        }

        public Vehicle()
        {
            count++;
        }

        public static void Start() { }
        public void levelup()
        {
            level++;
        }

        public void ShiftGear()
        {
            gear++;
        }

        public abstract void move();
        public abstract void sound();
        public abstract void stop();
    }

    class Car : Vehicle
    {
        private int _fuel;
        private int _speed;
        private int _gear;
        public override int fuel { get => _fuel; protected set => _fuel = Math.Clamp(value, 0, 600); }
        public override int speed { get => _speed; protected set => _speed = Math.Clamp(value, -20, 300); }
        public override int gear { get => _gear; protected set => _gear = Math.Clamp(value, 0, 6); }

        public Car()
        {
            brand = RandomBrandCar.GetRandomBrand();
            fuel = gnr.Next(1, 600);
            speed = gnr.Next(10, 350);

            if (speed >= 0 && speed <= 60)
                gear = 1;
            else if (speed > 60 && speed <= 110)
                gear = 2;
            else if (speed > 110 && speed <= 160)
                gear = 3;
            else if (speed > 160 && speed <= 220)
                gear = 4;
            else if (speed > 220 && speed <= 280)
                gear = 5;
            else if (speed > 280 && speed <= 350)
                gear = 6;
        }

        public override void move()
        {
            throw new NotImplementedException();
        }

        public override void sound()
        {
            throw new NotImplementedException();
        }

        public override void stop()
        {
            throw new NotImplementedException();
        }
    }

    class Truck : Vehicle
    {
        private int _fuel;
        private int _speed;
        private int _gear;
        public override int fuel { get => _fuel; protected set => _fuel = Math.Clamp(value, 0, 1500); }
        public override int speed { get => _speed; protected set => _speed = Math.Clamp(value, -10, 300); }
        public override int gear { get => _gear; protected set => _gear = Math.Clamp(value, 0, 12); }

        public Truck()
        {
            brand = RandomBrandCar.GetRandomBrand();
            fuel = gnr.Next(10, 1500);
            speed = gnr.Next(10, 300);

            if (speed >= 0 && speed <= 10)
                gear = 1;
            else if (speed > 10 && speed <= 18)
                gear = 2;
            else if (speed > 18 && speed <= 26)
                gear = 3;
            else if (speed > 26 && speed <= 34)
                gear = 4;
            else if (speed > 34 && speed <= 42)
                gear = 5;
            else if (speed > 42 && speed <= 50)
                gear = 6;
            else if (speed > 50 && speed <= 58)
                gear = 7;
            else if (speed > 58 && speed <= 66)
                gear = 8;
            else if (speed > 66 && speed <= 74)
                gear = 9;
            else if (speed > 74 && speed <= 82)
                gear = 10;
            else if (speed > 82 && speed <= 88)
                gear = 11;
            else if (speed > 88 && speed <= 90)
                gear = 12;

        }

        public override void move()
        {
            throw new NotImplementedException();
        }

        public override void sound()
        {
            throw new NotImplementedException();
        }

        public override void stop()
        {
            throw new NotImplementedException();
        }
    }

    static class RandomBrandCar
    {
        private static Random rng = new Random();

        public static string? GetRandomBrand()
        {
            var e = Enum.GetValues(typeof(ArabaMarkasi));
            return e.GetValue(rng.Next(e.Length)).ToString();
        }
    }

    enum ArabaMarkasi
    {
        Toyota,
        Honda,
        Ford,
        BMW,
        Mercedes,
        Audi,
        Volkswagen,
        Nissan,
        Chevrolet,
        Hyundai,
        Kia,
        Mazda,
        Subaru,
        Lexus,
        Peugeot,
        Renault,
        Fiat,
        Tesla,
        Jaguar,
        Tofas,
        Volvo
    }

    // Motosiklet markaları
    enum MotosikletMarkasi
    {
        Yamaha,
        Honda,
        Kawasaki,
        Suzuki,
        Ducati,
        BMW,
        HarleyDavidson
    }

    // Kamyon markaları
    enum KamyonMarkasi
    {
        MercedesBenz,
        Volvo,
        Scania,
        MAN,
        Iveco
    }
}
