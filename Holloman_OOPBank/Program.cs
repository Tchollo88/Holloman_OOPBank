using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Holloman_OOPBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account(); 
        }

        static void Account()
        {
            decimal Withdrawal = 0m;
            decimal Deposite = 0m;
            decimal Balance = 0m;

            Bank OOP = new Bank(Withdrawal, Deposite);

            AccountMenu(OOP, Withdrawal, Deposite, Balance);
        }
        static void AccountMenu(Bank alpha, decimal Withdrawal, decimal Deposit, decimal Balance)
        {
            MenuIntro();
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key != ConsoleKey.D && key.Key != ConsoleKey.W && key.Key != ConsoleKey.B && key.Key != ConsoleKey.Q)
            {
                Console.Clear();
                Console.WriteLine("Sorry, but you need to enter, either (D), (W), (B) or (Q) to continue...");
                Console.WriteLine("Please hit enter and try again. Thank you!");
                Console.Clear();
                MenuIntro();
            }

            if(key.Key == ConsoleKey.D)
            {
                Console.Clear();
                MakeDeposit(alpha, key, Withdrawal, Deposit, Balance);
            }

            if(key.Key == ConsoleKey.W)
            {
                Console.Clear();
                MakeWithdrawal(alpha, key, Withdrawal, Withdrawal, Balance);
            }
            
            if (key.Key == ConsoleKey.B)
            {
                Console.Clear();

                if(Balance < 0)
                {
                    Console.WriteLine("Your current balance is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-$" + Balance);
                    Console.ResetColor();
                }
                if(Balance > 0)
                {
                    Console.WriteLine("Your current balance is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("$" + Balance);
                    Console.ResetColor();
                }
                
            }

            if (key.Key == ConsoleKey.Q)
            {
                return;
            }
        }

        public static void SubMenu(Bank alpha, ConsoleKeyInfo key, decimal Withdrawal, decimal Deposit, decimal Balance)
        {
            if (key.Key == ConsoleKey.W)
            {
                SubMenuIntro();
                ConsoleKeyInfo subkey = Console.ReadKey();

                if (subkey.Key != ConsoleKey.C && subkey.Key != ConsoleKey.R)
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, but you need to enter, either (C) or (R) to continue...");
                    Console.WriteLine("Please hit enter and try again. Thank you!");
                    Console.Clear();
                    Console.ReadLine();
                    SubMenu(alpha, key, Withdrawal, Deposit, Balance);
                }
                if (subkey.Key == ConsoleKey.C)
                {
                    Console.Clear();
                    MakeWithdrawal(alpha, key, Withdrawal, Withdrawal, Balance);
                }
                if (subkey.Key == ConsoleKey.R)
                {
                    AccountMenu(alpha, Withdrawal, Deposit, Balance);
                }
            }
            if(key.Key == ConsoleKey.D)
            {
                SubMenuIntro();
                ConsoleKeyInfo subkey = Console.ReadKey();

                if (subkey.Key != ConsoleKey.C && subkey.Key != ConsoleKey.R)
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, but you need to enter, either (C) or (R) to continue...");
                    Console.WriteLine("Please hit enter and try again. Thank you!");
                    Console.ReadLine();
                    SubMenu(alpha, key, Withdrawal, Deposit, Balance);
                }
                if (subkey.Key == ConsoleKey.C)
                {
                    Console.Clear();
                    MakeDeposit(alpha, key, Withdrawal, Deposit, Balance);
                }
                if (subkey.Key == ConsoleKey.R)
                {
                    Console.Clear();
                    AccountMenu(alpha, Withdrawal, Deposit, Balance);
                }
            }
        }

        public static void MenuIntro()
        {
            Console.WriteLine
              ("Welcome to the OOPBank, please enter one of the following options: \n (D)eposite, (W)ithdraw, (B)alance, or (Q)uit");
        }

        public static void SubMenuIntro()
        {
            Console.WriteLine("What would you like to do next? \n (C)ontinue or (R)eturn");
        }

        public static void FinishLog()
        {
            Console.WriteLine("Thank you for using OOP Bank today, please come again!");
            Console.WriteLine("Please hit enter to go back to the main menu....");
            Console.ReadLine();
        }

        public static void MakeWithdrawal(Bank alpha, ConsoleKeyInfo key, decimal Withdrawal, decimal Deposit, decimal Balance)
        {
            Console.WriteLine("Please enter the amount you would like to withdraw: ");
            Withdrawal = decimal.Parse(Console.ReadLine());
            Balance = alpha.SetBalance();

            Balance = CalculateWithdrawal(alpha, Withdrawal, Balance);
            if (Balance < 0)
            {
                
                
                Balance = alpha.NegativeBalance(Balance);
                Console.WriteLine("Your money has been withdrawn, \nYour new account balance is:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-$" + Balance);
                Console.ResetColor();

                //if (Withdrawal > Balance && Balance < 0 && Balance < -1000)
                //{
                //    Balance = alpha.NegativeBalance(Balance);
                //    Console.WriteLine
                //        ("Your account has been overdrawn passed the allowable amount, \nplease report to the nearest teller and balance your account!");
                //    Console.WriteLine("Your account currently stands: ");
                //    Console.ForegroundColor = ConsoleColor.Red;
                //    Console.WriteLine("-$" + Balance);
                //    Console.ResetColor();
                //    FinishLog();
                //    AccountMenu(alpha, Withdrawal, Deposit, Balance);
                //}

                SubMenu(alpha, key, Withdrawal, Deposit, Balance); 
            }
            else if(Balance >= 0)
            {
                Console.WriteLine("Your money has been withdrawn, \nYour new account balance is:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("$" + Balance);
                Console.ResetColor();
                SubMenu(alpha, key, Withdrawal, Deposit, Balance);
            }

        }

        public static void MakeDeposit(Bank alpha, ConsoleKeyInfo key, decimal Withdrawal, decimal Deposit, decimal Balance)
        {
            Console.WriteLine("Please enter the amount you would like to deposite: ");
            Deposit = decimal.Parse(Console.ReadLine());

            if(Deposit > 500)
            {
                Console.Clear();

                Deposit = 500;
                Balance = CalculateDeposit(alpha, Deposit, Balance);

                Console.WriteLine("We are only able to deposite up to $500 max in a single deposite. \n $500 has been added to your acount.");
                
                Console.WriteLine("Your new balance is: " );
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("$" + Balance);
                Console.ResetColor();
                SubMenu(alpha, key, Withdrawal, Deposit, Balance);
            }
            else
            {
                Balance = CalculateDeposit(alpha, Deposit, Balance);
                Console.WriteLine("Your new balance is: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("$" + Balance);
                Console.ResetColor();
                SubMenu(alpha, key, Withdrawal, Deposit, Balance);
            }
        }

        public static decimal CalculateWithdrawal(Bank alpha, decimal WD, decimal Bal)
        {
            //alpha.BalanceWithdrawal = WD;
            //WD = alpha.BalanceWithdrawal;
            Bal = alpha.WithdrawMoney(WD);

            return Bal;
        }

        public static decimal CalculateDeposit(Bank alpha, decimal DP, decimal Bal)
        {
            //alpha.BalanceDeposite = DP;
            //DP = alpha.BalanceDeposite;
            Bal = alpha.DepositeMoney(DP);

            return Bal;
        }
    }
}
