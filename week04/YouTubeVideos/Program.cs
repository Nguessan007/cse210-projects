using System;
using System.Collections.Generic;

// Comment class
class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Video class
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        var video1 = new Video("C# Basics", "Alice", 300);
        video1.AddComment(new Comment("Bob", "Great explanation!"));
        video1.AddComment(new Comment("Charlie", "Thanks for this video."));
        video1.AddComment(new Comment("Dana", "Very helpful!"));

        var video2 = new Video("OOP Concepts", "John", 420);
        video2.AddComment(new Comment("Eva", "I love OOP!"));
        video2.AddComment(new Comment("Frank", "This cleared my doubts."));
        video2.AddComment(new Comment("Grace", "Amazing content!"));

        var video3 = new Video("LINQ Tutorial", "Emma", 360);
        video3.AddComment(new Comment("Henry", "LINQ is so powerful."));
        video3.AddComment(new Comment("Ivy", "Nice examples."));
        video3.AddComment(new Comment("Jack", "Very clear explanation."));

        // Put videos in a list
        List<Video> videos = new List<Video>() { video1, video2, video3 };

        // Display info for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine(new string('-', 40));
        }
    }
}
