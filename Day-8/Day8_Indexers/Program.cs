
using System;
class Employee
{
    // Properties (single attributes)
    public int Id { get; set; }
    public string Name { get; set; }

    // Private array for attendance
    private string[] attendance = new string[7]; // 7 days

    // Indexer (collection attribute)
    public string this[int day]
    {
        get { return attendance[day]; }
        set { attendance[day] = value; }
    }
}

class Program
{
    static void Main()
    {
        Employee emp = new Employee();
        emp.Id = 101;
        emp.Name = "Dheeraj";

        // Using indexer for attendance
        emp[0] = "P";  // Day 0
        emp[1] = "A";
        emp[2] = "P";

        Console.WriteLine("Employee Id: " + emp.Id);
        Console.WriteLine("Employee Name: " + emp.Name);

        Console.WriteLine("Attendance Day 0: " + emp[0]);
        Console.WriteLine("Attendance Day 1: " + emp[1]);
        Console.WriteLine("Attendance Day 2: " + emp[2]);
    }
}

//2nd Program class to demonstrate Product indexer
/*
using System;

class Product
{
    // Properties (single product details)
    public string ProductName { get; set; }
    public double Price { get; set; }

    // Ratings stored in an array
    private int[] ratings = new int[5]; // 5 customers

    // Indexer for ratings
    public int this[int customerIndex]
    {
        get { return ratings[customerIndex]; }
        set { ratings[customerIndex] = value; }
    }
}

class Program
{
    static void Main()
    {
        Product p = new Product();
        p.ProductName = "Laptop";
        p.Price = 55000;

        // Customer ratings using indexer
        p[0] = 5;
        p[1] = 4;
        p[2] = 5;

        Console.WriteLine("Product: " + p.ProductName);
        Console.WriteLine("Price: " + p.Price);

        Console.WriteLine("Customer 0 Rating: " + p[0]);
        Console.WriteLine("Customer 1 Rating: " + p[1]);
        Console.WriteLine("Customer 2 Rating: " + p[2]);
    }
}

*/