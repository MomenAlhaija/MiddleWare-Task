using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var account = new SavingAccount();
            account.AccountNumber = "A_123";
            account.Balance = 5000;
            account.WithDraw(550);
            Console.WriteLine(account.Balance);

        }
        interface IBanKAccount
        {
            string AccountNumber { get; set; }
            decimal Balance { get; set; }

            void Deposit(decimal amount);
            void WithDraw(decimal amount);
        }
        public class CheckingAccount : IBanKAccount
        {
            public  string AccountNumber { get; set; }
            public  decimal Balance { get; set; }
            private const decimal DaillyWithDrow = 5000;
            public  void Deposit(decimal amount)
            {
                if (amount < 0)
                    throw new InvalidOperationException();
                Balance += amount;
            }
            public  void WithDraw(decimal amount)
            {
                if (amount < 0)
                    throw new InvalidOperationException();
                else if (amount > DaillyWithDrow)
                {
                    Console.WriteLine("You can not draw max from the Daily allow drow amount ");
                    throw new InvalidOperationException();
                }
                Balance -= amount;

            }


        }
        public class SavingAccount : IBanKAccount
        {
            private const decimal DaillyWithDrow = 2000;
            public string AccountNumber { get; set; }
            public decimal Balance { get; set; }
            public  void Deposit(decimal amount)
            {

                if (amount < 0)
                {
                    throw new InvalidOperationException();
                }
                Balance += amount;
            }

            public  void WithDraw(decimal amount)
            {
                if (amount < 0)
                    throw new InvalidOperationException();
                else if (amount > DaillyWithDrow)
                {
                    Console.WriteLine("You can not draw max from the Daily allow drow amount ");
                    throw new InvalidOperationException();
                }
                Balance -= amount;
            }
        }
    }
}


