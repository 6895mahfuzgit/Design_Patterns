using System;

namespace VisitorPatterExample
{
    public class DiscountVisitor : IVisitor
    {
        private double _savings = 0.00;

        public void ViditableBook(Book book)
        {
            double discount = 0.00;

            if (book.Price > 350)
            {
                discount = book.Discount(.40);
                Console.WriteLine($"Book {book.Id} is now {book.Price - discount}");
            }
            else
            {
                Console.WriteLine($"Full price of Book {book.Id} is {book.Price}");
            }

            _savings += discount;
        }

        public void ViditablePen(Pen pen)
        {
            double discount = 0.00;

            if (pen.Price > 250)
            {
                discount = pen.Discount(.55);
                Console.WriteLine($"Pen {pen.Id} is now {pen.Price - discount}");
            }
            else
            {
                Console.WriteLine($"Full price of Pen {pen.Id} is {pen.Price}");
            }

            _savings += discount;
        }

        public void Print()
        {
            Console.WriteLine($"Total Savings is {_savings}");
        }

    }
}
