using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    static internal class LoginManager
    {

        // Holds current user logged in 
        static User activeUser;

        // Checks list of users to find if the username exists
        // If it's found in the list check if the username and password is correct and return true/false
        static public bool Login(string username, string password)
        {

            User user = UserManager.GetUser(username);

            if (user == null) { return false; }
            if (user.UserName == username && user.Password == password)
            {
                activeUser = user;
                return true;
            }
            else
            {
                return false;
            }

        }

        // Used to check password of active user
        // Can be used for password checks on actions with extra security
        // Example: enter password before transfering money
        static public bool Password(string password)
        {
            if (password == activeUser.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public User GetActiveUser()
        {
            return activeUser;
        }

    }
}
