using System;
using System.Collections.Generic;


namespace BankMgr
{

  public class AccountTracker
  {

    public List<AccountHolder> AccountHolders = new List<AccountHolder>();


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