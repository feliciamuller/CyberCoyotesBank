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

        //holds last Id used to create a user
        static private int lastId = 101;

        static public void CreateUser(string username, string password, bool isAdmin = false)
        {

            //checks if username exists in list of users
            bool exists = Users.Any(x => x.UserName == username);

            //if user name is already in use stop creation of new user
            if (exists)
            {
                Console.WriteLine("Username already exists");
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
                return;
            }


            //if password is empty stop creaton of new user
            if (password == "")
            {
                Console.WriteLine("Password cannot be empty");
                Console.WriteLine("press any key to continue");
                Console.ReadKey();
                return;
            }

            // +1 to lastId to create new user ID
            lastId++;

            //creates Admin or user depending on isAdmin bool and adds to user list
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
