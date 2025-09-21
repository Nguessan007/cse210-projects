using System;
using FractionsApp;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction(1, 2);   // 1/2
        Fraction f2 = new Fraction(3, 4);   // 3/4

        Console.WriteLine($"Fraction 1: {f1} = {f1.ToDecimal()}");
        Console.WriteLine($"Fraction 2: {f2} = {f2.ToDecimal()}");

        Console.WriteLine("\nArithmetic:");
        Console.WriteLine($"{f1} + {f2} = {f1.Add(f2)}");
        Console.WriteLine($"{f1} - {f2} = {f1.Subtract(f2)}");
        Console.WriteLine($"{f1} * {f2} = {f1.Multiply(f2)}");
        Console.WriteLine($"{f1} / {f2} = {f1.Divide(f2)}");
    }
}
