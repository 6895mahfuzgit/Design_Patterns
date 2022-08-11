using System;

namespace VisitorPatterExample
{
    public class SalesCountVisitor : IVisitor
    {
        private int _bookCount = 0;
        private int _penCount = 0;

        public void ViditableBook(Book book)
        {
            _bookCount++;
        }

        public void ViditablePen(Pen pen)
        {
            _penCount ++;
        }
        public void Print()
        {
            Console.WriteLine($"Total Book(s) {_bookCount} and Pen(s) {_penCount} sold.");
            Console.WriteLine($"Total { _bookCount + _penCount} Item(s) sold.");
        }

    }
}
