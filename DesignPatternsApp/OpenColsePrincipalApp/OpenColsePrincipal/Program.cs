using System;
using System.Collections.Generic;

namespace OpenColsePrincipal
{
    public class Program
    {
        public enum Color
        {
            Red, Green, Blue
        }

        public enum Size
        {
            Small, Medium, Large
        }


        public class Product
        {
            public string Name { get; set; }
            public Color Color { get; set; }
            public Size Size { get; set; }

            public Product(string name, Color color, Size size)
            {
                Name = name;
                Color = color;
                Size = size;
            }
        }

        public class ProductFilter
        {
            public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
            {
                foreach (Product p in products)
                {
                    if (p.Size == size)
                    {
                        yield return p;
                    }
                }
            }

            public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
            {
                foreach (Product p in products)
                {
                    if (p.Color == color)
                    {
                        yield return p;
                    }
                }
            }


            public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
            {
                foreach (Product p in products)
                {
                    if (p.Color == color && p.Size == size)
                    {
                        yield return p;
                    }
                }
            }

        }


        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Small);

            Product[] products = { apple, tree, house };

            //violate  open-close pricpal start
            var productFilter = new ProductFilter();

            Console.WriteLine("Only Green Products are : ");
            foreach (Product p in productFilter.FilterByColor(products,Color.Green))
            {
                Console.WriteLine($"{p.Name}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Only Small Products are : ");
            foreach (Product p in productFilter.FilterBySize(products, Size.Small))
            {
                Console.WriteLine($"{p.Name}");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Only Small and Green Products are : ");
            foreach (Product p in productFilter.FilterBySizeAndColor(products, Size.Small,Color.Green))
            {
                Console.WriteLine($"{p.Name}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            //violate  open-close pricpal End



        }
    }
}
