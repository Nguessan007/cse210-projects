using System;

namespace ScriptureMemorizer
{
    // Represents a scripture reference, e.g. "John 3:16" or "Proverbs 3:5-6"
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verseStart;
        private int? _verseEnd; // null when single verse

        // Constructor for single verse: "Book", chapter, verse
        public Reference(string book, int chapter, int verse) : this(book, chapter, verse, null) { }

        // Constructor for verse range: e.g. verseStart=5 verseEnd=6
        public Reference(string book, int chapter, int verseStart, int? verseEnd)
        {
            _book = book ?? throw new ArgumentNullException(nameof(book));
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseEnd;
        }

        // Parse a formatted reference string like "John 3:16" or "Proverbs 3:5-6"
        public Reference(string referenceString)
        {
            if (string.IsNullOrWhiteSpace(referenceString))
                throw new ArgumentException("Reference string is empty.");

            // find last space (book may contain spaces, e.g., "1 John")
            int lastSpace = referenceString.LastIndexOf(' ');
            if (lastSpace < 0)
                throw new ArgumentException("Invalid reference format.");

            _book = referenceString.Substring(0, lastSpace).Trim();
            string chapVerse = referenceString.Substring(lastSpace + 1).Trim();

            var parts = chapVerse.Split(':');
            if (parts.Length != 2)
                throw new ArgumentException("Invalid chapter:verse format.");

            if (!int.TryParse(parts[0], out _chapter))
                throw new ArgumentException("Invalid chapter number.");

            string versePart = parts[1];
            if (versePart.Contains("-"))
            {
                var vr = versePart.Split('-');
                if (!int.TryParse(vr[0], out _verseStart) || !int.TryParse(vr[1], out int end))
                    throw new ArgumentException("Invalid verse range.");
                _verseEnd = end;
            }
            else
            {
                if (!int.TryParse(versePart, out _verseStart))
                    throw new ArgumentException("Invalid verse number.");
                _verseEnd = null;
            }
        }

        public override string ToString()
        {
            return _verseEnd.HasValue
                ? $"{_book} {_chapter}:{_verseStart}-{_verseEnd.Value}"
                : $"{_book} {_chapter}:{_verseStart}";
        }
    }
}
