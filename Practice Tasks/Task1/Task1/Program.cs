namespace Task1
{
    public static class Program
    {
        public static void Main()
        {
            List<string> testStrings = new List<string>() { "a", "abcdef", "abcde", "school", "maxim", "tech", "draniki so smetanoi"};

            foreach (string str in testStrings)
            {
                StringReverserContext context = StringReverser.SplitAndReverse(str);
                Console.WriteLine($"{context.Result}");
                Console.WriteLine($"Максимальная строка, где края - гласные: {context.MaxVowelString}");
                foreach (KeyValuePair<char, int> pair in context.CharCount)
                {
                    Console.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
        }
    }
}