using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Labs
{
    class ATM
    {
        private List<Account> accounts;

        public List<Account> Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }

        public ATM()
        {

        }

        public ATM(List<Account> _accounts)
        {
            accounts = _accounts;
        }

        public Account Register()
        {
            if (AccountLoggedIn())
            {
                LogOut();
            }
            bool loggedIn = false;
            
                string name = Program.GetUserInput("Enter the username of your account.");
                string password = Program.GetUserInput("Enter in a password.");
                double balance = 0.0;
                foreach (var account in accounts)
                {
                    if (name == account.Name || password == account.Password)
                    {
                        Console.WriteLine("There is already an account with this username or password.");
                    }
                }
                Account newAccount = new Account(name, password, loggedIn, balance);
                accounts.Add(newAccount);
                return newAccount;
            


        }

        public void LogIn()
        {

            string name = Program.GetUserInput("Enter in your username.");
            string password = Program.GetUserInput("Enter in your password.");

            foreach (var account in accounts)
            {
                if (account.LoggedIn)
                {
                    Console.WriteLine("There is already a logged on user. Please log out.");
                    //Add log out method here.
                }
                else if (account.Name == name && account.Password == password)
                {
                    account.LoggedIn = true;
                }
                else
                {

                }

            }

        }

        public void LogOut()
        {
            if (AccountLoggedIn())
            {
                foreach (var account in accounts)
                {
                    account.LoggedIn = false;
                }
            }
        }


        public bool AccountLoggedIn()
        {
            foreach (var account in accounts)
            {
                if (account.LoggedIn)
                {
                    return true;
                }
            }
            return false;
        }

        public double CheckBalance()
        {
            if (AccountLoggedIn())
            {
                foreach (var account in accounts)
                {
                    return account.Balance;
                }

            }
            return 0;
        }

        public void Deposit(double despoitAmount)
        {
            double newAmount = 0.0;
            if (AccountLoggedIn())
            {
                foreach (var account in accounts)
                {
                    newAmount = account.Balance + despoitAmount;
                    account.Balance = newAmount;
                }
            }
        }
        public void Withdraw(double withdrawAmount)
        {
            double newAmount = 0.0;
            if (AccountLoggedIn())
            {

                foreach (var account in accounts)
                {
                        newAmount = account.Balance - withdrawAmount;
                        account.Balance = newAmount;
                }

                double balance = CheckBalance();

                Console.WriteLine($"You've withdrawn ${withdrawAmount}. Your new balance is ${balance}.");
            }
            
        }








    }
}
