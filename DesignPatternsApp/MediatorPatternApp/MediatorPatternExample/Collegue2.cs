using System;

namespace MediatorPatternExample
{
    public class Collegue2 : Collegue
    {
        //public Collegue2(Mediator mediator) : base(mediator)
        //{
        //}

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Collegue2 receives notification message: {message}");
        }
    }
}
