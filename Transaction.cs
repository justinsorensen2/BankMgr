using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace BankMgr
{
  public class Transaction
  {
    public string User { get; set; }
    public double TransactionAmt { get; set; }
    public string TransactionType { get; set; }
    public DateTime When { get; set; }

    public List<Transaction> Transactions = new List<Transaction>();
    public void CreateTransaction(double amt, string loginId, List<Transaction> transList, string type)
    {
      var transaction = new Transaction
      {
        User = loginId,
        TransactionAmt = amt,
        TransactionType = type,
        When = DateTime.Now
      };
      transList.Add(transaction);
    }
    public void WriteTransaction(List<Transaction> transList)
    {
      var writer = new StreamWriter("Transactions.csv");
      var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
      csvWriter.WriteRecords(transList);
      writer.Flush();
    }
    public List<Transaction> ReadTransactions()
    {
      var transReader = new StreamReader("Transactions.csv");
      var transCsvReader = new CsvReader(transReader, CultureInfo.InvariantCulture);
      //create account list from data in csv
      var tempList = transCsvReader.GetRecords<Transaction>().ToList();
      return tempList;
    }
    public void DisplayTransactions(string loginId, List<Transaction> transList, string type)
    {

      var loggedInUserTrans = transList.Select(user => transList.User == loginId);
    }

  }

}


