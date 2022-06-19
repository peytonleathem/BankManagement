using System;

namespace Classes;

public class BankAccount
{
    //Number id of bank account
    public string Number { get;}
    //Owner name
    public string Owner {get; set;}
    //Transaction history
    private List<Transaction> allTransactions = new List<Transaction>();
    //Calculate balance by traversing transaction history
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach(var item in allTransactions)
            {
                balance += item.Amount;
            }

        return balance;
        }
    }

    private static int accountNumberSeed = 1;

    //Virtual method for implementing interest- Used virtual so that I can make other accounts with different rates
    //Making this app is making me realize I don't know enough about banks and credit cards
    public virtual void CalculateMonthlyInterest()
    {
        if (Balance > 500m)
        {
            decimal interest = Balance * 0.05m;
            MakeDeposit(interest, DateTime.Now, "Apply monthly interest");
        }
    }

    //A method to make deposits-throws exceptions for negative deposits
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    //A method for making a withdrawal- throws an error for negative withdrawals and insufficient funds 
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
    if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
        }
        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Not sufficient funds for this withdrawal");
        }
        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
    }

    //An account history method- prints the account history and returns it as a formatted string to be operated on
    public List<string> GetAccountHistory()
    {
        List<string> history = new List<string> {};

        decimal balance = 0;

        history.Add($"Date\t\tAmount\tBalance\tNote");

        foreach (var item in allTransactions)
        {
            balance += item.Amount;
            history.Add($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }
        
        history.ForEach(h => Console.WriteLine(h));

        return history;
    }

    //Constructor for creation of a basic bank account
    public BankAccount(String name, decimal initialBalance)
    {
        Owner = name;
        Number = accountNumberSeed.ToString();
        accountNumberSeed++;

        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }
}


/*
                                             
                                                          .^^^^^^^:                                                          
                                                          .^^^^^^^:                                                          
                                                          .^^^^^^^:                                                          
                                                          .^^^^^^^.                                                          
                                                          .^^^^^^^.                                                          
                                                          :^^^^^^^.                                                          
                                                          :^^^^^^^.                                                          
                                                          :^^^^^^^.                                                          
                                                          :::::::^.                                                          
            ..::...                                                                                      ..::::.             
        ...    .:^^::.                                                                                .::^^:..   .:..        
      .:^:       .::^^^:.                             ....:::::::::....                            .::^^^:.       .:^:.      
    .:^^.           .:^^^::.                      .:::^^^^^^^^^^^^^^^^^:::.                      .:^^^:.            :^^:     
    :^^:              .::^^^:.                .::^^^^^^^^^^^^^^^^^^^^^^^^^^^::.               .:^^^::.              .^^^:    
   .^^^.                 .:^^^::.            .:^^^^^^^^^^^:::::::::^^^^^^^^^^^:.           ..:^^^:.                  :^^:    
   .^^^.                   .::^^^:.            .::^^^::...         ...::^^^::.           .:^^^::.                    :^^:    
   .^^^:                      .:^^^::.            ..                     ..           ..:^^^:.                      .^^^.    
    .^^^:                       ..:^^^:.                                            .:^^^::.                       .^^^:     
     .:^^:.                        .::^^:..                                       .:^^^:.                        .:^^^:      
      .:^^^:.                         .::^^:.                                  .:^^::.                         .:^^^:.       
        .::^^^:..                         .....           ........           .....                        ...::^^::.         
           ..:::::::..               ..:::::..         .::^^.  .^^^:.         ..::::::..               ..::::::...           
         ..                        .:^^^^^:.^^:.      :^^::.    .::^^:.      :^^:.^^^^^^:                         :.         
        :^.                       .^^^^^^^: .^^^.    :.              .:.    :^^: .^^^^^^^:                        :^.        
        ^^.                       .^^^^^^^:  :^^    .^:              :^:    .^^  .^^^^^^^.                        :^:        
        :^:.                       .:^^^^^.. .:.    .^^::          ::^^.     .: ..:^^^^:.                        :^^.        
         :^^:.                       ...:..^.        :^^:          :^^:         ::.....                        .^^:.         
          .:^^::..     ..                .^^.         .::   .:..   :^:          :^:.               .... ....::^^:.           
             .:::::::::..              .:^:.            .:::^^^^:::..            .:^:.              ..:::::::..              
                          ..:.......:::::.                 ......                  .::::::.....::.                           
                            ..::::::...    ..                                   ..     ...:::...                             
                                         .:^^:.                               .:^^:.                                         
                                      .:^^^^^^^:..                         ..:^^^^^^^:.                                      
                                       .:^^^^^^^^^:..                   ..:^^^^^^^^^:.                                       
                                         .:^^^^^^^^^^:::.............:::^^^^^^^^^^:.                                         
                                           .::^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^::.                                           
                                              .::^^^^^^^^^^^^^^^^^^^^^^^^^^^::.                                              
                                                  ..:::^^^^^^^^^^^^^^^:::..                                                  
                                                        .............   
*/