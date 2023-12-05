using Task1.Utility;
using Task1.Utility.Sorting;

namespace Task1
{
    public static class Program
    {
        public static void Main()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();
            Console.WriteLine("Введите тип сортировки (1 - QuickSort/2 - TreeSort): ");
            SortingMode sortingMode = (SortingMode)Int32.Parse(Console.ReadLine());

            if (!Enum.GetNames(typeof(SortingMode)).Any(e => e.Equals(sortingMode.ToString())))
            {
                throw new NullReferenceException("Enum value that given wasn't found in SortingMode");
            }
            
            StringModifier modifier = new StringModifier(input, sortingMode);
            
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