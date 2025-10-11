using System;

public class ChecklistGoal : Goal
{
    private int _requiredCount;
    private int _bonus;
    private int _currentCount;

    public ChecklistGoal(string title, string description, int points, int requiredCount, int bonus)
        : base(title, description, points)
    {
        _requiredCount = requiredCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    // Set current count when loading
    public void SetCurrentCountForLoad(int c)
    {
        _currentCount = c;
    }

    public override int RecordEvent()
    {
        if (_currentCount >= _requiredCount)
        {
            // Already completed the checklist -> no further points
            return 0;
        }

        _currentCount++;
        int earned = GetPoints();

        if (_currentCount == _requiredCount)
        {
            // Completed checklist, add bonus
            earned += _bonus;
        }
        return earned;
    }

    public override string GetDetailsString()
    {
        string status = _currentCount >= _requiredCount ? "[X]" : "[ ]";
        return $"{status} {GetTitle()} ({GetDescription()}) -- Completed {_currentCount}/{_requiredCount}";
    }

    public override string GetStringRepresentation()
    {
        // Checklist:title,description,points,requiredCount,bonus,currentCount
        return $"Checklist:{GetTitle()},{GetDescription()},{GetPoints()},{_requiredCount},{_bonus},{_currentCount}";
    }
}
