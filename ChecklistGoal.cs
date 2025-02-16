using System;

class ChecklistGoal : IGoal
{
    public string Name { get; }
    public string Description { get; }
    public int Points { get; }
    public int TargetCount { get; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; }
    public bool IsCompleted => CurrentCount >= TargetCount;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
    {
        Name = name;
        Description = description;
        Points = points;
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public void RecordEvent(ref int score)
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            score += Points;
            Console.WriteLine($"Progress on '{Name}': {CurrentCount}/{TargetCount} (+{Points} points)");

            if (IsCompleted)
            {
                score += BonusPoints;
                Console.WriteLine($"Goal '{Name}' completed! Bonus +{BonusPoints} points.");
            }
        }
    }

    public string Serialize()
    {
        return $"ChecklistGoal,{Name},{Description},{Points},{TargetCount},{CurrentCount},{BonusPoints}";
    }
}
