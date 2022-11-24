using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank
{
    enum AccountType
    {
        Checking,
        Individual,
        Corporate
    }
    class Account
    {
        string owner;
        float balance;
        AccountType ownerType;

        public Account(string ownerName, string aType)
        {
            owner = ownerName;
            balance = 0;
            switch (aType)
            {
                case "Checking":
                    ownerType = AccountType.Checking;
                    break;
                case "Individual":
                    ownerType = AccountType.Individual;
                    break;
                case "Corporate":
                    ownerType = AccountType.Corporate;
                    break;
                default:
                    ownerType = AccountType.Checking;
                    break;
            }
        }
        ~Account() { 
            Console.WriteLine("Account is being deleted");
        }

        public string getOwner()
        {
            return owner;
        }
        public float getBalance()
        {
            return balance;
        }

        public AccountType getAccountType()
        {
            return ownerType;
        }

        public void deposit(float deposit_amount)
        {
            balance += deposit_amount;
            Console.WriteLine("Deposit Success!\n" + owner +" Current balance is " + balance);
            return;
        }

        public void withdraw(float withdraw_amount)
        {
            if (withdraw_amount > balance)
            {
                Console.WriteLine("The balance is not enough to withdraw the money!");
                return;
            } else
            {
                if ( ownerType == AccountType.Individual && withdraw_amount > 500)
                {
                    Console.WriteLine("Individual Account can't withdraw more than 500, Please try again!");
                    return;
                } 

                balance -= withdraw_amount;
                Console.WriteLine("Withdraw Success! Current balance is " + balance);
                return;
            }
        }

        public void transfer(Account to, float transfer_amount)
        {
            if (transfer_amount > balance)
            {
                Console.WriteLine(owner + " Current balance is " + balance);
                Console.WriteLine("The balance is not enough to transfer the money!"+ "\n");
                return;
            }
            else
            {
                balance -= transfer_amount;
                to.balance += transfer_amount;
                Console.WriteLine("Transfer Success!\n" + owner + " Current balance is " + balance);
                return;
            }
        }


    }
    class Program
    {
        string bank_name = "simple bank";
        List<Account> AccountList = new List<Account>();
        static void Main(string[] args)
        {
            Program bank = new Program();
            Console.WriteLine("This is " + bank.bank_name);

            Account alice = new Account("alice", "Individual");
            Account bob = new Account("bob", "Checking");

            bank.AccountList.Add(alice);
            bank.AccountList.Add(bob);

            Console.WriteLine("Alice desposit $500!");
            alice.deposit(500);
            Console.WriteLine("Bob deposit $500!");
            bob.deposit(500);

            Console.WriteLine("Alice  transfer $400 to bob!");
            alice.transfer(bob,400);
            Console.WriteLine("bob try to  transfer $1000 to alice!");
            bob.transfer(alice, 1000);
            Console.WriteLine("bob transfer $700 to alice!");
            bob.transfer(alice, 700);

            Console.WriteLine("Alice try to withdraw $600");
            alice.withdraw(600);
            Console.WriteLine("Alice withdraw $400");
            alice.withdraw(400);
            Console.WriteLine("bob withdraw $200");
            alice.transfer(bob, 200);




        }
    }
}
