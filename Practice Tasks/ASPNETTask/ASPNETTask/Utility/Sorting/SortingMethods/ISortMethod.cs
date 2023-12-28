namespace ASPNETTask.Utility.Sorting.SortingMethods;

public interface ISortMethod<T> where T: IComparable
{
    public List<T> Sort(List<T> data);
}