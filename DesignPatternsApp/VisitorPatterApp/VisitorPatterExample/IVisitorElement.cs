namespace VisitorPatterExample
{
    public interface IVisitorElement
    {
        void Accept(IVisitor visitor);
    }
}
