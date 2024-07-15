namespace UVUBank
{
    /// <summary>
    /// Savings Account class
    /// </summary>
    public class SavingsAccount : Account
    {
        public SavingsAccount(string name, string address, decimal balance)
            : base(name, address, balance, AccountType.Savings)
        {
            SetServiceFee(0m);
        }

        public override bool SetBalance(decimal inBalance)
        {
            if (inBalance < 100m)
            {
                return false;
            }
            SetInitialBalance(inBalance);
            return true;
        }
    }
}
