using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string title, string description, int points)
        : base(title, description, points)
    {
        _isComplete = false;
    }

    // Called when loading a saved goal that was already complete
    public void MarkCompleteForLoad()
    {
        _isComplete = true;
    }

    // Derived class override to record the event
    // Returns the points earned this time
    public override int RecordEvent()
    {
        if (_isComplete)
        {
            // already complete => no points (could adjust behavior if desired)
            return 0;
        }
        _isComplete = true;
        return GetPoints();
    }

    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {GetTitle()} ({GetDescription()})";
    }

    public bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        // Simple:title,description,points,isComplete
        return $"Simple:{GetTitle()},{GetDescription()},{GetPoints()},{_isComplete}";
    }
}
