using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Labs
{
    class Account
    {
        private string name;
        private string password;
        private bool loggedIn;
        private double balance;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public bool LoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }


        public Account()
        {

        }

        public Account(string _name, string _password, bool _loggedIn, double _balance)
        {
            name = _name;
            password = _password;
            loggedIn = _loggedIn;
            balance = _balance;
        }
        
    }
}
