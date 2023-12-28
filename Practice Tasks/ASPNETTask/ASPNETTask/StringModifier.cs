using ASPNETTask.Utility.Networking;
using ASPNETTask.Utility.Sorting;

namespace ASPNETTask
{
    public sealed class StringModifier
    {
        private char[] _allowedChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private char[] _consonantLetters = "bcdfghjklmnpqrstvwxz".ToCharArray();

        public string Result { get; }
        public string SortedResult { get; }
        public string MaxVowelString { get; }
        public string RandomRemovedString { get; }
        public Dictionary<char, int> CharCount { get; }
        
        public StringModifier(string? str, SortingMode sortingMode)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
            {
                throw new NullReferenceException("Given string was null/empty/full of whitespaces");
            }
            
            Result = ReverseByParity(str);
            SortedResult = String.Join("", Sorter.Sort<char>(Result.ToCharArray().ToList(), sortingMode));
            MaxVowelString = GetMaxVowelString(Result);
            CharCount = GetCharCount(Result);
            RandomRemovedString = RemoveRandomCharacter(Result).Result;
        }
        
        private string ReverseByParity(string str)
        {
            if (IsStringCorrect(str))
            {
                if (str.Length % 2 == 0)
                {
                    int stringLength = str.Length / 2;
                    string firstPart = str.Substring(0, stringLength).ReverseString();
                    string secondPart = str.Substring(stringLength, stringLength).ReverseString();
                    
                    return new string(firstPart + secondPart);
                }
                return str.Insert(0, str.ReverseString());
            }
            return null;
        }

        private bool IsStringCorrect(string str)
        {
            List<char> disallowedChars = new List<char>();
             
            foreach (char stringChar in str)
            {
                if (!_allowedChars.Contains(stringChar) || !Char.IsLower(stringChar))
                {
                    disallowedChars.Add(stringChar);
                }
            }

            if (disallowedChars.Count > 0)
            {
                throw new ArgumentException(
                    $"These disallowed chars was in {str} string: {new string(disallowedChars.ToArray())}");
            }
            return true;
        }
        
        private Dictionary<char, int> GetCharCount(string str)
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
        
        private async Task<string> RemoveRandomCharacter(string str)
        {
            RandomGenerator randomNumberGenerator = new RandomGenerator();
            int stringLength = str.Length;

            int randomIndex = await randomNumberGenerator.GetRandomNumber(stringLength);

            if (randomIndex >= stringLength)
            {
                throw new IndexOutOfRangeException("Index of deleting char was greater than string length");
            }

            char[] resultArray = str.ToCharArray();
            resultArray[randomIndex] = ' ';
            return new string(resultArray);
        }

        private string GetMaxVowelString(string str)
        {
            return str.Trim(_consonantLetters);
        }
    }
}