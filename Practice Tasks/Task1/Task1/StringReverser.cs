namespace Task1
{
    public static class StringReverser
    {
        public static string SplitAndReverse(string str)
        {
            if (str.Equals(string.Empty) || str == null)
                throw new NullReferenceException("String that given was empty");
            
            if (str.Length % 2 == 0)
            {
                int stringLength = str.Length / 2;
                string firstPart = str.Substring(0, stringLength).ReverseString();
                string secondPart = str.Substring(stringLength, stringLength).ReverseString();
                
                return new string(firstPart + secondPart);
            }
            return str.Insert(0, str.ReverseString());
        }
    }
}