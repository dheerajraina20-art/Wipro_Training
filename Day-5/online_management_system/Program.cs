using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_management_system
{
    using System;

    // Step 1: Enum for OrderStatus
    enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    // Step 2: Struct for Location (Latitude + Longitude)
    struct Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"Latitude: {Latitude}, Longitude: {Longitude}";
        }
    }

    // Step 3: Interface for Payment contract
    interface IPayment
    {
        void ProcessPayment(double amount);
        void RefundPayment(double amount);
        bool MakePayment(double amount);
    }

    // Step 3 Extension: Credit Card Payment class
    class CreditCardPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing Credit Card payment of {amount}...");
        }

        public void RefundPayment(double amount)
        {
            Console.WriteLine($"Refunding {amount} to Credit Card...");
        }

        public bool MakePayment(double amount)
        {
            ProcessPayment(amount);
            Console.WriteLine("Credit Card Payment Successful ");
            return true;
        }
    }

    // Step 3 Extension: Debit Card Payment class
    class DebitCardPayment : IPayment
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing Debit Card payment of {amount}...");
        }

        public void RefundPayment(double amount)
        {
            Console.WriteLine($"Refunding {amount} to Debit Card...");
        }

        public bool MakePayment(double amount)
        {
            ProcessPayment(amount);
            Console.WriteLine("Debit Card Payment Successful ");
            return true;
        }
    }

    // Step 4: Class Order with enum + struct + implements IPayment
    class Order : IPayment
    {
        // Order Properties
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public Location ShippingLocation { get; set; }

        // Extra Property (helps testing payment)
        public double Amount { get; set; }

        // Constructor
        public Order(int orderId, double amount, Location location)
        {
            OrderId = orderId;
            Amount = amount;
            ShippingLocation = location;
            Status = OrderStatus.Pending;
        }

        // Order method
        public void DisplayOrder()
        {
            Console.WriteLine("\n===== ORDER DETAILS =====");
            Console.WriteLine($"Order ID: {OrderId}");
            Console.WriteLine($"Amount: {Amount}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Shipping Location: {ShippingLocation}");
            Console.WriteLine("=========================");
        }

        // IPayment methods implemented in Order (as per requirement)
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing payment of {amount} for Order #{OrderId}...");
        }

        public void RefundPayment(double amount)
        {
            Console.WriteLine($"Refunding payment of {amount} for Order #{OrderId}...");
        }

        public bool MakePayment(double amount)
        {
            ProcessPayment(amount);
            Status = OrderStatus.Processing;
            Console.WriteLine("Payment done successfully  Order moved to Processing.");
            return true;
        }
    }

    class Program
    {
        static void Main()
        {
            // Create shipping location (struct)
            Location loc = new Location(12.9716, 77.5946);

            // Create Order (class)
            Order order1 = new Order(101, 2500, loc);

            order1.DisplayOrder();

            // Payment using Order's payment (because it implements IPayment)
            order1.MakePayment(order1.Amount);

            // Update status (enum)
            order1.Status = OrderStatus.Shipped;
            Console.WriteLine("\nOrder shipped ");

            order1.Status = OrderStatus.Delivered;
            Console.WriteLine("Order delivered ");

            order1.DisplayOrder();

            // OPTIONAL: Payment class usage (Credit / Debit)
            Console.WriteLine("\n--- Extra Demo: Using Payment Classes ---");

            IPayment credit = new CreditCardPayment();
            credit.MakePayment(999);

            IPayment debit = new DebitCardPayment();
            debit.MakePayment(499);
        }
    }

}
