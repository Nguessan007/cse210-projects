using System;

// Entry.cs (representation of a single entry)
public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString() => $"{Date} | {Prompt} | {Response}";
}

// Journal.cs (excerpt - Journal hides internal storage and file format)
public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string> { /* prompt list */ };
    private Random _random = new Random();

    // Public method: callers don't care how prompt is chosen or how entry is stored
    public void WriteNewEntry()
    {
        string prompt = _prompts[_random.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        // internal detail: we create an Entry and add it to a private list
        _entries.Add(new Entry(date, prompt, response));
    }

    // Public method: callers just pass a filename; Journal controls file format
    public void SaveToFile(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            foreach (var e in _entries)
                writer.WriteLine($"{e.Date}|{e.Prompt}|{e.Response}");
        }
    }
}
