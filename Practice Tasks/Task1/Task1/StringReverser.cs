namespace Task1
{
    public static class StringReverser
    {
        private static char[] s_allowedChars = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        
        /// <summary>
        /// Reverse the odd string and adding to original one, or reversing halves of even string and concatenate them
        /// </summary>
        /// <param name="str">Original string</param>
        /// <returns>Reversed string</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static string ReverseByParity(string str)
        {
            if (IsStringCorrect(str))
            {
                string newString;
                
                if (str.Length % 2 == 0)
                {
                    int midPoint = str.Length / 2;
                    string firstPart = str.Substring(0, midPoint).ReverseString();
                    string secondPart = str.Substring(midPoint, midPoint).ReverseString();
                
                    newString = new string(firstPart + secondPart);
                    return new string(newString);
                }
                newString = str.Insert(0, str.ReverseString());
                return new string(newString);
            }
            return null;
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
                    $"These disallowed chars was in {str} string: {new string(disallowedChars.ToArray())}");
            }
            return true;
        }
    }
}