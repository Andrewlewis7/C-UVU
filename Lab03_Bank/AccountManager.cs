using System;
using System.Collections.Generic;

namespace UVUBank
{
    /// <summary>
    /// Class to manage accounts
    /// </summary>
    public class AccountManager
    {
        private Dictionary<string, IAccount> accounts = new Dictionary<string, IAccount>();

        public bool StoreAccount(IAccount account)
        {
            if (account == null || string.IsNullOrEmpty(account.GetName()))
            {
                return false;
            }
            accounts[account.GetName()] = account;
            return true;
        }

        public IAccount FindAccount(string name)
        {
            accounts.TryGetValue(name, out var account);
            return account;
        }
    }
}
