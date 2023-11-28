namespace Task1
{
    public static class StringReverser
    {
        public static string SplitAndReverse(string str)
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
    }
}