using System.Collections;

namespace Task1.Utility.SortingMethods
{
    public sealed class TreeSort<T>: ISortMethod<T> where T: IComparable
    {
        public List<T> Sort(List<T> data)
        {
            List<T> tempData = new List<T>(data);
            List<T> sortedData = Behave(ref tempData);
            return sortedData;
        }
        
        private List<T> Behave(ref List<T> data)
        {
            var treeNode = new TreeNode<T>(data[0]);
            for (int i = 1; i < data.Count; i++)
            {
                treeNode.Insert(new TreeNode<T>(data[i]));
            }

            return treeNode.Transform();
        }
    }
    
    public class TreeNode<T> where T: IComparable
    {
        public T Data { get; set; }
        
        public TreeNode<T>? Left { get; set; }
        
        public TreeNode<T>? Right { get; set; }
        
        public TreeNode(T data)
        {
            Data = data;
        }
        
        public void Insert(TreeNode<T> node)
        {
            if (node.Data.CompareTo(Data) <= 0)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }
        
        public List<T> Transform(List<T>? elements = null)
        {
            if (elements == null)
            {
                elements = new List<T>();
            }

            if (Left != null)
            {
                Left.Transform(elements);   
            }

            elements.Add(Data);

            if (Right != null)
            {              
                Right.Transform(elements);
            }

            return elements.ToList();
        }
    }
}