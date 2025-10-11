using System;

class Program
{
    // NOTE: To exceed requirements and show creativity (for the 100%):
    // - This program includes a basic leveling system (every 1000 points -> next level).
    // - You can easily extend it with achievements, negative goals, or progress goals.
    // - Documented here to satisfy the "report on exceeding requirements" instruction.
    //
    // If you extended this more, explain the added features in a comment like above.

    static void Main(string[] args)
    {
        var manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEternal Quest - Main Menu");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Record event");
            Console.WriteLine("4. Save goals");
            Console.WriteLine("5. Load goals");
            Console.WriteLine("6. Show score/stats");
            Console.WriteLine("7. Exit");
            Console.Write("> ");

            string input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    CreateNewGoalMenu(manager);
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    manager.RecordEvent();
                    break;
                case "4":
                    manager.SaveGoals();
                    break;
                case "5":
                    manager.LoadGoals();
                    break;
                case "6":
                    manager.ShowStats();
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Choose 1-7.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void CreateNewGoalMenu(GoalManager mgr)
    {
        Console.WriteLine("Choose a goal type:");
        Console.WriteLine("1. Simple goal");
        Console.WriteLine("2. Eternal goal");
        Console.WriteLine("3. Checklist goal");
        Console.Write("> ");
        string t = Console.ReadLine();

        Console.Write("Enter title: ");
        string title = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();

        Console.Write("Enter points awarded: ");
        if (!int.TryParse(Console.ReadLine(), out int pts))
        {
            Console.WriteLine("Invalid points. Defaulting to 0.");
            pts = 0;
        }

        switch (t)
        {
            case "1":
                var simple = new SimpleGoal(title, desc, pts);
                mgr.AddGoal(simple);
                Console.WriteLine("Simple goal added.");
                break;
            case "2":
                var eternal = new EternalGoal(title, desc, pts);
                mgr.AddGoal(eternal);
                Console.WriteLine("Eternal goal added.");
                break;
            case "3":
                Console.Write("How many times to complete (required count)? ");
                if (!int.TryParse(Console.ReadLine(), out int req))
                {
                    Console.WriteLine("Invalid number. Defaulting to 1.");
                    req = 1;
                }
                Console.Write("Bonus points when completed: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus. Defaulting to 0.");
                    bonus = 0;
                }
                var checklist = new ChecklistGoal(title, desc, pts, req, bonus);
                mgr.AddGoal(checklist);
                Console.WriteLine("Checklist goal added.");
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }
}
