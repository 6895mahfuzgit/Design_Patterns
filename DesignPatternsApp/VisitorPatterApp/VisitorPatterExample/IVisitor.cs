namespace VisitorPatterExample
{
    public interface IVisitor
    {
        void ViditableBook(Book book);
        void ViditablePen(Pen pen);
        void Print();
    }
}
