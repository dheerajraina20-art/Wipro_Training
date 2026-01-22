using System;
using BankAudit;
using CoreBanking;

Console.WriteLine("Welcome to Bank Account Management System");

SavingsAccount savingAcc = new SavingsAccount("SA123", "1234", 5.0m, "BR001");
savingAcc.Deposit(1000);

decimal interest = savingAcc.CalculateInterest();
Console.WriteLine($"Interest for Saving Account: {interest}");

CorporateAccount corpAcc = new CorporateAccount("CA123", "5678", 7.0m, "BR002");
corpAcc.Deposit(5000);
corpAcc.ApplyCorporateInterest();

Console.WriteLine("Corporate Account interest applied successfully ✅");
