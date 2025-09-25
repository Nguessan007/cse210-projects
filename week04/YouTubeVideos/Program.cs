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

class Program
{
    static void Main()
    {
        Video video = new Video { Title = "OOP in C#", Author = "John Doe", Length = 600 };

        video.Comments.Add(new Comment { CommenterName = "Alice", Text = "Great explanation!" });
        video.Comments.Add(new Comment { CommenterName = "Bob", Text = "Very helpful, thanks." });

        video.DisplayInfo();
    }
}
