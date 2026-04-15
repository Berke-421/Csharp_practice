using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bötpro_56
{
    class Class1
    {
        static void Main(string[] args)
        {
            NormalTank a = new NormalTank();
            Console.WriteLine(a.level);
        }
    }

    abstract class Tank 
    {
        public string? name { get; protected set; }

        public virtual int MaxCan
        {
            get;

            protected set;
        }
        public int NowCan { get; protected set; }

        private int _level;
        public int level
        {
            get => _level;

            protected set => _level = Math.Clamp(value, 1, 45);
        }

        public static int count { get; private set; }

        static Tank()
        {
            count = 0;
        }
        public Tank()
        {
            count++;
            level = 900;
            Console.WriteLine("Abstract sınıfın yapıcı metodu çalıştı");
            Console.WriteLine("abstract tank sınıfı new ile oluşturulamaz ama alt sınıfların yapıcı metodundan önce çalışır");
        }

        public abstract void Move();
        public abstract void die();
        public abstract void fire();
    }

    class HeavyTank : Tank
    {
        private int _MaxCan;
        public override int MaxCan { get => _MaxCan; protected set => _MaxCan = Math.Clamp(value, 80, 900); }

        public HeavyTank()
        {
            MaxCan = 80;
            NowCan = MaxCan;
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void die()
        {
            throw new NotImplementedException();
        }

        public override void fire()
        {
            throw new NotImplementedException();
        }
    }

    class NormalTank : Tank
    {
        private int _MaxCan;
        public override int MaxCan { get => _MaxCan; protected set => _MaxCan = Math.Clamp(value, 40, 550); }

        public NormalTank()
        {
            MaxCan = 40;
            NowCan = MaxCan;
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void die()
        {
            throw new NotImplementedException();
        }

        public override void fire()
        {
            throw new NotImplementedException();
        }
    }

    class LightTank : Tank
    {
        private int _MaxCan;
        public override int MaxCan { get => _MaxCan; protected set => _MaxCan = Math.Clamp(value, 20, 300); }

        public LightTank()
        {
            MaxCan = 20;
            NowCan = MaxCan;
        }
        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void die()
        {
            throw new NotImplementedException();
        }

        public override void fire()
        {
            throw new NotImplementedException();
        }
    }
}
