using System;

public class MathAssignment : Assignment
{
    // Private member variables (specific to MathAssignment)
    private string _textbookSection;
    private string _problems;

    // Constructor (calls base class constructor)
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Specific method
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
