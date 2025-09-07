using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name?");
        string first= Console.Read();

        Console.Write("What is your last name?");
        string last= Console.Read();

        Console.WriteLine($"Your name is {last}, {first} {last}.");
    }
}