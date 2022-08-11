using System;
using System.Collections.Generic;

namespace VisitorPatterExample
{
    public class Item
    {
        public int Id;
        public double Price;

        public Item(int id, double price)
        {
            Id = id;
            Price = price;
        }

        public double Discount(double percentage)
        {
            return Math.Round(Price * percentage, 2);
        }
    }

    public class Book : Item, IVisitorElement
    {
        public Book(int id, double price) : base(id, price)
        {
        }

        public void Accept(IVisitor visitor)
        {
            visitor.ViditableBook(this);
        }
    }

    public class Pen : Item, IVisitorElement
    {
        public Pen(int id, double price) : base(id, price)
        {
        }

        public void Accept(IVisitor visitor)
        {
            visitor.ViditablePen(this);
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {

            var items = new List<IVisitorElement>
            {
                new Book(1,100),
                new Pen(2,600),
                new Book(3,300),
                new Pen(4,900),
                new Book(5,200),
            };

            var cartObj = new ObjectStructure(items);
            var discount = new DiscountVisitor();

            //items.ForEach(i =>
            //{
            //    i.Accept(discount);
            //});

            var sales = new SalesCountVisitor();

            //items.ForEach(i =>
            //{
            //    i.Accept(sales);
            //});

            cartObj.ApplyVisitor(discount);
            cartObj.ApplyVisitor(sales);
            sales.Print();
            //sales.Print();

        }
    }
}
