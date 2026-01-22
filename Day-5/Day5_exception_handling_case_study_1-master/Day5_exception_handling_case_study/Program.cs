using System;

public class DailyLimitExceededException : Exception
{
    // Custom exception class for Daily Limit Violation
    // Derived from System.Exception

    public DailyLimitExceededException(string message) : base(message)
    {
        // Calling base class constructor
    }
}

public class BankAccount
{
    private decimal dailyLimit = 1000m;          // daily transaction limit
    private decimal totalTransactionsToday = 0m; // track today's total transactions

    public void MakeTransaction(decimal amount)
    {
        // Check Daily Limit Business Rule
        if (totalTransactionsToday + amount > dailyLimit)
        {
            // Throw custom exception
            throw new DailyLimitExceededException("Daily transaction limit exceeded.");
        }

        totalTransactionsToday += amount;
        Console.WriteLine($" Transaction of {amount} completed successfully.");
    }
}

class Program
{
    static void Main()
    {
        BankAccount acc = new BankAccount();

        try
        {
            acc.MakeTransaction(501);
            acc.MakeTransaction(500); // will exceed 1000
        }
        catch (DailyLimitExceededException ex)
        {
            Console.WriteLine("Transaction Failed: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected Error: " + ex.Message);
        }
    }
}
