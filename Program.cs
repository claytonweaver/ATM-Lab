using System;
using System.Collections.Generic;

namespace ATM_Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            ATM atm = new ATM(accounts);

            bool resume = false;
            bool resume2 = false;
            string mainMenu = "Do you want to go back to the main menu? (y/n)";
            string accountMenu = "Would you like to return to your account menu? (y/n)";
            string tryAgain = "Do you want to try again? (y/n)";
            

                do
                {
                try
                {
                    ShowMainMenu();
                    int userInput = int.Parse(GetUserInput("What would you like to do? (Enter a number between 1 and 3)."));
                    if (userInput == 1)
                    {
                        atm.LogIn();

                        if (atm.AccountLoggedIn())
                        {
                            //Second do while loop (the account layer)
                            do
                            {

                                ShowAccountMenu();
                                int userInput2 = int.Parse(GetUserInput("What would you like to do? (Enter a number between 1 and 5)."));
                                if (userInput2 == 1)
                                {
                                    double userAmount = int.Parse(GetUserInput("How much would you like to withdrawal?"));
                                    double balance = atm.CheckBalance();
                                    if (balance > 0)
                                    {
                                        atm.Withdraw(userAmount);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Insufficient funds.");
                                    }
                                    resume2 = AskToTryAgain(GetUserInput(accountMenu)); 
                                }
                                else if (userInput2 == 2)
                                {
                                    double userAmount = int.Parse(GetUserInput("How much would you like to deposit?"));
                                    atm.Deposit(userAmount);
                                    resume2 = AskToTryAgain(GetUserInput(accountMenu));
                                }
                                else if (userInput2 == 3)
                                {
                                    double balance = atm.CheckBalance();
                                    Console.WriteLine($"Your balance is ${balance}");
                                    resume2 = AskToTryAgain(GetUserInput(accountMenu));

                                }
                                else if (userInput2 == 4)
                                {
                                    atm.LogOut();
                                    resume2 = false;
                                }
                                else
                                {
                                    resume2 = false;
                                }


                            } while (resume2);
                        }
                        else
                        {
                            resume = AskToTryAgain(GetUserInput(tryAgain));
                        }
                    }
                    else if(userInput == 2)
                    {
                        atm.Register();
                        resume = AskToTryAgain(GetUserInput(mainMenu));

                    }
                    else if(userInput == 3)
                    {
                        resume = false;
                    }
                    else
                    {
                        resume = AskToTryAgain(GetUserInput(mainMenu));

                    }
                }
                catch (Exception)
                {

                    resume = AskToTryAgain(GetUserInput(tryAgain));
                }
                    
                } while (resume);
            
            
        }



        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static bool AskToTryAgain(string input)
        {
            try
            {
                if (input.ToLower()[0] == 'y')
                    return true;
                else if (input.ToLower()[0] == 'n')
                    return false;
                else
                    Console.WriteLine("Wrong input. Would you like to try again? (y/n)");
                string input2 = Console.ReadLine();
                AskToTryAgain(input2);
            }
            catch (StackOverflowException)
            {
                string userError = GetUserInput("That's not right. Try again: 'y' or 'n'");
                AskToTryAgain(userError);
            }
            return true;
        }
        public static void ShowMainMenu()
        {
            Console.WriteLine("Welcome to Bank of Clay's ATM!");
            Console.WriteLine();
            Console.WriteLine("     1. Log In");
            Console.WriteLine("     2. Create Account");
            Console.WriteLine("     3. Quit");
            Console.WriteLine();
        }
        public static void ShowAccountMenu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("     1. Withdraw");
            Console.WriteLine("     2. Deposit");
            Console.WriteLine("     3. Check Balance");
            Console.WriteLine("     4. Log Out");
            Console.WriteLine("     5. Main Menu");
            Console.WriteLine();
        }
    }
}
