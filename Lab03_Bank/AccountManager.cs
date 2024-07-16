using System;
using System.Collections.Generic;

namespace UVUBank
{
    public class AccountManager
    {
        private Dictionary<string, IAccount> accounts = new Dictionary<string, IAccount>();

        public bool StoreAccount(IAccount account)
        {
            if (account == null) return false;
            if (accounts.ContainsKey(account.GetAccountNumber())) return false;

            accounts.Add(account.GetAccountNumber(), account);
            return true;
        }

        public IAccount FindAccountByNumber(string accountNumber)
        {
            accounts.TryGetValue(accountNumber, out IAccount account);
            return account;
        }

        public IAccount FindAccountByName(string name)
        {
            foreach (var account in accounts.Values)
            {
                if (account.GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return account;
                }
            }
            return null;
        }
    }
}
