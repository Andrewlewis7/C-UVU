namespace UVUBank
{
    /// <summary>
    /// Interface for Account class
    /// </summary>
    public interface IAccount
    {
        bool SetName(string inName);
        string GetName();
        bool SetAddress(string inAddress);
        string GetAddress();
        string GetAccountNumber();
        bool SetBalance(decimal inBalance);
        decimal GetBalance();
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        void SetState(AccountState inState);
        AccountState GetState();
        bool SetServiceFee(decimal fee);
        decimal GetServiceFee();
        bool SetAccountType(AccountType inType);
        AccountType GetAccountType();
    }
}
