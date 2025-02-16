using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class GoalManager
{
    private List<IGoal> goals = new List<IGoal>();
    private int score = 0;
    private string filename = "goals.json";

    public void AddGoal(IGoal goal)
    {
        goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in goals)
        {
            if (goal.Name == goalName)
            {
                goal.RecordEvent(ref score);
                return;
            }
        }
        Console.WriteLine("Goal not found.");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        foreach (var goal in goals)
        {
            string status = goal.IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{status} {goal.Name}");
        }
        Console.WriteLine($"Total Score: {score}");
    }

    public void SaveGoals()
    {
        var data = new { score, goals };
        File.WriteAllText(filename, JsonConvert.SerializeObject(data, Formatting.Indented));
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            score = data.score;
            goals.Clear();

            foreach (var goalData in data.goals)
            {
                string type = goalData["$type"];
                if (type.Contains("SimpleGoal"))
                    goals.Add(new SimpleGoal(goalData["Name"].ToString(), goalData["Description"].ToString(), (int)goalData["Points"]));
                else if (type.Contains("EternalGoal"))
                    goals.Add(new EternalGoal(goalData["Name"].ToString(), goalData["Description"].ToString(), (int)goalData["Points"]));
                else if (type.Contains("ChecklistGoal"))
                    goals.Add(new ChecklistGoal(goalData["Name"].ToString(), goalData["Description"].ToString(), (int)goalData["Points"], (int)goalData["TargetCount"], (int)goalData["BonusPoints"]));
            }

            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("Save file not found.");
        }
    }
}
