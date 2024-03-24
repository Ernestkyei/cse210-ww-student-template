using System;


// Base class for all mindfulness activities
public abstract class MindfulnessActivity
{
    protected int durationInSeconds;

    public MindfulnessActivity(int durationInSeconds)
    {
        this.durationInSeconds = durationInSeconds;
    }

    public abstract void Start();
}

// Derived class for breathing activity
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int durationInSeconds) : base(durationInSeconds)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Breathing Activity: This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.WriteLine("Setting duration for breathing activity: " + durationInSeconds + " seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds

        for (int i = 0; i < durationInSeconds; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }

        Console.WriteLine("Good job! You've completed the breathing activity for " + durationInSeconds + " seconds.");
    }
}

// Derived class for reflection activity
public class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int durationInSeconds) : base(durationInSeconds)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Reflection Activity: This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine("Setting duration for reflection activity: " + durationInSeconds + " seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds

        Random rand = new Random();
        int randomIndex = rand.Next(prompts.Length);
        string prompt = prompts[randomIndex];
        Console.WriteLine("Prompt: " + prompt);
        Thread.Sleep(3000); // Pause for 3 seconds

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(3000); // Pause for 3 seconds
        }

        Console.WriteLine("Good job! You've completed the reflection activity for " + durationInSeconds + " seconds.");
    }
}

// Derived class for listing activity
public class ListingActivity : MindfulnessActivity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int durationInSeconds) : base(durationInSeconds)
    {
    }

    public override void Start()
    {
        Console.WriteLine("Listing Activity: This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("Setting duration for listing activity: " + durationInSeconds + " seconds.");
        Thread.Sleep(3000); // Pause for 3 seconds

        Random rand = new Random();
        int randomIndex = rand.Next(prompts.Length);
        string prompt = prompts[randomIndex];
        Console.WriteLine("Prompt: " + prompt);
        Thread.Sleep(3000); // Pause for 3 seconds

        Console.WriteLine("Think about the prompt and start listing...");
        Thread.Sleep(3000); // Pause for 3 seconds

        // Simulating user entering items in the list
        int itemCount = 0;
        while (true)
        {
            Console.WriteLine("Enter an item (or type 'quit' to finish): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            itemCount++;
        }

        Console.WriteLine("You've listed " + itemCount + " items.");
        Console.WriteLine("Good job! You've completed the listing activity for " + durationInSeconds + " seconds.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mindfulness Activity Program");

        while (true)
        {
                       Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter duration for Breathing Activity (in seconds): ");
                int duration = int.Parse(Console.ReadLine());
                BreathingActivity breathingActivity = new BreathingActivity(duration);
                breathingActivity.Start();
            }
            else if (choice == "2")
            {
                Console.Write("Enter duration for Reflection Activity (in seconds): ");
                int duration = int.Parse(Console.ReadLine());
                ReflectionActivity reflectionActivity = new ReflectionActivity(duration);
                reflectionActivity.Start();
            }
            else if (choice == "3")
            {
                Console.Write("Enter duration for Listing Activity (in seconds): ");
                int duration = int.Parse(Console.ReadLine());
                ListingActivity listingActivity = new ListingActivity(duration);
                listingActivity.Start();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Exiting the program...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
            }

            Console.WriteLine();
        }
    }
}
