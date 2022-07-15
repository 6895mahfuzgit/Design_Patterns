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


        //specification pattern start
        public interface ISpecification<T>
        {
            bool isSatisfied(T t);
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
        }

        public class ColorSpecification : ISpecification<Product>
        {
            private Color _color;

            public ColorSpecification(Color color)
            {
                _color = color;
            }

            public bool isSatisfied(Product t)
            {
                return t.Color == _color;
            }
        }


        public class SizeSpecification : ISpecification<Product>
        {
            private Size _size;

            public SizeSpecification(Size size)
            {
                _size = size;
            }

            public bool isSatisfied(Product t)
            {
                return t.Size == _size;
            }
        }

        public class AndSpecification<T> : ISpecification<T>
        {
            private ISpecification<T> _specification1, _specification2;
            public AndSpecification(ISpecification<T> specification1, ISpecification<T> specification2)
            {
                _specification1 = specification1;
                _specification2 = specification2;
            }

            public bool isSatisfied(T t)
            {
                return _specification1.isSatisfied(t) && _specification2.isSatisfied(t);
            }
        }

        public class BatterFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
            {
                foreach (var item in items)
                {
                    if (spec.isSatisfied(item))
                        yield return item;
                }
            }
        }


        //specification pattern end


        static void Main(string[] args)
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Medium);

            Product[] products = { apple, tree, house };

            //violate  open-close pricpal start
            //var productFilter = new ProductFilter();

            //Console.WriteLine("Only Green Products are : ");
            //foreach (Product p in productFilter.FilterByColor(products, Color.Green))
            //{
            //    Console.WriteLine($"{p.Name}");
            //}
            //Console.WriteLine("");
            //Console.WriteLine("");
            //Console.WriteLine("Only Small Products are : ");
            //foreach (Product p in productFilter.FilterBySize(products, Size.Small))
            //{
            //    Console.WriteLine($"{p.Name}");
            //}
            //Console.WriteLine("");
            //Console.WriteLine("");

            //Console.WriteLine("Only Small and Green Products are : ");
            //foreach (Product p in productFilter.FilterBySizeAndColor(products, Size.Small, Color.Green))
            //{
            //    Console.WriteLine($"{p.Name}");
            //}
            //Console.WriteLine("");
            //Console.WriteLine("");
            //violate  open-close pricpal End


            // using pecification pattern
            var betterFilter = new BatterFilter();

            Console.WriteLine("Only Green Products are : ");
            foreach (Product p in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"{p.Name}");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Only Small Products are : ");
            foreach (Product p in betterFilter.Filter(products, new SizeSpecification(Size.Small
                )))
            {
                Console.WriteLine($"{p.Name}");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Only Small and Green Products are : ");
            foreach (Product p in betterFilter.Filter(products, new AndSpecification<Product>(new SizeSpecification(Size.Small),new ColorSpecification(Color.Green))))
            {
                Console.WriteLine($"{p.Name}");
            }

            Console.WriteLine("");
            Console.WriteLine("");

            // using pecification pattern
        }
    }
}
