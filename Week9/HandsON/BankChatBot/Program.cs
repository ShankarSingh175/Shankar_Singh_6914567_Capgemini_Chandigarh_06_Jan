using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public interface IBankAccountOperation
{
    void Deposit(decimal d);
    void Withdraw(decimal d);
    decimal ProcessOperation(string message);
}

class BankOperations : IBankAccountOperation
{
    private decimal balance = 0;

    public void Deposit(decimal d)
    {
        balance += d;
    }

    public void Withdraw(decimal d)
    {
        balance -= d;
    }

    public decimal ProcessOperation(string message)
    {
        message = message.ToLower();

        // extract number from message
        Match m = Regex.Match(message, @"\d+");
        decimal amount = 0;

        if (m.Success)
            amount = Convert.ToDecimal(m.Value);

        if (message.Contains("deposit") || message.Contains("invest") || message.Contains("transfer"))
        {
            Deposit(amount);
        }
        else if (message.Contains("withdraw") || message.Contains("pull"))
        {
            Withdraw(amount);
        }

        return balance;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = Console.Out;

        int n = Convert.ToInt32(Console.ReadLine());
        List<string> inputs = new List<string>();

        for (int i = 0; i < n; i++)
        {
            inputs.Add(Console.ReadLine());
        }

        BankOperations opt = new BankOperations();

        foreach (var item in inputs)
        {
            textWriter.WriteLine(opt.ProcessOperation(item));
        }
    }
}