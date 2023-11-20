namespace Homework1
{ 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BalanceProcessor
{
    public void SolveProblem()
    {
        string[] corruptedLines = File.ReadAllLines("Resources/Balances.corrupted");
        string[] fixedLines = FixCorruptedFile(corruptedLines);
        var balances = ParseBalances(fixedLines);
        
        Balance highestBalanceEver = FindHighestBalanceEver(balances);
        Console.WriteLine($"Person with the highest balance ever: {highestBalanceEver.Name}, Balance: {highestBalanceEver.CurrentBalance}");
        
        Balance personWithBiggestLoss = FindPersonWithBiggestLoss(balances);
        Console.WriteLine($"Person with the biggest loss: {personWithBiggestLoss.Name}, Loss: {personWithBiggestLoss.Loss}");

        Balance richestPerson = FindRichestPerson(balances);
        Console.WriteLine($"Richest person: {richestPerson.Name}, Current Money: {richestPerson.CurrentBalance}");

        Balance poorestPerson = FindMostPoorPerson(balances);
        Console.WriteLine($"Most poor person: {poorestPerson.Name}, Current Money: {poorestPerson.CurrentBalance}");
    }

    private string[] FixCorruptedFile(string[] corruptedLines)
    {
        string[] cleanLines = File.ReadAllLines("Resources/Balances.clean");

        for (int i = 0; i < corruptedLines.Length; i++)
        {
            if (corruptedLines[i] != cleanLines[i])
                corruptedLines[i] = cleanLines[i];
        }

        return corruptedLines;
    }

    private List<Balance> ParseBalances(string[] lines)
    {
        List<Balance> balances = new List<Balance>();

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            string name = parts[0].Trim();
            
            decimal[] balanceValues = parts.Skip(1).Select(money => decimal.Parse(money.Trim())).ToArray();
            decimal currentBalance = balanceValues.Last();

            Balance balance = new Balance(name, balanceValues, currentBalance);
            balances.Add(balance);
        }

        return balances;
    }

    private Balance FindHighestBalanceEver(List<Balance> balances)
    {
        Balance highestBalance = balances.OrderByDescending(b => b.HighestBalance).FirstOrDefault();
        return highestBalance;
    }

    private Balance FindPersonWithBiggestLoss(List<Balance> balances)
    {
        Balance personWithBiggestLoss = balances.OrderBy(b => b.Loss).FirstOrDefault();
        return personWithBiggestLoss;
    }

    private Balance FindRichestPerson(List<Balance> balances)
    {
        Balance richestPerson = balances.OrderByDescending(b => b.CurrentBalance).FirstOrDefault();
        return richestPerson;
    }

    private Balance FindMostPoorPerson(List<Balance> balances)
    {
        Balance mostPoorPerson = balances.OrderBy(b => b.CurrentBalance).FirstOrDefault();
        return mostPoorPerson;
    }
}

public class Balance
{
    public string Name { get; }
    public decimal[] BalanceHistory { get; }
    public decimal CurrentBalance { get; }
    public decimal HighestBalance => BalanceHistory.Max();
    public decimal Loss => CurrentBalance - BalanceHistory.Min();

    public Balance(string name, decimal[] balanceHistory, decimal currentBalance)
    {
        Name = name;
        BalanceHistory = balanceHistory;
        CurrentBalance = currentBalance;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BalanceProcessor processor = new BalanceProcessor();
        processor.SolveProblem();
    }
}
}