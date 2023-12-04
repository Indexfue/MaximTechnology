namespace Task1
{
    public static class Program
    {
        public static void Main()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();
          
            StringReverserContext context = StringReverser.ReverseByParity(input);
          
            Console.WriteLine(context.Result);
          
            foreach (KeyValuePair<char, int> pair in context.CharCount)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}