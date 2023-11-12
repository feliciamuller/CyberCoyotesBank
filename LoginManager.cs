using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    static internal class LoginManager
    {

        //Holds curret user logged in 
        static User activeUser;

        //checks list of users to find if username exists.
        //if found in list check if username and password is correct and return true/false
        static public bool Login(string username, string password)
        {
            //TODO Move list of users to better place
            List<User> users = new List<User>() { new User("admin", "admin"), new User("test", "123") };

            User user = users.Find(x => x._username == username);

            if (user == null) { return false; }
            if (user._username == username && user._password == password)
            {
                activeUser = user;
                return true;
            }
            else
            {
                return false;
            }

        }

        //Used to check password of active user
        //can be used for password checks on actions with extra security
        //example: enter password before transfering money
        static public bool Password(string password)
        {
            if (password == activeUser._password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
