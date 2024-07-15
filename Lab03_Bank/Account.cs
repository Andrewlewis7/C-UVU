using System;

namespace UVUBank
{
    /// <summary>
    /// Enumeration for account states
    /// </summary>
    public enum AccountState
    {
        New,
        Active,
        UnderAudit,
        Frozen,
        Closed
    }

    /// <summary>
    /// Enumeration for account types
    /// </summary>
    public enum AccountType
    {
        Savings,
        Checking,
        CD
    }

    /// <summary>
    /// Abstract Account class to manage individual bank accounts
    /// </summary>
    public abstract class Account : IAccount
    {
        private const decimal DefaultMinimumBalance = 100m;
        private const decimal DefaultServiceFee = 0m;

        private string name;
        private string address;
        private string accountNumber;
        private decimal balance;
        private AccountState state;
        private AccountType accountType;
        private decimal serviceFee;

        public Account(string name, string address, decimal balance, AccountType accountType)
        {
            if (!SetName(name) || !SetAddress(address) || !SetBalance(balance) || !SetAccountType(accountType))
            {
                throw new ArgumentException("Invalid account details");
            }
            this.accountNumber = GenerateAccountNumber(accountType);
            this.state = AccountState.New;
            this.serviceFee = DefaultServiceFee;
        }

        public bool SetName(string inName)
        {
            if (string.IsNullOrEmpty(inName))
            {
                return false;
            }
            name = inName;
            return true;
        }

        public string GetName()
        {
            return name;
        }

        public bool SetAddress(string inAddress)
        {
            if (string.IsNullOrEmpty(inAddress))
            {
                return false;
            }
            address = inAddress;
            return true;
        }

        public string GetAddress()
        {
            return address;
        }

        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public abstract bool SetBalance(decimal inBalance);

        public decimal GetBalance()
        {
            return balance;
        }

        protected void SetInitialBalance(decimal inBalance)
        {
            balance = inBalance;
        }

        public void PayInFunds(decimal amount)
        {
            balance += amount;
        }

        public bool WithdrawFunds(decimal amount)
        {
            if (balance - amount < 0)
            {
                return false;
            }
            balance -= amount;
            return true;
        }

        public void SetState(AccountState inState)
        {
            state = inState;
        }

        public AccountState GetState()
        {
            return state;
        }

        public virtual bool SetServiceFee(decimal fee)
        {
            serviceFee = fee;
            return true;
        }

        public decimal GetServiceFee()
        {
            return serviceFee;
        }

        public bool SetAccountType(AccountType inType)
        {
            accountType = inType;
            return true;
        }

        public AccountType GetAccountType()
        {
            return accountType;
        }

        private string GenerateAccountNumber(AccountType accountType)
        {
            Random random = new Random();
            string number = random.Next(100000, 999999).ToString();
            char typeChar = accountType switch
            {
                AccountType.Savings => 'S',
                AccountType.Checking => 'C',
                AccountType.CD => 'D',
                _ => throw new ArgumentOutOfRangeException()
            };
            return number + typeChar;
        }
    }
}
