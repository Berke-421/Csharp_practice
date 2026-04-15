using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bötpro_9
{
    class Class1
    {
        static void Main()
        {
            Araba berke = new Araba();

            berke.hiz = 34;

            berke.arttir(12);

            Console.WriteLine();

            Araba bicer = new Araba();

            bicer.hiz = 70;
            bicer.arttir(100);

            Console.WriteLine();

            Araba nesne = new Araba(); // yeni bir nesne oluşturarak sınıfın içindeki özellikleri kullanabileceiğimiz nesne adında bir referans oluşturarak bellekte yeni yer açılır.
            nesne.hiz = 56; // nesne ile sınıf içindeki özelliğe/alana ulaşarak değer atarız her yeni nesneye ait o sınıftaki özellikler ve metotlar olur.
            nesne.arttir(67);
        }
    }

    class Araba
    {
        public short hiz;

        public void arttir(short a)
        {
            hiz += a;
            Console.WriteLine($"Hiz {a}km/h arttırıldı");
            Console.WriteLine($"Yeni hız: {hiz} km/h");
        }
    }
}
