namespace UVUBank
{
    /// <summary>
    /// Checking Account class
    /// </summary>
    public class CheckingAccount : Account
    {
        public CheckingAccount(string name, string address, decimal balance)
            : base(name, address, balance, AccountType.Checking)
        {
            SetServiceFee(5m);
        }

        public override bool SetBalance(decimal inBalance)
        {
            if (inBalance < 10m)
            {
                return false;
            }
            SetInitialBalance(inBalance);
            return true;
        }

        public override bool SetServiceFee(decimal fee)
        {
            if (fee < 5m)
            {
                return false;
            }
            return base.SetServiceFee(fee);
        }
    }
}
