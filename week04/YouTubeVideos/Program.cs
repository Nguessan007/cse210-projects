using System;
using System.Collections.Generic;

class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public void DisplayComment()
    {
        Console.WriteLine($"{CommenterName}: {Text}");
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // length in seconds
    public List<Comment> Comments { get; set; } = new List<Comment>();

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Length: {Length} seconds");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            comment.DisplayComment();
        }
    }
}

// Comment class
class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

// Video class
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int lengthSeconds)
    {
        Title = title;
        Author = author;
        LengthSeconds = lengthSeconds;
    }

    // Add a comment to the video
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Get the number of comments
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    // Get all comments
    public List<Comment> GetComments()
    {
        return comments;
    }
}

// Program entry
class Program
{
    static void Main()
    {
        // Create some videos
        Video video1 = new Video("Learn C# in 10 Minutes", "Alice", 600);
        Video video2 = new Video("Funny Cat Compilation", "Bob", 300);
        Video video3 = new Video("Travel Vlog: Japan", "Charlie", 1200);
        Video video4 = new Video("Guitar Tutorial: Beginner", "Diana", 900);

        // Add comments to each video
        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Emily", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Sam", "Could you explain classes more?"));

        video2.AddComment(new Comment("Lucy", "Hahaha so funny!"));
        video2.AddComment(new Comment("Mike", "I love cats!"));
        video2.AddComment(new Comment("Anna", "Made my day."));

        video3.AddComment(new Comment("Tom", "Beautiful scenery!"));
        video3.AddComment(new Comment("Sara", "Japan is on my bucket list."));
        video3.AddComment(new Comment("Leo", "Amazing video quality."));

        video4.AddComment(new Comment("Nina", "I learned so much."));
        video4.AddComment(new Comment("Alex", "Great pacing and explanation."));
        video4.AddComment(new Comment("Emma", "Thanks for the tutorial!"));

        // Put videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3, video4 };

        // Display video info and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
