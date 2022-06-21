namespace Classes
{
    //Login struct to keep track of users and their login times, as well as any transactions performed by this particular login
    public struct LogIn
    {
        User User { get; set; }
        DateTime AccessDate { get; set; }
        List<Transaction> LoginTransactions = new List<Transaction>();

        public LogIn(User user, DateTime accessDate)
        {
            User = user;
            AccessDate = accessDate;
        }

    }

    //A struct to create a transaction- made readonly so transactions can't be altered after their creation. A transaction must be deleted by admin
    public readonly struct Transaction
{
    public decimal Amount { get; }
    public DateTime Date { get; }
    public string Notes { get; }

    public Transaction(decimal amount, DateTime date, string note)
    {
        Amount = amount;
        Date = date;
        Notes = note;
    }
}
}