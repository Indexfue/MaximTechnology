using System.Collections;
using Task1.Utility.SortingMethods;

namespace Task1.Utility
{
    public static class Sorter
    {
        public static List<T> Sort<T>(List<T> data, SortingMode sortingMode) where T: IComparable
        {
            ISortMethod<T> sortingMethod = GetSortingMethod<T>(sortingMode);
            return sortingMethod.Sort(data);
        }

        private static ISortMethod<T> GetSortingMethod<T>(SortingMode sortingMode) where T: IComparable
        {
            switch (sortingMode)
            {
                case SortingMode.QuickSort:
                    return new QuickSort<T>();
                case SortingMode.TreeSort:
                    return new TreeSort<T>();
                default:
                    return null;
            }
        }
    }
}