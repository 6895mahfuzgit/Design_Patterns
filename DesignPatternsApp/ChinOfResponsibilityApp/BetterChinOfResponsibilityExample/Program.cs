using System;
using System.Collections.Generic;

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
        }




        public class AgeValidate : IUserValidateHandler<User>
        {
            public void Handler(User t)
            {
                if (t.Age < 18)
                {
                    Console.WriteLine("Age should be greater then 18.");
                }
                else
                {
                    Console.WriteLine("Age is Ok.");
                }

            }
        }

        public class NameValidate : IUserValidateHandler<User>
        {
            public void Handler(User t)
            {
                if (string.IsNullOrEmpty(t.Name))
                {
                    Console.WriteLine("Name can't be empty.");
                }
                else
                {
                    Console.WriteLine("Name is Ok.");
                }

            }
        }

        public class ValidateUser
        {
            private IList<IUserValidateHandler<User>> validations;

            public ValidateUser(params IUserValidateHandler<User>[] userValidateHandlers)
            {
                this.validations = userValidateHandlers;
            }

            public void CheckValidator(User user)
            {
                foreach (var item in validations)
                {
                    item.Handler(user);
                }
            }

        }

        static void Main(string[] args)
        {

            var user = new User()
            {
                Id = 1,
                Name = "Mahfuz",
                Age = 10
            };

            //var ageValidate = new AgeValidate();
            // ageValidate.SetNext(new NameValidate());

            // ageValidate.Handler(user);

            var userValidate = new ValidateUser(new AgeValidate(),new NameValidate());
            userValidate.CheckValidator(user);

        }
    }
}
