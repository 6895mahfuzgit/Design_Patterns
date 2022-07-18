using System;

namespace FactoryMethodPattern
{

    public class Point
    {
        private double x, y;

        //factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cosh(theta), rho * Math.Sign(theta));
        }

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }


        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cartesian = Point.NewCartesianPoint(1.3, 5.6);
            Console.WriteLine($"cartesian: {cartesian}");

            var polar = Point.NewPolarPoint(3.9, 90);
            Console.WriteLine($"polar: {polar}");

            Console.ReadLine();
        }
    }
}
