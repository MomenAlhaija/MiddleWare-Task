using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            BanKAccount account = new SavingAccount();
            account.AccountNumber = "A_123";
            account.Balance = 5000;
            account.WithDraw(550);
            Console.WriteLine(account.Balance);

        }
        public abstract class BanKAccount
        {
            public string AccountNumber { get; set; }
            public decimal Balance { get; set; }
            public abstract void Deposit(decimal amount);
            public abstract void WithDraw(decimal amount);
        }
        public class CheckingAccount:BanKAccount
        {
            private const decimal DaillyWithDrow = 5000;
            public override void Deposit(decimal amount)
            {

                if (amount < 0)
                {
                    throw new InvalidOperationException();
                }
                Balance += amount;
            }
            public override void WithDraw(decimal amount)
            {
                if(amount<0)
                    throw new InvalidOperationException();
                else if (amount > DaillyWithDrow)
                {
                    Console.WriteLine("You can not draw max from the Daily allow drow amount ");
                    throw new InvalidOperationException();
                }
                Balance -= amount;
                
            }


        }
        public class SavingAccount : BanKAccount
        {
            private const decimal DaillyWithDrow = 2000;

            public override void Deposit(decimal amount)
            {

                if (amount < 0)
                {
                    throw new InvalidOperationException();
                }
                Balance += amount;
            }

            public override void WithDraw(decimal amount)
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
