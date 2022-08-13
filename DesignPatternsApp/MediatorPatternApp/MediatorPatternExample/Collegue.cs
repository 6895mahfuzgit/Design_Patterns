namespace MediatorPatternExample
{
    public abstract class Collegue
    {
        protected Mediator mediator;
        protected Collegue(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }

        public abstract void HandleNotification(string message);

    }
}
