using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace BankMgr
{
  class Program
  {
    static void Main()
    {

      //create tracker
      var acctTracker = new AccountTracker();
      //load data
      //create readers and read file
      var reader = new StreamReader("Accounts.csv");
      var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      //create account from data in csv
      var acctList = csvReader.GetRecords<AccountHolder>().ToList();
      // take list and set variables for user 1
      Console.WriteLine($"{acctList[0].ToString()}");
      var acct1 = acctList[0];

      //Display account info
      acctTracker.DisplayAccount(acct1);
      //set var for while loop
      var isRunning = true;

      while (isRunning)
      {
        //display options to user
        Console.WriteLine("Welcome to your BankU Account.");
        Console.WriteLine("Deposit to Checking(1), Deposit to Savings(2), Withdraw from Savings(3),");
        Console.WriteLine("Withdraw from Checking(4), Transfer from Savings to Checking(5),");
        Console.WriteLine("Transfer from Checking to Savings(6), Display Balances(7),");
        Console.WriteLine("or Save and Exit(8)");
        Console.WriteLine("Please enter the number of your choice.");
        var input = Console.ReadLine();
        if (input == "8")
        {
          //quit and save
          var writer = new StreamWriter("Accounts.csv");
          var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
          csvWriter.WriteRecords(acctList);
          writer.Flush();
          isRunning = false;
        }
        else if (input == "7")
        {
          //display balances
          acctTracker.DisplayAccount(acct1);

        }
        else if (input == "6")
        {
          //transfer from checking to savings
          Console.WriteLine("How much would you like to transfer from Checking to Savings?");
          var amtToTransfer = double.Parse(Console.ReadLine());
          acctTracker.TransferToSavings(acct1, amtToTransfer);
          Console.WriteLine("Your transfer has been completed.");
          acctTracker.DisplayAccount(acct1);
        }
        else if (input == "5")
        {
          //tfr from savings to checking
          Console.WriteLine("How much would you like to transfer from Savings to Checking?");
          var amtToTransfer = double.Parse(Console.ReadLine());
          acctTracker.TransferToChecking(acct1, amtToTransfer);
          Console.WriteLine("Your transfer has been completed.");
          acctTracker.DisplayAccount(acct1);
        }
        else if (input == "4")
        {
          //withdraw from checking
          Console.WriteLine("How much would you like to withdraw from Checking?");
          var amtToWithdraw = double.Parse(Console.ReadLine());
          acctTracker.WithdrawFromChecking(acct1, amtToWithdraw);
          Console.WriteLine("Your withdrawal has been completed.");
          acctTracker.DisplayAccount(acct1);
        }
        else if (input == "3")
        {
          //withdraw from savings
          Console.WriteLine("How much would you like to withdraw from Savings?");
          var amtToWithdraw = double.Parse(Console.ReadLine());
          acctTracker.WithdrawFromSavings(acct1, amtToWithdraw);
          Console.WriteLine("Your withdrawal has been completed.");
          acctTracker.DisplayAccount(acct1);
        }
        else if (input == "2")
        {
          //deposit to savings
          Console.WriteLine("How much would you like to deposit to Savings?");
          var amtToDeposit = double.Parse(Console.ReadLine());
          acctTracker.DepositToSavings(acct1, amtToDeposit);
          Console.WriteLine("Your deposit has been completed.");
          acctTracker.DisplayAccount(acct1);
        }
        else if (input == "1")
        {
          //deposit to checking
          Console.WriteLine("How much would you like to deposit to Checking?");
          var amtToDeposit = double.Parse(Console.ReadLine());
          acctTracker.DepositToChecking(acct1, amtToDeposit);
          Console.WriteLine("Your deposit has been completed.");
          acctTracker.DisplayAccount(acct1);
        }

      }
      Console.WriteLine("Thank you for using BankU. Goodbye.");
    }
  }
}


