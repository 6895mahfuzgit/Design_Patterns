using System;
using System.Collections.Generic;

namespace StartegyPatternExample
{

    enum Countries
    {
        US,
        UAE,
        BD
    }

    public interface ITax
    {
        string GetCountryCode();
        decimal GetTax(); //here startegy works
                          // according to interface it works
    }

    public class UsTex : ITax
    {
        public string GetCountryCode()
        {
            return nameof(Countries.US);
        }

        public decimal GetTax()
        {
            return 0.5m;
        }
    }

    public class UaeTex : ITax
    {
        public string GetCountryCode()
        {
            return nameof(Countries.UAE);
        }

        public decimal GetTax()
        {
            return 0.6m;
        }
    }

    public class BdTex : ITax
    {
        public string GetCountryCode()
        {
            return nameof(Countries.BD);
        }

        public decimal GetTax()
        {
            return 0.9m;
        }
    }

    public class ProcessTax
    {
        List<ITax> taxs = new List<ITax>() { new UsTex(), new UaeTex(), new BdTex() };
        public decimal GetCountryTax(string countryCode)
        {

            var tax = 0m;

            foreach (var i in taxs)
            {
                if (i.GetCountryCode() == countryCode)
                {
                    tax = i.GetTax();
                    break;
                }
            }

            return tax;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //if i have order for usa then tring to calculate value(s) the
            // Order.CountryCode then

            var processTax=new ProcessTax();
            var tax=processTax.GetCountryTax("US");

            Console.WriteLine($"Tax For Us is : {tax}");
        }
    }
}
