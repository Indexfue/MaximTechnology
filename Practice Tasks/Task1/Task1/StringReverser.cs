namespace Task1
{
    public static class StringReverser
    {
        /// <summary>
        /// Reverse the odd string and adding to original one, or reversing halves of even string and concatenate them
        /// </summary>
        /// <param name="str">Original string</param>
        /// <returns>Reversed string</returns>
        /// <exception cref="NullReferenceException"></exception>
        public static string ReverseByParity(string str)
        {
            if (str.Equals(string.Empty) || str == null)
                throw new NullReferenceException("String that given was empty");
            
            if (str.Length % 2 == 0)
            {
                int midPoint = str.Length / 2;
                string firstPart = str.Substring(0, midPoint).ReverseString();
                string secondPart = str.Substring(midPoint, midPoint).ReverseString();
                
                return new string(firstPart + secondPart);
            }
            return str.Insert(0, str.ReverseString());
        }
    }
}