namespace ALE2.Models
{
    public class Word
    {
        public string word { get; }
        public bool existsInAutomata { get; }
        public bool expectedWordExistance { get; }

        public Word(string word, bool existsInAutomata, bool expectedWordExistance)
        {
            this.word = word;
            this.existsInAutomata = existsInAutomata;
            this.expectedWordExistance = expectedWordExistance;
        }

        public bool Equals(Word word)
        {
            if (this.word != word.word) return false;
            if (this.existsInAutomata != word.existsInAutomata || this.expectedWordExistance != word.expectedWordExistance) return false;
            return true;
        }
    }
}
