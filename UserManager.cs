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
        // List to hold all Users and Admins
        static private List<User> Users = new List<User>() { new Admin("admin", "admin", 101), new User("user", "user", 102), new User("user1", "user1", 103) };

        // Holds last Id used to create a user
        static private int lastId = 103;

        // Creates a new user or admin and adds to users list. Set bool to true to create admin
        static public void CreateUser(string username, string password, bool isAdmin = false)
        {

            // Checks if the username exists in list of users
            bool exists = Users.Any(x => x.UserName == username);

            // If the username is already in use stop creation of new user
            if (exists)
            {
                Console.WriteLine("The username already exists");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }


            // If the password is empty stop creation of new user
            if (password == "")
            {
                Console.WriteLine("The password cannot be empty");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }

            // +1 to lastId to create new user ID
            lastId++;

            // Creates Admin or user depending on isAdmin bool and adds to user list
            if (isAdmin)
            {
                Users.Add(new Admin(username, password, lastId));
            }
            else
            {
                Users.Add(new User(username, password, lastId));
            }
        }


        // Get user by string
        public static User GetUser(string username)
        {
            return Users.Find(x => x.UserName == username);
        }

        // Get user by id
        public static User GetUser(int id)
        {
            return Users.Find(x => x.ID == id);
        }

        // Gets all list of all Users
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

        // Gets a list of all Admins
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

        // Gets a list of both Users and Admins
        public static List<User> GetUsersAndAdmins()
        {
            return Users;
        }
    }
}
