using System;

namespace MediatorPatternExample
{
    public class Collegue1 : Collegue
    {
        public Collegue1(Mediator mediator) : base(mediator)
        {
        }

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Collegue1 receives notification message: {message}");
        }
    }
}
