using System;

namespace ChinOfResponsibilityExample
{
    public class Program
    {
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public interface IUserValidateHandler<T> where T : class
        {
            void Handler(T t);
            IUserValidateHandler<T> SetNext(IUserValidateHandler<T> next);
        }

        public class UserValidateHandler<T> : IUserValidateHandler<T> where T : class
        {
            private IUserValidateHandler<T> Next;



            public IUserValidateHandler<T> SetNext(IUserValidateHandler<T> next)
            {
                Next = next;
                return next;
            }

            public virtual void Handler(T t)
            {
                Next?.Handler(t);
            }
        }


        public class AgeValidate : UserValidateHandler<User>
        {
            public override void Handler(User t)
            {
                if (t.Age < 18)
                {
                    Console.WriteLine("Age should be greater then 18.");
                }
                else
                {
                    Console.WriteLine("Age is Ok.");
                }
                base.Handler(t);
            }
        }

        public class NameValidate : UserValidateHandler<User>
        {
            public override void Handler(User t)
            {
                if (string.IsNullOrEmpty(t.Name))
                {
                    Console.WriteLine("Name can't be empty.");
                }
                else
                {
                    Console.WriteLine("Name is Ok.");
                }
                base.Handler(t);
            }
        }

        static void Main(string[] args)
        {

            var user = new User()
            {
                Id = 1,
                Name = "Mahfuz",
                Age = 25
            };

            var ageValidate = new AgeValidate();
            ageValidate.SetNext(new NameValidate());

            ageValidate.Handler(user);

        }
    }
}
