using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    public class BankAccount
    {
        public decimal Balance {  get; set; }   

        public event Action<decimal> BalanceChanged;
        
        
        public decimal Deposit(decimal amount)
        {
            Balance += amount;
            BalanceChanged?.Invoke(Balance); 
            return Balance;
        }
        public decimal Withdraw(decimal amount)
        {
            Balance -= amount;
            BalanceChanged?.Invoke(Balance);
            return Balance;
        }

    }
    public class Logger
    {
        public void Subscribe(BankAccount account)
        {
            account.BalanceChanged += ShowBalance;
        }
        private void ShowBalance(Decimal newBalance)
        {
            Console.WriteLine( "Новый баланс: "+ newBalance);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            Logger notify = new Logger();
            notify.Subscribe(account);
            account.Deposit(300);
            account.Withdraw(100);  
            
        }
    }
}
