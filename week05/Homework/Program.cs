using System;

class Program
{
    static void Main(string[] args)
    {
        // Test Assignment
        Assignment assignment1 = new Assignment("John Doe", "History");
        Console.WriteLine(assignment1.GetSummary());

        // Test MathAssignment
        MathAssignment math1 = new MathAssignment("Jane Smith", "Fractions", "7.3", "1-10, 20-25");
        Console.WriteLine(math1.GetSummary());
        Console.WriteLine(math1.GetHomeworkList());

        // Test WritingAssignment
        WritingAssignment writing1 = new WritingAssignment("Mike Brown", "World War II", "The Causes of WWII");
        Console.WriteLine(writing1.GetSummary());
        Console.WriteLine(writing1.GetWritingInformation());
    }
}
