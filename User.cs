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

        public void CreateAccount()
        {
            Console.WriteLine("Ett konto är skapat för användare: " + UserName);
        }

        public void Loan()
        {
            Console.WriteLine("Lånet är beviljat för användare: " + UserName);
        }
    }
}
