namespace ASPNETTask
{
    public static class StringExtensions
    {
        public static string ReverseString(this string str)
        {
            return new string(str.Reverse().ToArray());
        }
    }   
}