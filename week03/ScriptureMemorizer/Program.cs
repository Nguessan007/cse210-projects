using System;
using ScriptureMemorizer;

class Program
{
    static void Main(string[] args)
    {
        // Example scripture - you can replace this with another passage or
        // add a small library and randomly choose one.
        // Demonstrates single verse constructor:
        Reference reference = new Reference("John", 3, 16);

        string text = "For God so loved the world that he gave his one and only Son, " +
                      "that whoever believes in him shall not perish but have eternal life.";

        // Create Scripture object which tokenizes the text into Word objects.
        Scripture scripture = new Scripture(reference, text);

        Console.WriteLine("Scripture Memorizer");
        Console.WriteLine("-------------------");
        Console.WriteLine("Press ENTER to hide a few words. Type 'quit' and press ENTER to exit.\n");
        Console.WriteLine("Press any key to start...");
        Console.ReadKey();

        // Main loop
        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Good work — program will now end.");
                break;
            }

            Console.WriteLine("\nPress ENTER to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && input.Trim().ToLower() == "quit")
            {
                Console.WriteLine("Quitting — goodbye!");
                break;
            }

            // Hide a "few" words per iteration. You can change this number.
            int wordsToHidePerStep = 3;
            scripture.HideRandomWords(wordsToHidePerStep);
        }
    }
}

/*
EXCEEDING / DESIGN NOTES (include in Program.cs as required by assignment):

- This solution uses classes that implement encapsulation:
  - Reference: handles formatting and parsing of scripture references (single verse and ranges).
  - Word: represents a token and handles masking letters while preserving punctuation.
  - Scripture: manages collection of Word objects, display, and random hiding logic.

- Extras beyond core requirements:
  - Hiding logic only selects from currently visible words (prevents "re-hiding" already hidden tokens).
  - Masking preserves punctuation (commas, periods, hyphens remain visible).
  - Reference class includes a parser that accepts formatted strings such as "Proverbs 3:5-6".
  - The text tokenization keeps punctuation attached to its word so the display looks natural.

- Ideas to further exceed requirements:
  - Add a scripture library file (JSON or CSV) and randomly pick passages.
  - Allow the user to choose how many words to hide per step.
  - Add a "restore" or "reveal one word" feature for hinting.
  - Save user progress to a file so memorization can continue later.
*/
