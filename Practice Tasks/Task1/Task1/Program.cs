namespace Task1
{
    public static class Program
    {
        public static void Main()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();
            Console.WriteLine(StringReverser.ReverseByParity(input));
        }
    }
}