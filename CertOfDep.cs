namespace Classes
{
    public class CertOfDep
    {
        private BankAccount account {get; set;}
        public decimal interest_rate { get; }
        private List<Transaction> transactionHistory = new List<Transaction> {};
        public decimal balance 
        {
            get
            {
              decimal balance = 0;

              foreach( var transaction in transactionHistory)
              {
                balance += transaction.Amount;
              }
              return balance;
            }
        }
    }
}