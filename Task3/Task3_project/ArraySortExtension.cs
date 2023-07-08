namespace Task3_project;


public static class ArraySortExtension
{
    
    public enum SortOrder
    {
        Ascending,
        Descending
    }

    public enum SortAlgorithm
    {
        InsertionSort, 
        SelectionSort,
        HeapSort,
        QSort,
        MergeSort
    }

    public static T?[] Sort<T>(
        this T?[]? source, SortOrder order, SortAlgorithm algorithm)
        where T : IComparable<T>
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        var comparerDelegate = new Comparison<T?>((x, y) =>
        {
            if (x == null && y != null) return -1;
            if (x != null && y == null) return 1;
            if (x == null && y == null) return 0;
            if (x != null && y != null) return x.CompareTo(y);
            return 0;
        });
        if (source.Clone() is not T[] result) throw new AggregateException("Cloning error!");

        TakeAlgorithm(result, order, algorithm, comparerDelegate);

        return result;
    }

    public static T?[] Sort<T>(
        this T?[]? source, SortOrder order, SortAlgorithm algorithm, IComparer<T?>? comparer)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        var comparerDelegate = new Comparison<T?>(comparer.Compare);
        if (source.Clone() is not T[] result) throw new AggregateException("Cloning error!");
        
        TakeAlgorithm(result, order, algorithm, comparerDelegate);

        return result;
    }
    
    public static T?[] Sort<T>(
        this T?[]? source, SortOrder order, SortAlgorithm algorithm, Comparer<T?>? comparer)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        var comparerDelegate = new Comparison<T?>(comparer.Compare);
        if (source.Clone() is not T[] result) throw new AggregateException("Cloning error!");
        
        TakeAlgorithm(result, order, algorithm, comparerDelegate);

        return result;
    }
    
    public static T?[] Sort<T>(
        this T?[]? source, SortOrder order, SortAlgorithm algorithm, Comparison<T?>? comparerDelegate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (comparerDelegate == null) throw new ArgumentNullException(nameof(comparerDelegate));
        if (source.Clone() is not T[] result) throw new AggregateException("Cloning error!");

        TakeAlgorithm(result, order, algorithm, comparerDelegate);

        return result;
    }

    private static void TakeAlgorithm<T>(T?[] arr, SortOrder order, SortAlgorithm algorithm, Comparison<T?> comparerDelegate)
    {
        switch (algorithm)
        {
            case SortAlgorithm.InsertionSort:
                InsertionSort(arr, comparerDelegate, order);
                break;
            case SortAlgorithm.SelectionSort:
                SelectionSort(arr, comparerDelegate, order);
                break;
            case SortAlgorithm.HeapSort:
                HeapSort(arr, comparerDelegate, order);
                break;
            case SortAlgorithm.QSort:
                QSort(arr, comparerDelegate, order);
                break;
            case SortAlgorithm.MergeSort:
                MergeSort(arr, comparerDelegate, order);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, "Invalid algorithm type!");
        }
    }
    
    private static void InsertionSort<T>(T[] arr, Comparison<T> comparer, SortOrder order)
    {
        var len = arr.Length;
        var comparerIndex = order == SortOrder.Ascending ? 1 : -1;
        for (var i = 1; i < len; i++)
            for (var j = i; j > 0 && comparer.Invoke(arr[j - 1], arr[j]) == comparerIndex; --j)
            {
                (arr[j - 1], arr[j]) = (arr[j], arr[j - 1]);
            }
    }
    
    private static void SelectionSort<T>(T[] arr, Comparison<T> comparer, SortOrder order)
    {
        var len = arr.Length;
        var comparerIndex = order == SortOrder.Ascending ? -1 : 1;
        for (var i = 0; i < len - 1; ++i)
        {
            var target = i;
            for (var j = i + 1; j < len; ++j)
                if (comparer.Invoke(arr[j], arr[target]) == comparerIndex) target = j;
            (arr[i], arr[target]) = (arr[target], arr[i]);
        }
    }

    private static void HeapSort<T>(T[] arr, Comparison<T> comparer, SortOrder order)
    {
        var comparerIndex = order == SortOrder.Ascending ? 1 : -1;
        var len = arr.Length;
        
        for (var i = len / 2 - 1; i >= 0; --i)
            Heapify(arr, len, i, comparer, comparerIndex);
        
        for (var i = len - 1; i >= 0; --i)
        {
            (arr[0], arr[i]) = (arr[i], arr[0]);

            Heapify(arr, i, 0, comparer, comparerIndex);
        }
    }

    private static void Heapify<T>(T[] arr, int len, int i, Comparison<T> comparer, int comparerIndex)
    {
        var target = i;
        var left = 2 * i + 1;
        var right = 2 * i + 2;
        
        if (left < len && comparer.Invoke(arr[left], arr[target]) == comparerIndex)
            target = left;
        
        if (right < len && comparer.Invoke(arr[right], arr[target]) == comparerIndex)
            target = right;

        if (target == i) return;
        (arr[i], arr[target]) = (arr[target], arr[i]);

        Heapify(arr, len, target, comparer, comparerIndex);
    }
    
    private static void QSort<T>(T[] arr, Comparison<T> comparer, SortOrder order)
    {
        var comparerIndex = order == SortOrder.Ascending ? -1 : 1;
        QuickSortRecursion(arr, 0, arr.Length - 1, comparer, comparerIndex);
    }
    
    private static void QuickSortRecursion<T>(T[] arr, int minIndex, int maxIndex, Comparison<T> comparer, int comparerIndex)
    {
        if (minIndex >= maxIndex) return;

        var pivotIndex = Partition(arr, minIndex, maxIndex, comparer, comparerIndex);
        QuickSortRecursion(arr, minIndex, pivotIndex - 1, comparer, comparerIndex);
        QuickSortRecursion(arr, pivotIndex + 1, maxIndex, comparer, comparerIndex);
    }
    
    private static int Partition<T>(T[] arr, int minIndex, int maxIndex, Comparison<T> comparer, int comparerIndex)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; ++i)
            if (comparer.Invoke(arr[i], arr[maxIndex]) == comparerIndex)
            {
                pivot++;
                (arr[pivot], arr[i]) = (arr[i], arr[pivot]);
            }
        pivot++;
        (arr[pivot], arr[maxIndex]) = (arr[maxIndex], arr[pivot]);
        return pivot;
    }

    private static void MergeSort<T>(T[] arr, Comparison<T> comparer, SortOrder order)
    {
        var comparerIndex = order == SortOrder.Ascending ? -1 : 1;
        MergeSortRecursion(arr, 0, arr.Length - 1, comparer, comparerIndex);
    }
    
    private static void MergeSortRecursion<T>(T[] array, int lowIndex, int highIndex, Comparison<T> comparer, int comparerIndex)
    {
        if (lowIndex >= highIndex) return;
        var middleIndex = (lowIndex + highIndex) / 2;
        MergeSortRecursion(array, lowIndex, middleIndex, comparer, comparerIndex);
        MergeSortRecursion(array, middleIndex + 1, highIndex, comparer, comparerIndex);
        Merge(array, lowIndex, middleIndex, highIndex, comparer, comparerIndex);
    }
    
    private static void Merge<T>(T[] arr, int lowIndex, int middleIndex, int highIndex, Comparison<T> comparer, int comparerIndex)
    {
        var left = lowIndex;
        var right = middleIndex + 1;
        var tempArr = new T[highIndex - lowIndex + 1];
        var index = 0;

        while (left <= middleIndex && right <= highIndex)
        {
            if (comparer.Invoke(arr[left], arr[right]) == comparerIndex)
            {
                tempArr[index] = arr[left];
                left++;
            }
            else
            {
                tempArr[index] = arr[right];
                right++;
            }
            index++;
        }

        for (var i = left; i <= middleIndex; i++)
        {
            tempArr[index] = arr[i];
            index++;
        }

        for (var i = right; i <= highIndex; i++)
        {
            tempArr[index] = arr[i];
            index++;
        }

        for (var i = 0; i < tempArr.Length; i++) 
            arr[lowIndex + i] = tempArr[i];
    }

}