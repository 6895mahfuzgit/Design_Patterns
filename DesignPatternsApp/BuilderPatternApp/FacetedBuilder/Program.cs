using System;

namespace FacetedBuilder
{
    public class Person
    {
        public string StreetAddress, PostCode, City;
        public string CompanyName, Position;
        public int AnnualIncome;
        public override string ToString()
        {
            return $"{nameof(StreetAddress)} :{StreetAddress} {nameof(PostCode)} :{PostCode} {nameof(City)} :{City} {nameof(CompanyName)} :{CompanyName} {nameof(Position)} :{Position} {nameof(AnnualIncome)} :{AnnualIncome}";
        }
    }

    public class PersonBuilder //facade
    {
        //referance
        protected Person person = new Person();
        public PersonJobBuilder Works => new PersonJobBuilder(person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public static implicit operator Person(PersonBuilder personBuilder)
        {
            return personBuilder.person;
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }
        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder In(string cityName)
        {
            person.City = cityName;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postCode)
        {
            person.PostCode = postCode;
            return this;
        }

    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new PersonBuilder();
            Person person = p
                .Lives.At("Matikata")
                                .In("Dhaka")
                                .WithPostCode("1206")
                .Works.At("P")
                              .AsA("Software Engg")
                              .Earning(9999999);

            Console.WriteLine(person);
        }
    }
}
