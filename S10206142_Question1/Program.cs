using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace S10206142_Question1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SavingsAccount> savingsAccList = new List<SavingsAccount>();
            InitSavingsAccList(savingsAccList);
            while (true)
            {
                DisplayMenu();
                Console.WriteLine("Enter option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine("{0,20}{1,20}{2,20}{3,20}", "Acc No", "Acc Name", "Balance", "Rate");
                    foreach (SavingsAccount sa in savingsAccList)
                    {
                        Console.WriteLine("{0,20}{1,20}{2,20}{3,20}", sa.AccNo, sa.AccName, sa.Balance, sa.Rate);
                    }
                    Console.WriteLine(" ");
                }
                if (option == "2")
                {
                    Console.WriteLine("Enter the account number: ");
                    string search = Console.ReadLine();
                    SavingsAccount accountNo = SearchAcc(savingsAccList, search);
                    if (accountNo == null)
                    {
                        Console.WriteLine("Unable to find account number. Please try again.");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Console.WriteLine("Enter amount to deposit: ");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        accountNo.Deposit(amount);
                        Console.WriteLine("${0} deposited successfully.", amount);
                        Console.WriteLine("{0,20}{1,20}{2,20}{3,20}", "Acc No", "Acc Name", "Balance", "Rate");
                        Console.WriteLine("{0,20}{1,20}{2,20}{3,20}", accountNo.AccNo, accountNo.AccName, accountNo.Balance, accountNo.Rate);
                        Console.WriteLine(" ");
                    }
                }
                if (option == "3")
                {
                    Console.WriteLine("Enter the account number: ");
                    string search = Console.ReadLine();
                    SavingsAccount withNo = SearchAcc(savingsAccList, search);
                    if (withNo == null)
                    {
                        Console.WriteLine("Unable to find account number. Please try again.");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Console.WriteLine("Enter amount to withdraw: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        if (withNo.Withdraw(amount) == true)
                        {
                            Console.WriteLine("${0} withdrawn successfully.");
                            Console.WriteLine("{0,20}{1,20}{2,20}{3,20}", "Acc No", "Acc Name", "Balance", "Rate");
                            Console.WriteLine("{0,20}{1,20}{2,20}{3,20}", withNo.AccNo, withNo.AccName, withNo.Balance, withNo.Rate);
                            Console.WriteLine(" ");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient funds.");
                        }
                    }
                }
                if (option == "0")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
            }
        }
        static void DisplayMenu()
        {
            Console.WriteLine("[1] Display All Accounts");
            Console.WriteLine("[2] Deposit");
            Console.WriteLine("[3] Withdraw");
            Console.WriteLine("[0] Exit ");
        }
        static void InitSavingsAccList(List<SavingsAccount> savingsAccList)
        {
            using (StreamReader sr = new StreamReader("savings_account(2).csv"))
            {
                string s = sr.ReadLine();
                string[] head = s.Split(',');

                while ((s = sr.ReadLine()) != null)
                {
                    string[] info = s.Split(',');
                    SavingsAccount accs = new SavingsAccount(info[0], info[1], Convert.ToDouble(info[2]), Convert.ToDouble(info[3]));
                    savingsAccList.Add(accs);
                }
            }
        }
         static SavingsAccount SearchAcc(List<SavingsAccount> sList, string accNo)
        {
            foreach (SavingsAccount sa in sList)
            {
                if (sa.AccNo == accNo)
                {
                    return sa;
                }
            }
            return null;
        }   
    }
}
