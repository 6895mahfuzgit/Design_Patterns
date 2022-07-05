using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SingleResponsibilityExampleApp
{
    class Program
    {

        public class User
        {
            private readonly List<string> users = new List<string>();
            private static int count = 0;

            public int AddUser(string userName)
            {
                users.Add($"{++count}.{userName}");
                return count;
            }

            public void RemoveUser(int index)
            {
                users.RemoveAt(index);
            }


            public override string ToString()
            {
                return string.Join(Environment.NewLine, users);
            }

            //public void Save(string fileName)
            //{
            //    File.WriteAllText(fileName, ToString());
            //}
        }

        public class Presistance
        {
            public void SaveToFile(User user, string fileName, bool overwrite = false)
            {
                if (overwrite || !File.Exists(fileName))
                {
                    File.WriteAllText(fileName, user.ToString());
                }
            }
        }

        static void Main(string[] args)
        {
            var user = new User();
            user.AddUser("Mahfuz");
            user.AddUser("Shazol");
            user.AddUser("Rahman");

            Console.WriteLine(user);


            var p = new Presistance();
            var filePath = @"C:\Users\E440\Desktop\PridesysProjects\Design_Patterns\users.txt";
            p.SaveToFile(user, filePath, true);

            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });

        }
    }
}
