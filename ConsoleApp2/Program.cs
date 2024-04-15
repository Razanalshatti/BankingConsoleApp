// See https://aka.ms/new-console-template for more information

/*

// task 1 setting up the account 

Console.WriteLine("Welcome to the Basic Banking Application \n-----------------------------\n");
Console.WriteLine("Enter your name:");
string name = Console.ReadLine();

Console.WriteLine("Enter Your Account number:");
int accountNumber = int.Parse(Console.ReadLine());

Console.WriteLine("Enter your blance amount:");
double balance = double.Parse(Console.ReadLine());

string username = name;
int userAccountnumber = accountNumber;
double userBalance = balance;

Console.WriteLine("\nAccount setup successful\n");
Console.WriteLine($"Name: {username}");
Console.WriteLine($"Account number: {userAccountnumber}");
Console.WriteLine($"Balance amount: {userBalance}");

// task 2 implementing user interactions
// task 3 recording transactions (adding a transaction history choice and display it)
// task 4 performing calculations 

const int maxTransaction = 50;
double[] transactions = new double[maxTransaction];
int transactionCount = 0;

int choice;
do
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Deposit");
    Console.WriteLine("2. Widthdraw");
    Console.WriteLine("3. View Balance:");
    Console.WriteLine("4. View Transaction History");
    Console.WriteLine("5. Exit");
    Console.WriteLine("\nEnter your choice:");
    choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Console.WriteLine("Enter your deposit amount: ");
        double depositAmount = double.Parse(Console.ReadLine());
        userBalance += depositAmount;
        transactions[transactionCount++] = userBalance;
        Console.WriteLine($"Deposit successful \nNew Balance: {userBalance}");
    }
    else if (choice == 2)
    {
        Console.WriteLine("Enter withdrawal amount: ");
        double withdrawalAmount = double.Parse(Console.ReadLine());
        if (withdrawalAmount <= userBalance)
        {
            userBalance -= withdrawalAmount;
            transactions[transactionCount++] = -withdrawalAmount;
            Console.WriteLine($"Withdrawal successful \nNew Balance: {userBalance}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
    else if (choice == 3)
    {
        Console.WriteLine($"Current Balance: {userBalance}");
    }
    else if (choice == 4)
    {
        Console.WriteLine("\nTransaction History:");
        for (int i = 0; i < transactionCount; i++)
        {
            Console.WriteLine(transactions[i] > 0 ? $"Deposit: +${transactions[i]}" : $"Withdrawal: -${-transactions[i]}");
        }
    }
    else if (choice != 5)
    {
        Console.WriteLine("Invalid choice. Please try again");
    }
} while (choice != 5);

Console.WriteLine("Thank you for using the banking system. \nGOODBYE!");

*/






using System;

class BankAccount
{
    // Encapsulated private members
    private string username;
    private int accountNumber;
    private double balance;
    private const int maxTransaction = 50;
    private double[] transactions = new double[maxTransaction];
    private int transactionCount = 0;

    // Constructor
    public BankAccount(string name, int accountNumber, double initialBalance)
    {
        this.username = name;
        this.accountNumber = accountNumber;
        this.balance = initialBalance;
    }

    // deposit money
    public void Deposit(double amount)
    {
        balance += amount;
        transactions[transactionCount++] = amount;
        Console.WriteLine($"Deposit successful \nNew Balance: {balance}");
    }

    // withdraw money
    public void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            transactions[transactionCount++] = -amount;
            Console.WriteLine($"Withdrawal successful \nNew Balance: {balance}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    // view balance
    public void ViewBalance()
    {
        Console.WriteLine($"Current Balance: {balance}");
    }

    // view transaction history
    public void ViewTransactionHistory()
    {
        Console.WriteLine("\nTransaction History:");
        for (int i = 0; i < transactionCount; i++)
        {
            Console.WriteLine(transactions[i] > 0 ? $"Deposit: +${transactions[i]}" : $"Withdrawal: -${-transactions[i]}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Basic Banking Application \n-----------------------------\n");
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Your Account number:");
        int accountNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter your balance amount:");
        double balance = double.Parse(Console.ReadLine());

        // Creating BankAccount object
        BankAccount account = new BankAccount(name, accountNumber, balance);

        int choice;
        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. View Balance:");
            Console.WriteLine("4. View Transaction History");
            Console.WriteLine("5. Exit");
            Console.WriteLine("\nEnter your choice:");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter your deposit amount: ");
                    double depositAmount = double.Parse(Console.ReadLine());
                    account.Deposit(depositAmount);
                    break;
                case 2:
                    Console.WriteLine("Enter withdrawal amount: ");
                    double withdrawalAmount = double.Parse(Console.ReadLine());
                    account.Withdraw(withdrawalAmount);
                    break;
                case 3:
                    account.ViewBalance();
                    break;
                case 4:
                    account.ViewTransactionHistory();
                    break;
                case 5:
                    Console.WriteLine("Thank you for using the banking system. \nGOODBYE!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again");
                    break;
            }
        } while (choice != 5);
    }
}