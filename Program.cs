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
      //set var for while loop that runs after login
      var isRunning = true;

      //welcome and ask for user name, then set var for loginId
      Console.WriteLine("Welcome to Suncoast Bank.");
      Console.WriteLine("Please enter your user name.");
      var loginId = Console.ReadLine();
      acctTracker.CheckUser(loginId, acctList);
      //use loginId set account to var
      var acct1 = acctList.First(user => user.User == loginId);
      acctTracker.LogIn(loginId, acct1);

      //Display account info
      acctTracker.DisplayAccount(acct1);
      //start while loop for user options
      while (isRunning)
      {
        var type = "";
        //display options to user
        Console.WriteLine("Deposit to Checking(1), Deposit to Savings(2), Withdraw from Savings(3),");
        Console.WriteLine("Withdraw from Checking(4), Transfer from Savings to Checking(5),");
        Console.WriteLine("Transfer from Checking to Savings(6), Display Balances(7),");
        Console.WriteLine("Display Transaction History(8), or Save and Exit(9)");
        Console.WriteLine("Please enter the number of your choice.");
        var input = Console.ReadLine();
        if (input == "9")
        {
          //quit and save
          var writer = new StreamWriter("Accounts.csv");
          var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
          csvWriter.WriteRecords(acctList);
          writer.Flush();
          transHistory.WriteTransaction(transList);
          isRunning = false;
        }
        else if (input == "8")
        {
          transHistory.DisplayTransactions(loginId, transList);
        }
        else if (input == "7")
        {
          //display balances
          acctTracker.DisplayAccount(acct1);

        }
        else if (input == "6")
        {
          //set type
          type = "transferred from Checking to Savings.";
          //transfer from checking to savings
          Console.WriteLine("How much would you like to transfer from Checking to Savings?");
          var amtToTransfer = double.Parse(Console.ReadLine());
          acctTracker.TransferToSavings(acct1, amtToTransfer);
          Console.WriteLine("Your transfer has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToTransfer, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList);
        }
        else if (input == "5")
        {
          //set type
          type = "transferred from Savings to Checking.";
          //tfr from savings to checking
          Console.WriteLine("How much would you like to transfer from Savings to Checking?");
          var amtToTransfer = double.Parse(Console.ReadLine());
          acctTracker.TransferToChecking(acct1, amtToTransfer);
          Console.WriteLine("Your transfer has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToTransfer, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList);
        }
        else if (input == "4")
        {
          //set type
          type = "withdrawn from Checking";
          //withdraw from checking
          Console.WriteLine("How much would you like to withdraw from Checking?");
          var amtToWithdraw = double.Parse(Console.ReadLine());
          acctTracker.WithdrawFromChecking(acct1, amtToWithdraw);
          Console.WriteLine("Your withdrawal has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToWithdraw, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList);
        }
        else if (input == "3")
        {
          //set type
          type = "withdrawn from Savings.";
          //withdraw from savings
          Console.WriteLine("How much would you like to withdraw from Savings?");
          var amtToWithdraw = double.Parse(Console.ReadLine());
          acctTracker.WithdrawFromSavings(acct1, amtToWithdraw);
          Console.WriteLine("Your withdrawal has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToWithdraw, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList);
        }
        else if (input == "2")
        {
          //set type
          type = "deposited to Savings.";
          //deposit to savings
          Console.WriteLine("How much would you like to deposit to Savings?");
          var amtToDeposit = double.Parse(Console.ReadLine());
          acctTracker.DepositToSavings(acct1, amtToDeposit);
          Console.WriteLine("Your deposit has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToDeposit, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList);
        }
        else if (input == "1")
        {
          //set type
          type = "deposited to Checking.";
          //deposit to checking
          Console.WriteLine("How much would you like to deposit to Checking?");
          var amtToDeposit = double.Parse(Console.ReadLine());
          acctTracker.DepositToChecking(acct1, amtToDeposit);
          Console.WriteLine("Your deposit has been completed.");
          acctTracker.DisplayAccount(acct1);
          transHistory.CreateTransaction(amtToDeposit, loginId, transList, type);
          transHistory.DisplayTransactions(loginId, transList);
        }

      }
      Console.WriteLine("Thank you for using Suncoast Bank. Goodbye.");
      Console.Clear();
    }
  }
}


