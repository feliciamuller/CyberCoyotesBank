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
       
        // Här ska man kunna låna pengar och se hur mycket ränta det blir på lånet
        // Lånet ska bli ett avtryck i historiken i loggen
        public void Loan()
        {
            Console.WriteLine("The application for a loan has been granted for the user: " + UserName);
        }
    }
}
