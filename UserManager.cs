using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    static internal class UserManager
    {
        //list to hold all Users and Admins
        static private List<User> Users = new List<User>() { new Admin("admin", "admin", 101), new Admin("admin1", "admin", 102), new Admin("admin2", "admin", 103) , new User("user", "admin", 104), new User("user1", "admin", 105) };

        //holds last Id used to create a user
        static private int lastId = 101;

        //creates a new user or admin and adds to users list. Set bool to true to create admin
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


        //get user by string
        public static User GetUser(string username)
        {
            return Users.Find(x => x.UserName == username);
        }

        //get user by id
        public static User GetUser(int id)
        {
            return Users.Find(x => x.ID == id);
        }

        //gets all list of all Users
        public static List<User> GetUsersList()
        {
            List<User> listUsers = new List<User>();

            foreach (var user in Users)
            {
                if (user.GetType().Name == "User")
                {
                    listUsers.Add(user);
                }
                
            }

            return listUsers;
        }

        //gets a list of all Admins
        public static List<User> GetAdminsList()
        {
            List<User> listUsers = new List<User>();

            foreach (var user in Users)
            {
                if (user.GetType().Name == "Admin")
                {
                    listUsers.Add(user);
                }

            }

            return listUsers;
        }

        //gets a list of both Users and Admins
        public static List<User> GetUsersAndAdmins()
        {
            return Users;
        }
    }
}
