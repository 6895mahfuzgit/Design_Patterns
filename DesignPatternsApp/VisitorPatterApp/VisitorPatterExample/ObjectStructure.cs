using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPatterExample
{
    public class ObjectStructure
    {

        private List<IVisitorElement> _cart;

        public ObjectStructure(List<IVisitorElement> cart)
        {
            _cart = cart;
        }

        public void RemoveItem(IVisitorElement visitorElement)
        {
            _cart.Remove(visitorElement);
        }

        public void ApplyVisitor(IVisitor visitor)
        {
            foreach (var item in _cart)
            {
                item.Accept(visitor);
               // visitor.Print();
            }
        }
    }
}
