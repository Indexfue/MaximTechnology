namespace Task1
{
    public static class StringReverser
    {
        private static char[] s_allowedChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        
        public static string SplitAndReverse(string str)
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
            return string.Empty;
        }

        private static bool IsStringCorrect(string str)
        {
            List<char> disallowedChars = new List<char>();
             
            foreach (char stringChar in str)
            {
                if (!s_allowedChars.Contains(stringChar) || !Char.IsLower(stringChar))
                {
                    disallowedChars.Add(stringChar);
                }
            }

            if (disallowedChars.Count > 0)
            {
                throw new ArgumentException(
                    $"These disallowed chars was in string: {new string(disallowedChars.ToArray())}");
            }
            return true;
        }
    }
}