using System;

public class EternalGoal : Goal
{
    // No extra member variables needed, but class exists to encapsulate behavior
    public EternalGoal(string title, string description, int points)
        : base(title, description, points)
    {
    }

    public override int RecordEvent()
    {
        // Each time it's recorded, return the base points
        return GetPoints();
    }

    public override string GetDetailsString()
    {
        // Eternal goals are never marked complete
        return $"[~] {GetTitle()} ({GetDescription()})";
    }

    public override string GetStringRepresentation()
    {
        // Eternal:title,description,points
        return $"Eternal:{GetTitle()},{GetDescription()},{GetPoints()}";
    }
}
