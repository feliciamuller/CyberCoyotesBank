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

            User user = UserManager.GetUsersAndAdmins().Find(x => x.UserName == username);

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

        //Used to check password of active user
        //can be used for password checks on actions with extra security
        //example: enter password before transfering money
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
