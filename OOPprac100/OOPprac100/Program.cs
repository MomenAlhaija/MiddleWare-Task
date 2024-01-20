using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace OOPprac100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var e = new BankAccount("A-128");
            e.Deposit(5000);
            Console.WriteLine(e.Balance);
            e.Withdraw(200);
            e.Withdraw(2000);
        }
    }
    public class BankAccount
    {
        private const decimal _MaxWithdraw = 1000;
        private readonly string _accNo;
        private decimal _balance;

        public BankAccount(string accNo)
        {
            _accNo = accNo;
        }

        public string AccountNumber => _accNo;
        public decimal Balance=>_balance;
       
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Rejected:Negative Amount");
                return;
            }

            _balance += amount;
            Log($"Accepted:{amount.ToString("C")} deposite");
        }
        public void Withdraw(decimal amount)
        {

            if (amount > _balance)
            {
                Console.WriteLine("Rejected:Drow grater than your Balance");
                return;
            }
            if(amount > _MaxWithdraw)
            {
                Console.WriteLine("Rejected: Drow grater than allowdraw");
                return;
            }

            _balance -= amount;
            Log($"Accepted:{amount.ToString("C")} Withdraw");
        }
    
        public void Log(string message)
        {
            var TimeStamp= DateTime.Now.ToString("yyyy-MM-dd");
            Console.WriteLine($"[{TimeStamp}] {message}");
            Console.WriteLine($"[{TimeStamp}] Balance info:Account No '{_accNo}' ,Balance:'{_balance.ToString("C")}'");

        }
    }
} 
