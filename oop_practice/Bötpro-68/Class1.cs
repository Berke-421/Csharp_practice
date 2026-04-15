using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_68
{
    internal class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    public interface Ianimal
    {
        void sound() { Console.WriteLine("Animal sound"); } // default implementation
        // default ayar otomatik olarak tüm implementasyonlarda
        void eat() { Console.WriteLine("Animal is seating"); }
        void walk();

        string? name { get; } // yalnızca okunabilir ancak implementasyonda set edilebilir
    }

    public class Dog : Ianimal
    {
        // otomatik şekilde sound() ve eat() metotlarını alır çünkü default implementation var
        public void walk()
        {
            Console.WriteLine("Dog is walking");
        }

        public string? name { get; protected set; }
    }

    public class Cat : Ianimal
    {
        // otomatik şekilde sound() ve eat() metotlarını alır çünkü default implementation var

        public void walk()
        {
            Console.WriteLine("Cat is walking");
        }

        public string? name { get; protected set; }
    }

    public class Bird : Ianimal
    {
        // otomatik şekilde sound() ve eat() metotlarını alır çünkü default implementation var
        public void walk()
        {
            Console.WriteLine("Bird is walking");
        }
        public string? name { get; protected set; }
    }
}
