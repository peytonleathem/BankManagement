using System;

namespace Classes;

public class BankAccount
{
    public string Number { get;}
    public string Owner {get; set;}
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

    private static int accountNumberSeed = 1234567890;
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

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

    public void GetAccountHistory()
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
    }

    public BankAccount(String name, decimal initialBalance)
    {
        Owner = name;
        Number = accountNumberSeed.ToString();
        accountNumberSeed++;

        MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
    }

    private List<Transaction> allTransactions = new List<Transaction>();
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