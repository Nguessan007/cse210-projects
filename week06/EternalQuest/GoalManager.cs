using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private string _saveFilename = "goals.txt";

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore() => _score;

    public void AddGoal(Goal g)
    {
        _goals.Add(g);
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been added.");
            return;
        }

        int i = 1;
        foreach (var g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetDetailsString()}");
            i++;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record. Add a goal first.");
            return;
        }

        Console.WriteLine("Which goal did you accomplish? Enter the number:");
        ListGoals();
        Console.Write("> ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        var selected = _goals[choice - 1];
        int earned = selected.RecordEvent();
        _score += earned;
        Console.WriteLine($"You earned {earned} points. Total score: {_score}");
        CheckLevelUp();
    }

    public void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter(_saveFilename))
        {
            outputFile.WriteLine(_score); // first line store score
            foreach (var g in _goals)
            {
                outputFile.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Goals saved to {_saveFilename}");
    }

    public void LoadGoals()
    {
        if (!File.Exists(_saveFilename))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(_saveFilename);
        if (lines.Length == 0) return;

        // First line is score
        if (int.TryParse(lines[0], out int savedScore))
        {
            _score = savedScore;
        }
        else
        {
            _score = 0;
        }

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            var g = Goal.CreateFromString(lines[i]);
            if (g != null) _goals.Add(g);
        }

        Console.WriteLine($"Loaded {_goals.Count} goals, score is {_score}.");
    }

    public void ShowScore()
    {
        Console.WriteLine($"Your score: {_score}");
    }

    // A small gamification addition: leveling system (demonstrates creativity)
    private int _level = 1;
    private void CheckLevelUp()
    {
        int levelThreshold = _level * 1000;
        while (_score >= levelThreshold)
        {
            _level++;
            Console.WriteLine($"🎉 Level up! You reached level {_level}!");
            levelThreshold = _level * 1000;
        }
    }

    public void ShowStats()
    {
        Console.WriteLine($"Score: {_score}  |  Level: {_level}  |  Goals: {_goals.Count}");
    }
}
