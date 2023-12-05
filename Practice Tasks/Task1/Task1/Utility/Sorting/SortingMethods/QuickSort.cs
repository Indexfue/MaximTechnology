namespace Task1.Utility.Sorting.SortingMethods
{
    public sealed class QuickSort<T>: ISortMethod<T> where T: IComparable
    {
        public List<T> Sort(List<T> data)
        {
            List<T> tempData = new List<T>(data);
            List<T> sortedData = Behave(ref tempData, 0, data.Count - 1);
            return sortedData;
        }
        
        private List<T> Behave(ref List<T> data, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = Partition(data, left, right);

                Behave(ref data, left, partitionIndex - 1);
                Behave(ref data, partitionIndex + 1, right);
            }

            return data;
        }
            
        private int Partition(List<T> data, int left, int right)
        {
            var pivot = data[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (data[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    (data[i], data[j]) = (data[j], data[i]);
                }
            }
            (data[i + 1], data[right]) = (data[right], data[i + 1]);

            return i + 1;
        }
    }
}