﻿using Classes;

class Program
{
    public static void Main()
    {
        var account = new BankAccount("Peyton", 1000);
        var account2 = new BankAccount("Pratt", 1200);
        Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance. ");
        Console.WriteLine($"Account {account2.Number} was created for {account2.Owner} with {account2.Balance} initial balance. ");

        account.MakeWithdrawal(500, DateTime.Now, "Rent Payment");
        Console.WriteLine(account.Balance);
        account.MakeDeposit(100, DateTime.Now, "Kawkie paid me back");
        Console.WriteLine(account.Balance);

        account.GetAccountHistory();
    }

}