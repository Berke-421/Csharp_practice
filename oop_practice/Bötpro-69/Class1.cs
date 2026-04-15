using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_69
{
    internal class Class1
    {
        static void Main(string[] args)
        {

        }
    }

    public interface IMusic
    {
        void play() { Console.WriteLine("Playing music"); } // default implementation
        // otomatik ayar tüm implementasyonlarda

        void pause(); // manuel şekilde implementasyon gerektirir

        string? title { get; } // yalnızca okunabilir ancak implementasyonda set edilebilir
    }

    public class Piano : IMusic
    {
        public void pause()
        {
            Console.WriteLine("Music paused");
        }

        public string? title { get; protected set; }
    }

    public class Guitar : IMusic
    {
        public void pause()
        {
            Console.WriteLine("Music paused");
        }

        public string? title { get; protected set; }
    }

    public class Drums : IMusic
    {
        public void pause()
        {
            Console.WriteLine("Music paused");
        }
        public string? title { get; protected set; }
    }
}
