using System;

namespace Factory
{
    public class PointFactory
    {
        //factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cosh(theta), rho * Math.Sign(theta));
        }
    }

    public class Point
    {
        private double x, y;
        public Point(double x, double y)
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
            var cartesian = PointFactory.NewCartesianPoint(1.3, 5.6);
            Console.WriteLine($"cartesian: {cartesian}");

            var polar = PointFactory.NewPolarPoint(3.9, 90);
            Console.WriteLine($"polar: {polar}");

            Console.ReadLine();
        }

    }
}
