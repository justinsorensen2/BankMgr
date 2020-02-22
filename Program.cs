﻿using System;
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
      //create transaction tracker var
      var transHistory = new Transaction();
      //load data
      //create readers and read accounts
      var reader = new StreamReader("Accounts.csv");
      var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      //create account list from data in csv
      var acctList = csvReader.GetRecords<AccountHolder>().ToList();
      //call read transactions method
      var transList = transHistory.ReadTransactions();
      //set var for while loop that runs login
      var loggingIn = true;
      //set var for while loop that runs after login
      var isRunning = true;

      //welcome and ask for user name
      Console.WriteLine("Welcome to Suncoast Bank.");
      Console.WriteLine("Please enter your user name.");
      var loginId = Console.ReadLine();
      //check login ID against acctlist and set account to var
      var acct1 = acctList.First(user => user.User == loginId);


      while (loggingIn)
      {
        //ask for password, and start if based on veracity of input
        Console.WriteLine($"Hello, {acct1.Name}. Please enter your password.");
        var password = Console.ReadLine();
        if (password == acct1.Password)
        {
          Console.WriteLine("Login successful.");
          loggingIn = false;
        }
        else
        {
          Console.WriteLine("Incorrect username/password combination. Please try again.");
        }
      }
      while (isRunning)
      {
        var type = "";
        //Display account info
        acctTracker.DisplayAccount(acct1);
        //display options to user
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
          //set type
          type = "from Checking to Savings.";
          //transfer from checking to savings
          Console.WriteLine("How much would you like to transfer from Checking to Savings?");
          var amtToTransfer = double.Parse(Console.ReadLine());
          acctTracker.TransferToSavings(acct1, amtToTransfer);
          Console.WriteLine("Your transfer has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToTransfer, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList, type);
        }
        else if (input == "5")
        {
          //set type
          type = "from Savings to Checking.";
          //tfr from savings to checking
          Console.WriteLine("How much would you like to transfer from Savings to Checking?");
          var amtToTransfer = double.Parse(Console.ReadLine());
          acctTracker.TransferToChecking(acct1, amtToTransfer);
          Console.WriteLine("Your transfer has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToTransfer, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList, type);
        }
        else if (input == "4")
        {
          //set type
          type = "from Checking";
          //withdraw from checking
          Console.WriteLine("How much would you like to withdraw from Checking?");
          var amtToWithdraw = double.Parse(Console.ReadLine());
          acctTracker.WithdrawFromChecking(acct1, amtToWithdraw);
          Console.WriteLine("Your withdrawal has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToWithdraw, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList, type);
        }
        else if (input == "3")
        {
          //set type
          type = "from Savings.";
          //withdraw from savings
          Console.WriteLine("How much would you like to withdraw from Savings?");
          var amtToWithdraw = double.Parse(Console.ReadLine());
          acctTracker.WithdrawFromSavings(acct1, amtToWithdraw);
          Console.WriteLine("Your withdrawal has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToWithdraw, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList, type);
        }
        else if (input == "2")
        {
          //set type
          type = "to Savings.";
          //deposit to savings
          Console.WriteLine("How much would you like to deposit to Savings?");
          var amtToDeposit = double.Parse(Console.ReadLine());
          acctTracker.DepositToSavings(acct1, amtToDeposit);
          Console.WriteLine("Your deposit has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToDeposit, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList, type);
        }
        else if (input == "1")
        {
          //set type
          type = "to Checking,";
          //deposit to checking
          Console.WriteLine("How much would you like to deposit to Checking?");
          var amtToDeposit = double.Parse(Console.ReadLine());
          acctTracker.DepositToChecking(acct1, amtToDeposit);
          Console.WriteLine("Your deposit has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToDeposit, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList, type);
        }

      }
      Console.WriteLine("Thank you for using Suncoast Bank. Goodbye.");
      Console.Clear();
    }
  }
}


