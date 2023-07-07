namespace Task2_project;


public static class EnumerableExtensions
{
    
    /// <summary>
    /// --- CheckUnique ---
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    private static void CheckUnique<T>(List<T> source, IEqualityComparer<T> comparer)
    {
        var length = source.Count;
        for (var i = 0; i < length; ++i)
        {
            for (var k = i + 1; k < length; ++k)
            {
                if (comparer.Equals(source[i], source[k]))
                    throw new ArgumentException("Elements are not unique!", nameof(source));
            }
        }
    }
    
    
    //~~###  4 hours!! I will never delete this, despite the fact, this code is a piece of shit!  ###~~
    
    
    /*
    public static IEnumerable<IEnumerable<T>> Combinations<T>(
        this IEnumerable<T>? source, IEqualityComparer<T>? comparer, int k = 2)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        if (k < 1) throw new ArgumentException("Invalid k!", nameof(k));
    
        var sourceList = source.ToList();
        CheckUnique(sourceList, comparer);
        
        var result = new List<List<T>>();
        var miniRes = new List<T>(k);
    
        for (var i = 0; i < k; ++i)
        {
            miniRes.Add(sourceList.First());
        }
    
        var index = k-1;
        var caret = k-1;
        var uniq = 0;
        var uniqIndex = 0;
        var x = sourceList.Count;
        var maxIndex = x - 1;
        if (maxIndex == 0)
        {
            result.Add(miniRes);
            return result;
        }
    
        while (index >= 0)
        {
            var copy = new List<T>(miniRes);
            result.Add(copy);
            while (caret >= index)
            {
                for (var i = uniq+1; i < maxIndex + 1; ++i)
                {
                    miniRes[caret] = sourceList[i];
                    copy = new List<T>(miniRes);
                    result.Add(copy);
                }
                caret--;
                while (caret >= 0 && miniRes[caret]!.Equals(sourceList[maxIndex])) caret--;
    
                if (caret >= index)
                {
                    if (uniq == maxIndex)
                    {
                        if(uniqIndex != maxIndex) uniqIndex++;
                        uniq = uniqIndex;
                    }
                    else uniq++;
                    do {
                        miniRes[caret] = sourceList[uniq];
                        caret++;
                        if(caret == k-1) miniRes[caret] = sourceList[uniq];
                    } while (caret != k-1);
                    copy = new List<T>(miniRes);
                    result.Add(copy);
                }
            }
            index--;
            uniqIndex = maxIndex > 0 ? 1 : 0;
            uniq = uniqIndex;
            if (index < 0) continue;
            do {
                miniRes[caret] = sourceList[uniq];
                caret++;
                if (caret == k-1) miniRes[caret] = sourceList[uniq];
            } while (caret != k-1);
        }
    
        return result;
    }
    */
    
    
    /// <summary>
    /// --- Combinations ---
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static IEnumerable<IEnumerable<T>> Combinations<T>(
        this IEnumerable<T>? source, IEqualityComparer<T>? comparer, int k = 2)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        if (k < 0) throw new ArgumentException("Negative k!", nameof(k));
    
        var sourceList = source.ToList();
        CheckUnique(sourceList, comparer);

        var result = new List<List<T>>();
        var current = new List<T>();
        
        AllCombinations(sourceList, k, 0, current, result);

        return result;
    }

    private static void AllCombinations<T>(List<T> source, int k, int index, List<T> current, List<List<T>> result)
    {
        
        if (current.Count == k)
        {
            result.Add(current.ToList());
            return;
        }
        for (var i = index; i < source.Count; ++i)
        {
            current.Add(source[i]);
            AllCombinations(source, k, i, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
    
    
    /// <summary>
    /// ---  Subsets ---
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<IEnumerable<T>> Subsets<T>(
        this IEnumerable<T> source, IEqualityComparer<T>? comparer)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));

        var sourceList = source.ToList();
        CheckUnique(sourceList, comparer);
        
        var result = new List<List<T>>();

        var sourceLen = sourceList.Count;
        for (var mask = 0; mask < (1 << sourceLen); ++mask)
        {
            result.Add(new List<T>());

            for (var j = 0; j < sourceLen; ++j)
            {
                if ((mask & (1 << j)) != 0)
                {
                    result.Last().Add(sourceList[j]);
                }
            }
        }
        result.Sort((x, y) => x.Count.CompareTo(y.Count));

        return result;
    }
    
    
    /// <summary>
    /// --- Permutations ---
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<IEnumerable<T>> Permutations<T>(
        this IEnumerable<T>? source, IEqualityComparer<T>? comparer)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));

        var sourceList = source.ToList();
        CheckUnique(sourceList, comparer);
        
        var result = new List<List<T>>();
        AllPermutations(sourceList, new List<T>(), result);
        return result;
    }
    
    private static void AllPermutations<T>(List<T> arr, List<T> current, List<List<T>> result)
    {
        if (arr.Count == 0)
        {
            result.Add(current);
            return;
        }
        for (var i = 0; i < arr.Count; ++i)
        {
            var lst = new List<T>(arr);
            lst.RemoveAt(i);
            var newCurrent = new List<T>(current) { arr[i] };
            AllPermutations(lst, newCurrent, result);
        }
    }
    
}