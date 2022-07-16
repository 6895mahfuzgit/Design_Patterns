using System;

namespace InterfaceSegregationPrincipl
{

    public class Document
    {

    }

    public interface IMaccine // here forcely impl all method 
    {
        void Print(Document document);
        void Scan(Document document);
        void Fax(Document document);
    }

    //segregate funtion in interfaces

    public interface IPrinter
    {
        void Print(Document document);
    }

    public interface IScan
    {
        void Scan(Document document);
    }

    public interface IFax
    {
        void Fax(Document document);
    }


    public interface IMultiFunctionDevice : IPrinter, IScan, IFax
    {
    }

    // use decorator patter to use already impl methods
    public class Machine : IMultiFunctionDevice
    {
        private readonly IPrinter _printer;
        private readonly IScan _scan;

        public Machine(IPrinter printer, IScan scan)
        {
            _printer = printer;
            _scan = scan;
        }

        public void Print(Document document)
        { 
             _printer.Print(document);//decorator pattern
        }

        public void Scan(Document document)
        {
            _scan.Scan(document); //decorator pattern
        }

        public void Fax(Document document)
        {
            Console.WriteLine("Fax impl ", document);
        }

    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
