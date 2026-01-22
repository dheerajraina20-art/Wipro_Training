using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_properties_static_keyword_implimentation
{
    static class PlatformConfig
    {
        //static properties shared by everyone
        public static string PlatformName { get; } = "abc learning";
        public static int MaxLoginAttempts { get; } = 3;
        public static double GlobalDiscountRate { get;  } = 0.15;
        public static double TotalRegisteredUsers { get; private set; } = 0;

        public static void IncrementUser()
        {
            TotalRegisteredUsers++;
        }
    }

    public class  User
    {
        //instance property unique to each user
        public string UserName { get; set; }
        public User(string userName )
        {
            UserName = userName;
            PlatformConfig.IncrementUser();
        }
        public void DisplayUserDetails()
        {
            Console.WriteLine($"User: {UserName}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Platform Name: {PlatformConfig.PlatformName}");
            Console.WriteLine($"Max Login Attempts: {PlatformConfig.MaxLoginAttempts}");
            Console.WriteLine($"Global Discount Rate: {PlatformConfig.GlobalDiscountRate}");
            User user1 = new User("Alice");
            User user2 = new User("Bob");
            user1.DisplayUserDetails();
            user2.DisplayUserDetails();
            Console.WriteLine($"Total Registered Users: {PlatformConfig.TotalRegisteredUsers}");
        }
    }
}
