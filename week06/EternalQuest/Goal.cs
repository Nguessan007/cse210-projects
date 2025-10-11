using System;

public abstract class Goal
{
    // Encapsulated fields
    private string _title;
    private string _description;
    private int _points;

    // Constructor for base fields
    protected Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    // Public getters / setters
    public string GetTitle() => _title;
    public string GetDescription() => _description;
    public int GetPoints() => _points;
    public void SetPoints(int p) => _points = p;

    // An abstract event recorder (polymorphism: derived classes must implement)
    public abstract int RecordEvent();

    // Default string used to display details; derived classes may override
    public virtual string GetDetailsString()
    {
        return $"{_title} ({_description})";
    }

    // A string representation to allow saving to a text file.
    // Format: TYPE:field1,field2,...
    public abstract string GetStringRepresentation();

    // Factory to create appropriate Goal subclass from saved line
    public static Goal CreateFromString(string dataLine)
    {
        // Expected format: Type:field1,field2,...
        // Example: Simple:Run marathon,Run a full marathon,100,true
        if (string.IsNullOrWhiteSpace(dataLine))
            return null;

        var parts = dataLine.Split(':', 2);
        if (parts.Length != 2) return null;

        var type = parts[0];
        var fields = parts[1].Split(',');

        switch (type)
        {
            case "Simple":
                // Simple:title,description,points,isComplete
                {
                    string title = fields[0];
                    string desc = fields[1];
                    int pts = int.Parse(fields[2]);
                    bool isComplete = bool.Parse(fields[3]);
                    var g = new SimpleGoal(title, desc, pts);
                    if (isComplete) g.MarkCompleteForLoad();
                    return g;
                }
            case "Eternal":
                // Eternal:title,description,points
                {
                    string title = fields[0];
                    string desc = fields[1];
                    int pts = int.Parse(fields[2]);
                    return new EternalGoal(title, desc, pts);
                }
            case "Checklist":
                // Checklist:title,description,points,requiredCount,bonus,currentCount
                {
                    string title = fields[0];
                    string desc = fields[1];
                    int pts = int.Parse(fields[2]);
                    int required = int.Parse(fields[3]);
                    int bonus = int.Parse(fields[4]);
                    int current = int.Parse(fields[5]);
                    var g = new ChecklistGoal(title, desc, pts, required, bonus);
                    // restore current count
                    g.SetCurrentCountForLoad(current);
                    return g;
                }
            default:
                return null;
        }
    }
}
