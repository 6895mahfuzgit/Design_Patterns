using System;

namespace LiskovSubstitutionPrincipal
{
    public class Rectangle
    {
        public virtual int Weight { get; set; }
        public virtual int Height { get; set; }

        public Rectangle()
        {
        }

        public Rectangle(int weight, int height)
        {
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Weight)}:{Weight}, {nameof(Height)}:{Height}";
        }
    }


    public class Square : Rectangle
    {
        public override int Weight { set { base.Weight = base.Height = value; } }
        public override int Height { set { base.Weight = base.Height = value; } }
    }

    public class Program
    {
        static void Main(string[] args)
        {

            static int Area(Rectangle r) => r.Weight * r.Height;

            Rectangle r = new Rectangle(3, 6);
            Console.WriteLine($"{r} has Area: {Area(r)}");

            Rectangle sq = new Square();
            sq.Weight = 4;
            Console.WriteLine($"{sq} has Area: {Area(sq)}");
        }

    }
}
