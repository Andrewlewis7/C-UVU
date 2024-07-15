+---------------------+                +---------------------+
|     <<interface>>   |                |      Account        |
|       IAccount      |<---------------|---------------------|
|---------------------|                | - AccountNumber:    |
| + SetName(string)   |                |   string            |
| + GetName(): string |                | - Name: string      |
| + SetAddress(string)|                | - Address: string   |
| + GetAddress():     |                | - Balance: decimal  |
|   string            |                | - Type: AccountType |
| + SetBalance(decimal)|               | - ServiceFee:       |
| + GetBalance():     |                |   decimal           |
|   decimal           |                | - State: AccountState|
| + PayInFunds(decimal)|               |---------------------|
| + WithdrawFunds     |                | + SetName(string):  |
|   (decimal): bool   |                |   bool              |
| + SetState(AccountState)|            | + GetName(): string |
| + GetState():       |                | + SetAddress(string):|
|   AccountState      |                |   bool              |
| + SetServiceFee     |                | + GetAddress():     |
|   (decimal): bool   |                |   string            |
| + GetServiceFee():  |                | + GetAccountNumber():|
|   decimal           |                |   string            |
| + SetAccountType    |                | + SetBalance(decimal):|
|   (AccountType): bool|               |   bool              |
| + GetAccountType(): |                | + GetBalance():     |
|   AccountType       |                |   decimal           |
|                     |                | + PayInFunds(decimal)|
|                     |                | + WithdrawFunds     |
|                     |                |   (decimal): bool   |
|                     |                | + SetState          |
|                     |                |   (AccountState)    |
|                     |                | + GetState():       |
|                     |                |   AccountState      |
|                     |                | + SetServiceFee     |
|                     |                |   (decimal): bool   |
|                     |                | + GetServiceFee():  |
|                     |                |   decimal           |
|                     |                | + SetAccountType    |
|                     |                |   (AccountType): bool|
|                     |                | + GetAccountType(): |
|                     |                |   AccountType       |
+---------------------+                +---------------------+
            ^                                      ^
            |                                      |
            |                                      |
+---------------------+            +---------------------+           +---------------------+
|  SavingsAccount     |            |   CheckingAccount   |           |      CDAccount      |
|---------------------|            |---------------------|           |---------------------|
| + SetBalance(decimal):|          | + SetBalance(decimal):|         | + SetBalance(decimal):|
|   bool              |            |   bool              |           |   bool              |
+---------------------+            | + SetServiceFee     |           | + SetServiceFee     |
                                   |   (decimal): bool   |           |   (decimal): bool   |
                                   +---------------------+           +---------------------+
                                                |
+---------------------+                         |
|   AccountManager    |                         |
|---------------------|                         |
| - accounts:         |                         |
|   Dictionary<string,|                         |
|   IAccount>         |                         |
|---------------------|                         |
| + StoreAccount(IAccount)|                     |
|   : bool           |                          |
| + FindAccount(string)|                        |
|   : IAccount       |                          |
+---------------------+
