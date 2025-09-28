using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    // Holds the Reference and words for a scripture passage.
    // Responsible for displaying and hiding words.
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private static Random _rand = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference ?? throw new ArgumentNullException(nameof(reference));
            if (text == null) text = string.Empty;

            // Split text into tokens by whitespace. Tokens keep punctuation attached.
            // Example tokens: "Son," "world" "life."
            var tokens = text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
            _words = new List<Word>();
            foreach (var t in tokens)
            {
                _words.Add(new Word(t));
            }
        }

        // Display the reference and the current (partially hidden) scripture text.
        public void Display()
        {
            Console.WriteLine(_reference.ToString());
            Console.WriteLine();
            for (int i = 0; i < _words.Count; i++)
            {
                Console.Write(_words[i].Display());
                if (i < _words.Count - 1) Console.Write(" ");
            }
            Console.WriteLine();
        }

        // Returns true when every word with letters is hidden
        public bool IsCompletelyHidden()
        {
            foreach (var w in _words)
            {
                if (w.LetterCount > 0 && !w.IsHidden) return false;
            }
            return true;
        }

        // Hide up to 'count' words chosen at random from those that are currently visible.
        // If fewer visible words remain, hide all remaining.
        public void HideRandomWords(int count)
        {
            if (count <= 0) return;

            // collect indices of words that can be hidden (letterCount > 0 and not hidden)
            var candidates = new List<int>();
            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden && _words[i].LetterCount > 0)
                    candidates.Add(i);
            }

            if (candidates.Count == 0) return;

            // hide up to 'count' unique words
            int toHide = Math.Min(count, candidates.Count);
            for (int i = 0; i < toHide; i++)
            {
                int pick = _rand.Next(candidates.Count);
                int idx = candidates[pick];
                _words[idx].Hide();
                candidates.RemoveAt(pick);
            }
        }
    }
}
