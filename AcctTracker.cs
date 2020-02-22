using System;
using System.Collections.Generic;
using System.Linq;

namespace BankMgr
{

  public class AccountTracker
  {

    public List<AccountHolder> AccountHolders = new List<AccountHolder>();

    public string CheckUser(string loginId, List<AccountHolder> acctList)
    {
      //set var for while loop that checks username
      var checkingUser = true;
      //start while loop to check user
      while (checkingUser)
      {
        var loginTrue = acctList.Any(user => user.User == loginId);
        if (loginTrue == true)
        {
          checkingUser = false;
        }
        else
        {
          Console.WriteLine("That entry does not match an existing account.");
          Console.WriteLine("Please enter your user name.");
          loginId = Console.ReadLine();
        }
      }
      return loginId;
    }
    public void LogIn(string loginId, AccountHolder acct1)
    {
      //set var for while loop that runs password check
      var loggingIn = true;
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
    }
    public void DisplayAccount(AccountHolder acct1)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"User Name: {acct1.Name}");
      Console.WriteLine($"Checking Account Balance: ${acct1.CheckingBalance}");
      Console.WriteLine($"Savings Account Balance: ${acct1.SavingsBalance}");
      var total = acct1.CheckingBalance + acct1.SavingsBalance;
      Console.WriteLine($"Total Balance: ${total}");
      Console.ForegroundColor = ConsoleColor.White;
    }
    public void TransferToChecking(AccountHolder acct1, double amtToTransfer)
    {
      acct1.SavingsBalance = acct1.SavingsBalance - amtToTransfer;
      acct1.CheckingBalance = acct1.CheckingBalance + amtToTransfer;
    }
    public void TransferToSavings(AccountHolder acct1, double amtToTransfer)
    {
      acct1.CheckingBalance = acct1.CheckingBalance - amtToTransfer;
      acct1.SavingsBalance = acct1.SavingsBalance + amtToTransfer;
    }
    public void DepositToChecking(AccountHolder acct1, double amtToDeposit)
    {
      acct1.CheckingBalance = amtToDeposit + acct1.CheckingBalance;
    }

    public void DepositToSavings(AccountHolder acct1, double amtToDeposit)
    {
      acct1.SavingsBalance = amtToDeposit + acct1.SavingsBalance;
    }
    public void WithdrawFromChecking(AccountHolder acct1, double amtToWithdraw)
    {
      acct1.CheckingBalance = acct1.CheckingBalance - amtToWithdraw;
    }
    public void WithdrawFromSavings(AccountHolder acct1, double amtToWithdraw)
    {
      acct1.SavingsBalance = acct1.SavingsBalance - amtToWithdraw;
    }

  }

}