using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\n1. Create a Goal");
            Console.WriteLine("2. Record an Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Goal Name: ");
                string name = Console.ReadLine();
                Console.Write("Description: ");
                string desc = Console.ReadLine();
                Console.Write("Points: ");
                int points = int.Parse(Console.ReadLine());

                Console.Write("Type (1=Simple, 2=Eternal, 3=Checklist): ");
                string type = Console.ReadLine();

                if (type == "1")
                    manager.AddGoal(new SimpleGoal(name, desc, points));
                else if (type == "2")
                    manager.AddGoal(new EternalGoal(name, desc, points));
                else if (type == "3")
                {
                    Console.Write("Target Count: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Bonus Points: ");
                    int bonus = int.Parse(Console.ReadLine());
                    manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                }
            }
            else if (choice == "2")
            {
                Console.Write("Enter goal name: ");
                manager.RecordEvent(Console.ReadLine());
            }
            else if (choice == "3") manager.DisplayGoals();
            else if (choice == "4") manager.SaveGoals();
            else if (choice == "5") manager.LoadGoals();
            else if (choice == "6") break;
        }
    }
}
