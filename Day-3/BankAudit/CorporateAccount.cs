using System;
using CoreBanking;

namespace BankAudit
{
    public class CorporateAccount : BankAccount
    {
        public CorporateAccount(string accNumber, string pin, decimal interest, string branchCode)
            : base(accNumber, pin, interest, branchCode)
        {
        }

        public void ApplyCorporateInterest()
        {
            decimal corpInterest = balance * interestRate / 100;
            balance += corpInterest;

            Console.WriteLine($"Corporate Interest Applied: {corpInterest}");
        }
    }
}
