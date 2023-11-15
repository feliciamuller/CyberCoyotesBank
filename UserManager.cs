using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    static internal class UserManager
    {
        static public List<User> Users = new List<User>() { new Admin("admin", "admin", 101) };

        static private int lastId = 101;

        static public void CreateUser(string username, string password, bool isAdmin = false)
        {
            string uName;
            string pWord;
            bool exists = Users.Any(x => x.UserName == username);
            if (exists)
            {
                Console.WriteLine("Username already exists");
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
                return;
            }
            else
            {
                uName = username;
            }

            if (password == "")
            {
                Console.WriteLine("Password cannot be empty");
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
                return;
            }
            pWord = password;


            lastId++;
            if (isAdmin)
            {
                Users.Add(new Admin(username, password, lastId));
            }
            else
            {
                Users.Add(new User(username, password, lastId));
            }
            


        }

    }
}
