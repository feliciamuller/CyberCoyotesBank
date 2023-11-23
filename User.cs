using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{

    internal class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }

        public User(string username, string password, int id)
        {
            UserName = username;
            Password = password;
            ID = id; 
        }
    }
}
