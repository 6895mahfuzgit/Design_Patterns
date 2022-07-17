using System;

namespace FluentBuilderWithRecursivegeneric
{
    public class Personal
    {
        public string Name;
        public string Position;

        public class Builder : PersonJobBuilder<Builder> { }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name }, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Personal personal = new Personal();

        public Personal Build()
        {
            return personal;
        }
    }

    public class PersonalInfoBuilder<SELF>
     : PersonBuilder
     where SELF : PersonalInfoBuilder<SELF>

    {
        public SELF Called(string name)
        {
            personal.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF> : PersonalInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorkAs(string position)
        {
            personal.Position = position;
            return (SELF)this;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var me = Personal.New
                        .Called("Mahfuz")
                        .WorkAs("Software Engg")
                        .Build();

            Console.WriteLine(me.ToString());
        }
    }
}
