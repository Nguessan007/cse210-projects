using System.Text;

namespace ScriptureMemorizer
{
    // Represents a single token/word in the scripture text.
    // Hiding replaces alphabetic characters with underscores but preserves punctuation.
    public class Word
    {
        private readonly string _text;
        private bool _hidden;

        public Word(string text)
        {
            _text = text ?? string.Empty;
            _hidden = false;
        }

        // Whether this word is currently hidden
        public bool IsHidden => _hidden;

        // Hide the word (alphabetic characters will be masked in Display)
        public void Hide()
        {
            _hidden = true;
        }

        // Number of alphabetic characters in the token (used to skip punctuation-only tokens)
        public int LetterCount
        {
            get
            {
                int count = 0;
                foreach (char c in _text)
                {
                    if (char.IsLetter(c)) count++;
                }
                return count;
            }
        }

        // Returns the string to display: either the original token or masked version
        public string Display()
        {
            if (!_hidden) return _text;

            var sb = new StringBuilder(_text.Length);
            foreach (char c in _text)
            {
                sb.Append(char.IsLetter(c) ? '_' : c);
            }
            return sb.ToString();
        }
    }
}
