namespace Task3_project;


public static class Program
{
    //      ----- IntComparerFoo for delegate -----
    private static int IntComparerFoo(int x, int y)
    {
        return x.CompareTo(y);
    }
    
    
    public static void Main()
    {
        var a = new[] { 1, 2, 7, 4, 9, 3, 10, 5, 6, 8 };
        
        
        //      ----- Insertion Sort -----
        try
        {
            Console.WriteLine($"{Environment.NewLine} ----- Insertion Sort ----- {Environment.NewLine}");
            var b = a.Sort(ArraySortExtension.SortOrder.Ascending, ArraySortExtension.SortAlgorithm.InsertionSort);
            var c = a.Sort(
                ArraySortExtension.SortOrder.Ascending, ArraySortExtension.SortAlgorithm.InsertionSort,
                new IntComparer());
            var d = a.Sort(
                ArraySortExtension.SortOrder.Descending, ArraySortExtension.SortAlgorithm.InsertionSort,
                Comparer<int>.Create(new Comparison<int>(IntComparerFoo)));
            var e = a.Sort(
                ArraySortExtension.SortOrder.Descending, ArraySortExtension.SortAlgorithm.InsertionSort,
                new Comparison<int>(IntComparerFoo));
            
            Console.Write("a =>  ");
            foreach (var item in a) Console.Write($"{item} ");
            Console.WriteLine($"{Environment.NewLine}");
        
            Console.Write("b =>  ");
            foreach (var item in b) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("c =>  ");
            foreach (var item in c) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("d =>  ");
            foreach (var item in d) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("e =>  ");
            foreach (var item in e) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
            
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"{ex.Message}, {ex.ActualValue}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        
        //      ----- Selection Sort -----
        try
        {
            Console.WriteLine($"{Environment.NewLine} ----- Selection Sort ----- {Environment.NewLine}");
            var b = a.Sort(ArraySortExtension.SortOrder.Ascending, ArraySortExtension.SortAlgorithm.SelectionSort);
            var c = a.Sort(
                ArraySortExtension.SortOrder.Ascending, ArraySortExtension.SortAlgorithm.SelectionSort,
                new IntComparer());
            var d = a.Sort(
                ArraySortExtension.SortOrder.Descending, ArraySortExtension.SortAlgorithm.SelectionSort,
                Comparer<int>.Create(new Comparison<int>(IntComparerFoo)));
            var e = a.Sort(
                ArraySortExtension.SortOrder.Descending, ArraySortExtension.SortAlgorithm.SelectionSort,
                new Comparison<int>(IntComparerFoo));
            
            Console.Write("a =>  ");
            foreach (var item in a) Console.Write($"{item} ");
            Console.WriteLine($"{Environment.NewLine}");
        
            Console.Write("b =>  ");
            foreach (var item in b) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("c =>  ");
            foreach (var item in c) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("d =>  ");
            foreach (var item in d) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("e =>  ");
            foreach (var item in e) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
            
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"{ex.Message}, {ex.ActualValue}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        
        //      ----- Heap Sort -----
        try
        {
            Console.WriteLine($"{Environment.NewLine} ----- Heap Sort ----- {Environment.NewLine}");
            var b = a.Sort(ArraySortExtension.SortOrder.Ascending, ArraySortExtension.SortAlgorithm.HeapSort);
            var c = a.Sort(
                ArraySortExtension.SortOrder.Ascending, ArraySortExtension.SortAlgorithm.HeapSort,
                new IntComparer());
            var d = a.Sort(
                ArraySortExtension.SortOrder.Descending, ArraySortExtension.SortAlgorithm.HeapSort,
                Comparer<int>.Create(new Comparison<int>(IntComparerFoo)));
            var e = a.Sort(
                ArraySortExtension.SortOrder.Descending, ArraySortExtension.SortAlgorithm.HeapSort,
                new Comparison<int>(IntComparerFoo));
            
            Console.Write("a =>  ");
            foreach (var item in a) Console.Write($"{item} ");
            Console.WriteLine($"{Environment.NewLine}");
        
            Console.Write("b =>  ");
            foreach (var item in b) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("c =>  ");
            foreach (var item in c) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("d =>  ");
            foreach (var item in d) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("e =>  ");
            foreach (var item in e) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
            
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"{ex.Message}, {ex.ActualValue}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        
        //      ----- Quick Sort -----
        try
        {
            Console.WriteLine($"{Environment.NewLine} ----- Quick Sort ----- {Environment.NewLine}");
            var b = a.Sort(ArraySortExtension.SortOrder.Ascending, ArraySortExtension.SortAlgorithm.QSort);
            var c = a.Sort(
                ArraySortExtension.SortOrder.Ascending, ArraySortExtension.SortAlgorithm.QSort,
                new IntComparer());
            var d = a.Sort(
                ArraySortExtension.SortOrder.Descending, ArraySortExtension.SortAlgorithm.QSort,
                Comparer<int>.Create(new Comparison<int>(IntComparerFoo)));
            var e = a.Sort(
                ArraySortExtension.SortOrder.Descending, ArraySortExtension.SortAlgorithm.QSort,
                new Comparison<int>(IntComparerFoo));
            
            Console.Write("a =>  ");
            foreach (var item in a) Console.Write($"{item} ");
            Console.WriteLine($"{Environment.NewLine}");
        
            Console.Write("b =>  ");
            foreach (var item in b) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("c =>  ");
            foreach (var item in c) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("d =>  ");
            foreach (var item in d) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("e =>  ");
            foreach (var item in e) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
            
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"{ex.Message}, {ex.ActualValue}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        
        //      ----- Merge Sort -----
        try
        {
            Console.WriteLine($"{Environment.NewLine} ----- Merge Sort ----- {Environment.NewLine}");
            var b = a.Sort(ArraySortExtension.SortOrder.Ascending, ArraySortExtension.SortAlgorithm.MergeSort);
            var c = a.Sort(
                ArraySortExtension.SortOrder.Ascending, ArraySortExtension.SortAlgorithm.MergeSort,
                new IntComparer());
            var d = a.Sort(
                ArraySortExtension.SortOrder.Descending, ArraySortExtension.SortAlgorithm.MergeSort,
                Comparer<int>.Create(new Comparison<int>(IntComparerFoo)));
            var e = a.Sort(
                ArraySortExtension.SortOrder.Descending, ArraySortExtension.SortAlgorithm.MergeSort,
                new Comparison<int>(IntComparerFoo));
            
            Console.Write("a =>  ");
            foreach (var item in a) Console.Write($"{item} ");
            Console.WriteLine($"{Environment.NewLine}");
        
            Console.Write("b =>  ");
            foreach (var item in b) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("c =>  ");
            foreach (var item in c) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("d =>  ");
            foreach (var item in d) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
        
            Console.Write("e =>  ");
            foreach (var item in e) Console.Write($"{item} ");
            Console.Write($"{Environment.NewLine}");
            
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"{ex.Message}, {ex.ActualValue}");
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}


