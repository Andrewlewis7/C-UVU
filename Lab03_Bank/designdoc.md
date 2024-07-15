## UVUBank Design Document

### Account Class (Abstract)

**Purpose**: Serves as the base class for all account types.

**Fields**:
- `AccountNumber`: A unique alphanumeric identifier for the account.
- `Name`: The name of the account holder.
- `Address`: The address of the account holder.
- `Balance`: The current balance of the account.
- `Type`: The type of the account (Savings, Checking, CD).
- `ServiceFee`: The monthly service fee for the account.
- `State`: The state of the account (active, inactive, etc.).

**Methods**:
- `SetName(string inName)`: Sets the account holder's name.
- `GetName()`: Returns the account holder's name.
- `SetAddress(string inAddress)`: Sets the account holder's address.
- `GetAddress()`: Returns the account holder's address.
- `GetAccountNumber()`: Returns the account number.
- `SetBalance(decimal inBalance)`: Sets the account balance.
- `GetBalance()`: Returns the account balance.
- `PayInFunds(decimal amount)`: Adds funds to the account.
- `WithdrawFunds(decimal amount)`: Withdraws funds from the account.
- `SetState(AccountState inState)`: Sets the state of the account.
- `GetState()`: Returns the state of the account.
- `SetServiceFee(decimal fee)`: Sets the service fee.
- `GetServiceFee()`: Returns the service fee.
- `SetAccountType(AccountType inType)`: Sets the account type.
- `GetAccountType()`: Returns the account type.

### SavingsAccount Class (Inherits from Account)

**Purpose**: Represents a savings account.

**Constructor**:
- `SavingsAccount(string name, string address, decimal balance)`: Initializes a new savings account and enforces a minimum balance of $100.

**Overrides**:
- `SetBalance(decimal amount)`: Ensures the balance does not fall below $100.

### CheckingAccount Class (Inherits from Account)

**Purpose**: Represents a checking account.

**Constructor**:
- `CheckingAccount(string name, string address, decimal balance)`: Initializes a new checking account and enforces a minimum balance of $10.

**Overrides**:
- `SetBalance(decimal amount)`: Ensures the balance does not fall below $10.
- `SetServiceFee(decimal fee)`: Ensures the service fee is not less than $5.

### CDAccount Class (Inherits from Account)

**Purpose**: Represents a certificate of deposit account.

**Constructor**:
- `CDAccount(string name, string address, decimal balance)`: Initializes a new CD account and enforces a minimum balance of $500.

**Overrides**:
- `SetBalance(decimal amount)`: Ensures the balance does not fall below $500.
- `SetServiceFee(decimal fee)`: Ensures the service fee is not less than $8.

### AccountManager Class

**Purpose**: Manages the storage and retrieval of account information.

**Fields**:
- `accounts`: A dictionary that stores accounts with the account holder's name as the key.

**Methods**:
- `StoreAccount(IAccount account)`: Stores an account if it does not already exist.
- `FindAccount(string name)`: Finds and returns an account by the account holder's name.

### Program Class

**Purpose**: Provides a user interface for interacting with the system.

**Methods**:
- `Main(string[] args)`: The entry point of the program. Handles user input and performs account operations.
