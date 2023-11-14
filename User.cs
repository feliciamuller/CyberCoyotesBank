using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCoyotesBank
{
    internal class User : Admin
    {
        string logActivity;

        public User(string username, string password, int id) : base (username, password, id)
        {
            Username = username;
            Password = password;
            Id = id;
        }

        public string CreateAccount()
        {
           
            //här ska man kunna välja vilket typ av konto man ska öppna
            //sparkonto eller annat konto
            //man ska välja valuta
            //på sparkonto ska man se hur mycket ränta jag får när jag sätter in pengar
            //kontoöppnandet ska bli ett avtryck i historiken i loggen
            //kontot ska få ett unikt Id
            return logActivity;

        }

        public string Loan()
        {
            //här ska man kunna låna pengar och se hur mycket ränta det blir på lånet
            //lånet ska bli ett avtryck i historiken i loggen
            return logActivity;
        }

    }
}
