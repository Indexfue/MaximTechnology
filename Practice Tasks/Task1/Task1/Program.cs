namespace Task1
{
    public static class Program
    {
        public static void Main()
        {
            List<string> testStrings = new List<string>() { "a", "abcdef", "abcde", "school", "maxim", "tech", "draniki so smetanoi"};

            foreach (string str in testStrings)
            {
                Console.WriteLine($"{StringReverser.SplitAndReverse(str)} is even: {str.Length % 2 == 0}");
            }
        }
    }
}