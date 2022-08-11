using System;
using System.Collections.Generic;

namespace AbstractFactory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea is nice but I'd prefer it with milk");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Coffee is sensational");
        }
    }


    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }


    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put a tea bag,boil water,pour {amount} ml, add lemon and enjoy! ");

            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans,boil water,pour {amount} ml, add cream and suger! ");

            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Coffee, Tea
        }
         
        private Dictionary<AvailableDrink,IHotDrinkFactory> factories=new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            //var s = Enum.GetValues(typeof(AvailableDrink));

            foreach (AvailableDrink  drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory=(IHotDrinkFactory)Activator.CreateInstance(typeof(AvailableDrink)); 
            }

        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
