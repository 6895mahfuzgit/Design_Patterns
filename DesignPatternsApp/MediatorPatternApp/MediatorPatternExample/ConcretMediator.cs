using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternExample
{
    public class ConcretMediator : Mediator
    {
        public Collegue1 c1 { get; set; }
        public Collegue2 c2 { get; set; }

        public override void Send(string message, Collegue collegue)
        {
            if (collegue == c1)
            {
                c2.HandleNotification(message);
            }
            else if (collegue == c2)
            {
                c1.HandleNotification(message);
            }
            else
            {
                throw new Exception("Invalid collegue");
            }

        }
    }
}
