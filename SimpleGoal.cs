using System;

class SimpleGoal : IGoal
{
    public string Name { get; }
    public string Description { get; }
    public int Points { get; }
    public bool IsCompleted { get; private set; }

    public SimpleGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsCompleted = false;
    }

    public void RecordEvent(ref int score)
    {
        if (!IsCompleted)
        {
            score += Points;
            IsCompleted = true;
            Console.WriteLine($"Goal '{Name}' completed! +{Points} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' is already completed.");
        }
    }

    public string Serialize()
    {
        return $"SimpleGoal,{Name},{Description},{Points},{IsCompleted}";
    }
}
