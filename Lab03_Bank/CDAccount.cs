namespace UVUBank
{
    /// <summary>
    /// Certificate of Deposit (CD) Account class
    /// </summary>
    public class CDAccount : Account
    {
        public CDAccount(string name, string address, decimal balance)
            : base(name, address, balance, AccountType.CD)
        {
            SetServiceFee(8m);
        }

        public override bool SetBalance(decimal inBalance)
        {
            if (inBalance < 500m)
            {
                return false;
            }
            SetInitialBalance(inBalance);
            return true;
        }

        public override bool SetServiceFee(decimal fee)
        {
            if (fee < 8m)
            {
                return false;
            }
            return base.SetServiceFee(fee);
        }
    }
}
