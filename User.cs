namespace Classes
{
    //A User class to define individual users
    public class User 
    {
        public string ID {get;}
        private static int id_Seed = 1;
        public string Name {get;}
        List<BankAccount> relatedAccounts = new List<BankAccount>();
        //May add some more sophisticated credit score methods later, depends on time
        public int CreditScore {get;}
        private string Password {get;}
        public string Email {get;}
        public List<string> UserInfo = new List<string>();

        public User(string name, int score, string pass, string email, List<string> info)
        {
            Name = name;
            CreditScore = score;
            Password = pass;
            Email = email;
            UserInfo = info;

            ID = id_Seed.ToString();
            id_Seed++;
        }

    }
}