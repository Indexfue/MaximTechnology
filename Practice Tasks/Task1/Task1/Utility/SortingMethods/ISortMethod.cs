using System.Collections;

namespace Task1.Utility.SortingMethods;

public interface ISortMethod<T> where T: IComparable
{
    public List<T> Sort(List<T> data);
}