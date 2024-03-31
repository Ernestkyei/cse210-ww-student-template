using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }

    // Abstract method to record an event for the goal
    public abstract void RecordEvent();
}

// Derived class for simple goals
public class SimpleGoal : Goal
{
    public override void RecordEvent()
    {
        Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
        IsCompleted = true;
    }
}

// Derived class for eternal goals
public class EternalGoal : Goal
{
    public override void RecordEvent()
    {
        Console.WriteLine($"Event recorded for eternal goal '{Name}'. You earned {Points} points.");
    }
}

// Derived class for checklist goals
public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CompletedCount { get; set; }

    public override void RecordEvent()
    {
        CompletedCount++;
        Console.WriteLine($"Event recorded for checklist goal '{Name}'. Total completed: {CompletedCount}/{TargetCount}.");
        if (CompletedCount == TargetCount)
        {
            Console.WriteLine($"Congratulations! Checklist goal '{Name}' completed. You earned {Points} points.");
            IsCompleted = true;
        }
    }
}

// Class to manage goals and score
public class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int totalScore = 0;

    // Add a new goal
    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    // Record an event for a specific goal
    public void RecordEventForGoal(string goalName)
    {
        Goal goal = goals.FirstOrDefault(g => g.Name == goalName && !g.IsCompleted);
        if (goal != null)
        {
            goal.RecordEvent();
            totalScore += goal.Points;
        }
        else
        {
            Console.WriteLine("Goal not found or already completed.");
        }
    }

    // Display user's score
    public void DisplayScore()
    {
        Console.WriteLine($"Your total score: {totalScore}");
    }

    // Save goals and score to a file
    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine($"{goal.Name},{goal.Description},{goal.Points},{goal.IsCompleted}");
            }
            writer.WriteLine($"Total Score,{totalScore}");
        }
    }

    // Load goals and score from a file
    public void LoadFromFile(string fileName)
    {
        goals.Clear();
        totalScore = 0;
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string name = parts[0];
                    string description = parts[1];
                    int points = int.Parse(parts[2]);
                    bool isCompleted = bool.Parse(parts[3]);

                    Goal goal;
                    if (isCompleted)
                    {
                        goal = new SimpleGoal { Name = name, Description = description, Points = points };
                        goal.RecordEvent(); // Automatically mark completed if loaded as completed
                    }
                    else
                    {
                        goal = new SimpleGoal { Name = name, Description = description, Points = points };
                    }

                    goals.Add(goal);
                }
                else if (parts.Length == 2 && parts[0] == "Total Score")
                {
                    totalScore = int.Parse(parts[1]);
                }
            }
        }
    }

    // Method to create a new goal based on user input
    public void CreateGoal()
    {
        Console.WriteLine("Enter the type of goal (Simple, Eternal, Checklist):");
        string goalType = Console.ReadLine().Trim();

        Console.WriteLine("Enter the name of the goal:");
        string name = Console.ReadLine().Trim();

        Console.WriteLine("Enter the description of the goal:");
        string description = Console.ReadLine().Trim();

        Console.WriteLine("Enter the points for completing the goal:");
        int points = int.Parse(Console.ReadLine().Trim());

        Goal goal;
        switch (goalType.ToLower())
        {
            case "simple":
                goal = new SimpleGoal { Name = name, Description = description, Points = points };
                break;
            case "eternal":
                goal = new EternalGoal { Name = name, Description = description, Points = points };
                break;
            case "checklist":
                Console.WriteLine("Enter the target count for the checklist goal:");
                int targetCount = int.Parse(Console.ReadLine().Trim());
                goal = new ChecklistGoal { Name = name, Description = description, Points = points, TargetCount = targetCount };
                break;
            default:
                Console.WriteLine("Invalid goal type. Please choose from Simple, Eternal, or Checklist.");
                return;
        }

        AddGoal(goal);
        Console.WriteLine($"New goal '{goal.Name}' created successfully!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        // Example: Create and add goals
        Goal goal1 = new SimpleGoal { Name = "Run a Marathon", Description = "Run 42.195 kilometers", Points = 1000 };
        goalManager.AddGoal(goal1);

        Goal goal2 = new EternalGoal { Name = "Read Scriptures", Description = "Read scriptures daily", Points = 100 };
        goalManager.AddGoal(goal2);

        Goal goal3 = new ChecklistGoal { Name = "Attend Temple", Description = "Attend temple 10 times", Points = 50, TargetCount = 10 };
        goalManager.AddGoal(goal3);

        // Example: Record events for goals
        goalManager.RecordEventForGoal("Run a Marathon");
        goalManager.RecordEventForGoal("Read Scriptures");
        goalManager.RecordEventForGoal("Attend Temple");
        goalManager.RecordEventForGoal("Attend Temple"); // Repeat attendance

        // Example: Display score
        goalManager.DisplayScore();

        // Example: Save and load goals from a file
        goalManager.SaveToFile("goals.txt");
        goalManager.LoadFromFile("goals.txt");

        // Example: Create a new goal
        goalManager.CreateGoal();

        // Display score after creating a new goal
        goalManager.DisplayScore();
    }
}
