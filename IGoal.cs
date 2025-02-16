using System;

interface IGoal
{
    string Name { get; }
    string Description { get; }
    int Points { get; }
    bool IsCompleted { get; }

    void RecordEvent(ref int score);
    string Serialize();
}
