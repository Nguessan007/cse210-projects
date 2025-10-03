using System;

// Inherits from Assignment
public class WritingAssignment : Assignment
{
    // Private member variable unique to WritingAssignment
    private string _title;

    // Constructor (calls base constructor for studentName and topic)
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to return writing information
    public string GetWritingInformation()
    {
        // Access student name from base class via public getter
        return $"{GetStudentName()} - \"{_title}\"";
    }
}
