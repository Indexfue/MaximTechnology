namespace Task1
{
    public sealed class StringReverserContext
    {
        private char[] _consonantLetters = "bcdfghjklmnpqrstvwxz".ToCharArray();
        
        public string? Result { get; }
        public string MaxVowelString { get; }
        public Dictionary<char, int> CharCount { get; }

        public StringReverserContext(string? result)
        {
            Result = result;
            CharCount = GetCharCount(Result);
            MaxVowelString = GetMaxVowelString(Result);
        }

        private Dictionary<char, int> GetCharCount(string? str)
        {
            if (str == null || str.Equals(string.Empty))
                throw new NullReferenceException("String that given was null");
            
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            foreach (char strChar in str)
            {
                if (charCount.ContainsKey(strChar))
                {
                    charCount[strChar] += 1;
                    continue;
                }
                charCount.Add(strChar, 1);
            }
            return charCount;
        }

        private string GetMaxVowelString(string str)
        {
            return str.Trim(_consonantLetters);
        }
    }
}