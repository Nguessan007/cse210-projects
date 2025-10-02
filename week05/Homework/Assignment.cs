using System;

public class Assignment
{
    // Private member variables
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Public method
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Getter to expose student name for derived classes if needed
    public string GetStudentName()
    {
        return _studentName;
    }
}
