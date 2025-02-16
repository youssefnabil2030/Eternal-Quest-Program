using System;

class EternalGoal : IGoal
{
    public string Name { get; }
    public string Description { get; }
    public int Points { get; }
    public bool IsCompleted => false;  // Always false since it's a recurring goal

    public EternalGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public void RecordEvent(ref int score)
    {
        score += Points;
        Console.WriteLine($"Recorded progress for '{Name}'. +{Points} points.");
    }

    public string Serialize()
    {
        return $"EternalGoal,{Name},{Description},{Points}";
    }
}
