using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPatternExample
{
    public class ConcretMediator : Mediator
    {
        //public Collegue1 c1 { get; set; }
        //public Collegue2 c2 { get; set; }

        private List<Collegue> collegues = new List<Collegue>();


        public void Register(Collegue collegue)
        {
            collegue.SetMediator(this);
            collegues.Add(collegue);
        }

        public override void Send(string message, Collegue collegue)
        {
            //if (collegue == c1)
            //{
            //    c2.HandleNotification(message);
            //}
            //else if (collegue == c2)
            //{
            //    c1.HandleNotification(message);
            //}
            //else
            //{
            //    throw new Exception("Invalid collegue");
            //}

            collegues.Where(c => c != collegue)
                     .ToList()
                     .ForEach(m =>
                     {
                         m.HandleNotification(message);
                     });
        }
    }
}
