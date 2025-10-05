using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "Who have you helped this week?",
        "When have you felt peace recently?"
    };

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity helps you reflect on good things by listing as many as you can.";
    }

    public override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Count)]);
        Console.Write("You may begin listing in: ");
        ShowCountdown(5);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            string input = Console.ReadLine();
            items.Add(input);
        }

        Console.WriteLine($"You listed {items.Count} items!");
    }
}
