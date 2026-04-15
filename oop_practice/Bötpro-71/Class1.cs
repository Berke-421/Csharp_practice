using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_71
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bötpro 71");
        }
    }

    public interface IExhaust
    {
        void MakeSound() { Console.WriteLine("VUU TUT TUT TU TU TU"); } // ability to make exhaust sound
        void Rev(); // ability to rev
        void ShootFlames(); // ability to shoot flames

        string? ExhaustType { get; } // read-only but can be set in implementation
    }

    public abstract class Vehicle
    {
        public abstract string? Type { get; } // vehicle type
        public abstract string? Brand { get; } // vehicle brand

        public abstract int Speed { get; protected set; } // vehicle speed
        public abstract int Price { get; protected set; } // vehicle price
        public abstract int Fuel { get; protected set; } // vehicle fuel level

        private int _level; // vehicle level status
        public int Level // LEVEL STATUS COMMON TO EVERY CLASS. not static because it will be kept separately for each vehicle
        {
            get => _level;
            private set => _level = Math.Clamp(value, 0, 999); // limit between 0 and 999 percentage value
        }
        
        private static int _count;
        public static int Count
        {
            get => _count;
            private set => _count = Math.Clamp(value, 0, 1000); // limit between 0 and 1000
        }

        public static Random Rng; // tool to be used by the whole class

        static Vehicle()
        {
            Rng = new Random(); // create random number generator at start
            Count = 0; // initialize vehicle count
        }

        public Vehicle()
        {
            Count++; // increase counter whenever a new vehicle is created
            Level = 0; // initial level status is zero because the vehicle is newly acquired
        }

        public int LevelUp()
        {
            return ++Level;
        }

        public abstract void StartEngine();
        public abstract void drive();
        public abstract void fast();
    }

    public class CommercialCar : Vehicle
    {
        public override string? Type => "Commercial car"; // vehicle type

        private string _brand;
        public override string? Brand => _brand;

        private int _speed;
        private int _price;
        private int _fuel;
        public override int Speed { get => _speed; protected set => _speed = Math.Clamp(value, 0, 300); }
        public override int Price { get => _price; protected set => _price = Math.Clamp(value, 0, 100000); }
        public override int Fuel { get => _fuel; protected set => _fuel = Math.Clamp(value, 0, 150); }

        public CommercialCar()
        {
            Speed = Rng.Next(80, 151); // random speed between 80 and 150 because it can be encountered on the street
            Price = Rng.Next(20000, 80001); // random price between 20,000 and 80,000 because commercial cars are usually in this range
            Fuel = Rng.Next(0, 151); // random fuel level between 0 and 150 because it can be encountered on the street
            _brand = RandomBrand.GetRandomCommercialCarBrand(); // assign a random brand
        }

        public override void StartEngine()
        {
            throw new NotImplementedException();
        }

        public override void drive()
        {
            throw new NotImplementedException();
        }
        public override void fast()
        {
            throw new NotImplementedException();
        }
    }

    public class RaceCar : Vehicle, IExhaust // abstract class and interface can be implemented at the same time. This is possible.
    {
        public override string? Type => "Race car"; // vehicle type
        private string _brand;
        public override string? Brand => _brand;
        private int _speed;
        private int _price;
        private int _fuel;
        public override int Speed { get => _speed; protected set => _speed = Math.Clamp(value, 0, 500); }
        public override int Price { get => _price; protected set => _price = Math.Clamp(value, 50000, 500000); }
        public override int Fuel { get => _fuel; protected set => _fuel = Math.Clamp(value, 0, 100); }
        private string _exhaustType;
        public string? ExhaustType => _exhaustType;
        public RaceCar()
        {
            Speed = Rng.Next(200, 401); // random speed between 200 and 400 because race cars are fast
            Price = Rng.Next(100000, 300001); // random price between 100,000 and 300,000 because race cars are expensive
            Fuel = Rng.Next(0, 101); // random fuel level between 0 and 100 because race cars are high-performance
            _brand = RandomBrand.GetRandomRaceCarBrand(); // assign a random brand
            _exhaustType = RandomBrand.GetRandomExhaustType(); // assign a random exhaust type
        }
        public override void StartEngine()
        {
            throw new NotImplementedException();
        }
        public override void drive()
        {
            throw new NotImplementedException();
        }
        public override void fast()
        {
            throw new NotImplementedException();
        }
        public void Rev()
        {
            throw new NotImplementedException();
        }
        public void ShootFlames()
        {
            throw new NotImplementedException();
        }
    }

    public static class RandomBrand
    {
        public static string GetRandomCommercialCarBrand()
        {
            Array values = Enum.GetValues<CommercialCarBrand>();
            return values.GetValue(Random.Shared.Next(values.Length))!.ToString()!;
        }

        public static string GetRandomRaceCarBrand()
        {
            Array values = Enum.GetValues<RaceCarBrand>();
            return values.GetValue(Random.Shared.Next(values.Length))!.ToString()!;
        }

        public static string GetRandomExhaustType()
        {
            Array values = Enum.GetValues<ExhaustType>();
            return values.GetValue(Random.Shared.Next(values.Length))!.ToString()!;
        }
    }

    public enum CommercialCarBrand
    {
        Ford,
        Mercedes,
        Renault,
        Volkswagen,
        Toyota,
        Hyundai,
    }

    public enum RaceCarBrand
    {
        MercedesBenz,
        Bmw,
        Audi,
        Ferrari,
        Lamborghini,
        Porsche,
        McLaren,
        Bugatti,
        AstonMartin,
    }

    public enum ExhaustType
    {
        Standard,
        Sport,
        Performance,
        Race,
    }
}
