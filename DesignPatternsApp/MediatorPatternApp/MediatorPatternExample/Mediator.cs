namespace MediatorPatternExample
{
    public abstract class Mediator
    {
        public abstract void Send(string message, Collegue collegue);
    }
}
