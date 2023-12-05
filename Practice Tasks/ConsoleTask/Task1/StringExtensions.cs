namespace Task1
{
    public static class StringExtensions
    {
        public static string ReverseString(this string str)
        {
            return new string(str.Reverse().ToArray());
        }
    }   
}