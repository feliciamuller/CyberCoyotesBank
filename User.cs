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
       
        // Här ska man kunna välja vilket typ av konto man ska öppna
        // Sparkonto eller annat konto
        // Man ska välja valuta
        // På sparkonto ska man se hur mycket ränta jag får när jag sätter in pengar
        // Kontoöppnandet ska bli ett avtryck i historiken i loggen
        // Kontot ska få ett unikt Id
        public void CreateAccount()
        {
            Console.WriteLine("Ett konto är skapat för användare: " + UserName);
        }

        // Här ska man kunna låna pengar och se hur mycket ränta det blir på lånet
        // Lånet ska bli ett avtryck i historiken i loggen
        public void Loan()
        {
            Console.WriteLine("Lånet är beviljat för användare: " + UserName);
        }
    }
}
