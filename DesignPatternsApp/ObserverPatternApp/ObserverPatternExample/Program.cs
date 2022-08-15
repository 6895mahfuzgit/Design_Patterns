using System;
using System.Collections.Generic;

namespace ObserverPatternExample
{


    public class OrderServiec : OrderSubject
    {
        public void CompleteOrder(Order order)
        {
            Notify(order.AsTrackingOrder());
        }
    }

    public interface IOrderobserver
    {
        void ReciveNotify(TrackerOrder trackerOrder);
    }




    public class Order
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }

    public static class TrackerOrderExtenction
    {
        public static TrackerOrder AsTrackingOrder(this Order order)
        {
            return new TrackerOrder()
            {
                ItemId = order.ItemId,
                Quantity = order.Quantity,
            };
        }
    }

    public class TrackerOrder
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }

    public abstract class OrderSubject
    {
        private List<IOrderobserver> _observers = new List<IOrderobserver>();

       public void Register(IOrderobserver orderobserver)
        {
            _observers.Add(orderobserver);
        }

       public void RemoveObserver(IOrderobserver orderobserver)
        {
            _observers.Remove(orderobserver);
        }


        protected void Notify(TrackerOrder tracker)
        {

            foreach (var obs in _observers)
            {
                obs.ReciveNotify(tracker);
            }
        }


    }
    public class StockChange : IOrderobserver
    {
        public void ReciveNotify(TrackerOrder trackerOrder)
        {
            Console.WriteLine($"Stock Change Notified for Item {trackerOrder.ItemId} and amount {trackerOrder.Quantity}");
        }
    }

    public class ResellerChange : IOrderobserver
    {
        public void ReciveNotify(TrackerOrder trackerOrder)
        {
            Console.WriteLine($"Ressler Notified for Item {trackerOrder.ItemId} and amount {trackerOrder.Quantity}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            var order=new OrderServiec();
            order.Register(new StockChange());
            order.Register(new ResellerChange());

            Console.WriteLine("   ");
            order.CompleteOrder(new Order { ItemId = 1, Quantity = 10 });

            Console.WriteLine("   ");
            order.CompleteOrder(new Order { ItemId = 6, Quantity = 4 });

            Console.WriteLine("   ");
            order.CompleteOrder(new Order { ItemId = 3, Quantity = 5 });


        }
    }
}
