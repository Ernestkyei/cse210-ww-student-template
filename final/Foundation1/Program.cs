using System;
using System.Collections.Generic;

// Comment class to store comment details
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public override string ToString()
    {
        return $"{CommenterName}: {Text}";
    }
}

// Video class to store video details and comments
class Video
{
    // Private member variables
    private string title;
    private string author;
    private int lengthInSeconds;
    private List<Comment> comments;

    // Constructor
    public Video(string title, string author, int lengthInSeconds)
    {
        this.title = title;
        this.author = author;
        this.lengthInSeconds = lengthInSeconds;
        this.comments = new List<Comment>();
    }

    // Method to add a comment to the video
    public void AddComment(string commenterName, string text)
    {
        comments.Add(new Comment { CommenterName = commenterName, Text = text });
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    // Method to display video details and comments
    public void DisplayDetails()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Length: {lengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");

        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine(comment);
        }

        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating video objects
        Video video1 = new Video("Introduction to C#", "John Doe", 300);
        video1.AddComment("Alice", "Great tutorial!");
        video1.AddComment("Bob", "I learned a lot, thank you!");
        video1.AddComment("Carol", "Could you make more videos like this?");

        Video video2 = new Video("Python Programming Basics", "Jane Smith", 400);
        video2.AddComment("David", "Very helpful, thanks!");
        video2.AddComment("Emily", "I wish I found this sooner.");

        Video video3 = new Video("Java for Beginners", "Chris Johnson", 250);
        video3.AddComment("Frank", "Awesome explanation!");
        video3.AddComment("Grace", "I'm enjoying learning Java!");

        // Adding videos to a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Displaying details of each video
        foreach (var video in videos)
        {
            video.DisplayDetails();
        }
    }
}
