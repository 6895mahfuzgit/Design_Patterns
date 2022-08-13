using System;

namespace MediatorPatternExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var media=new ConcretMediator();

            var c1 = new Collegue1();
            var c2 = new Collegue2();
            

            media.Register(c1);
            media.Register(c2);
            // media.c1 = c1;
            // media.c2 = c2;

            c1.Send("Hi, c2 how are you?");
            c2.Send("I am fine c1.how about you?");
        }
    }
}
