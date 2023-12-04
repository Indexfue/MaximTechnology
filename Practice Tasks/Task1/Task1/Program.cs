using Task1.Utility;

namespace Task1
{
    public static class Program
    {
        public static void Main()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();
          
            StringModifier modifier = new StringModifier(input, SortingMode.QuickSort);
            
            Console.WriteLine(modifier.Result);
            Console.WriteLine($"Максимальная строка, где края - гласные: {modifier.MaxVowelString}");
            Console.WriteLine($"Отсортированная строка: {modifier.SortedResult}");
          
            foreach (KeyValuePair<char, int> pair in modifier.CharCount)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}