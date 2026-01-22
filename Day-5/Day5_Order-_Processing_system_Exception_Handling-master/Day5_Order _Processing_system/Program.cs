using System;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message) { }
}

public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message) { }
}

public class ExternalServiceException : Exception
{
    public ExternalServiceException(string message) : base(message) { }
}

//creating the logger class
public class Logger
{
    public static void Log(Exception ex)
    {
        Console.WriteLine($"[LOG] {DateTime.Now} | {ex.GetType().Name} | {ex.Message}");
    }
}

//create OrderService class
public class OrderService
{
    public void PlaceOrder(int quantity, bool paymentServiceDown, bool dbDown)
    {
        //  1) Validation Checks (User input)
        if (quantity <= 0)
            throw new ValidationException("Quantity must be greater than 0.");

        //  2) Business Rule Check (Stock rule)
        int availableStock = 5;
        if (quantity > availableStock)
            throw new BusinessRuleException("Insufficient stock available.");

        //  3) Business Rule Check (Payment failure)
        if (paymentServiceDown == true)
            throw new BusinessRuleException("Payment failed. Transaction declined.");

        //  4) External Service / DB Failure
        if (dbDown == true)
            throw new ExternalServiceException("Database failure occurred.");

        Console.WriteLine(" Order placed successfully!");
    }
}

class Program
{
    static void Main()
    {
        OrderService order = new OrderService();

        try
        {
            // Change values to test
            order.PlaceOrder(quantity: 0, paymentServiceDown: false, dbDown: false);
        }

        //  Validation errors should NOT be logged
        catch (ValidationException ex) when (LogIfRequired(ex) == false)
        {
            Console.WriteLine(" Validation error handled WITHOUT logging: " + ex.Message);
        }

        //  Business rule errors should be logged
        catch (BusinessRuleException ex) when (LogIfRequired(ex))
        {
            Console.WriteLine(" Business rule failure handled WITH logging: " + ex.Message);
        }

        //  External service errors should be logged
        catch (ExternalServiceException ex) when (LogIfRequired(ex))
        {
            Console.WriteLine(" External service failure handled WITH logging: " + ex.Message);
        }

        //  Catch-all fallback
        catch (Exception ex) when (LogIfRequired(ex))
        {
            Console.WriteLine(" Unknown critical exception logged.");
        }

        Console.WriteLine(" Program ended safely (No crash).");
    }

    // Instructor required function
    static bool LogIfRequired(Exception ex)
    {
        if (ex is ValidationException)
            return false;   //  skip logging

        Logger.Log(ex);      //  log critical
        return true;
    }
}
