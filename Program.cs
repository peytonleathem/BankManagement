using Classes;

class Program
{
    public static void Main()
    {
        User temp1 = new User("Peyton Leathem", 1000, "testingPass", "testing123@gmail.com", new List<string> {"Testing"});
        User temp2 = new User("Pratt Hayes", 1000, "testingPass", "testing123@gmail.com", new List<string> {"Testing", "My very grumpy but very beloved grandfather"});
        var account = new BankAccount(temp1, 1000);
        var account2 = new BankAccount(temp2, 1200);
        Console.WriteLine($"Account {account.Number} was created for {account.Owner.Name} with {account.Balance} initial balance. ");
        Console.WriteLine($"Account {account2.Number} was created for {account2.Owner.Name} with {account2.Balance} initial balance. ");

        account.MakeWithdrawal(500, DateTime.Now, "Rent Payment");
        Console.WriteLine(account.Balance);
        account.MakeDeposit(100, DateTime.Now, "Kawkie paid me back");
        Console.WriteLine(account.Balance);

        account.GetAccountHistory();
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