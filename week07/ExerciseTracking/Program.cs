using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Create instances of each type
        activities.Add(new Running("03 Nov 2022", 30, 4.8));
        activities.Add(new Cycling("04 Nov 2022", 40, 15.0));
        activities.Add(new Swimming("05 Nov 2022", 25, 30));

        // Display summaries (polymorphism in action)
        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}
