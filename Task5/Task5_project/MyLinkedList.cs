using System.Collections;


namespace Task5_project;

public sealed class MyLinkedList<T> : 
    IEquatable<MyLinkedList<T>>,
    ICloneable,
    IEnumerable<T>
{

    private class MyLinkedListNode<T>
    {
        public T? Value { get; set; }
        public MyLinkedListNode<T>? Prev { get; set; }
        public MyLinkedListNode<T>? Next { get; set; }
    }
    
    
    private readonly LinkedList<T> _list;

    
    public MyLinkedList()
    {
        _list = new LinkedList<T>();
    }

    public MyLinkedList(MyLinkedList<T>? other)     //attribute?
    {
        if (ReferenceEquals(other, null)) throw new ArgumentNullException(nameof(other));
        _list = new LinkedList<T>(other._list);
    }

    public MyLinkedList(IEnumerable<T>? other)      //attribute?
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        _list = new LinkedList<T>(other);
    }

    public T this[int index]
    {
        get
        {
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
            var node = _list.First;
            if (node == null) throw new ArgumentOutOfRangeException(nameof(index));
            for (var i = 0; i < index; ++i)
            {
                node = node.Next;
                if (node == null) throw new ArgumentOutOfRangeException(nameof(index));
            }

            return node.Value;
        }

        set
        {
            Delete(index);
            Insert(value, index);
        }
    }

    public MyLinkedList<T> InsertFirst(T value)
    {
        _list.AddFirst(value);
        return this;
    }

    public MyLinkedList<T> InsertLast(T value)
    {
        _list.AddLast(value);
        return this;
    }

    public MyLinkedList<T> Insert(T value, int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        var node = _list.First;
        if (node == null) throw new ArgumentOutOfRangeException(nameof(index));
        for (var i = 0; i < index - 1 ; ++i)
        {
            node = node.Next;
            if (node == null) throw new ArgumentOutOfRangeException(nameof(index));
        }

        _list.AddAfter(node, value);
        
        return this;
    }

    public MyLinkedList<T> DeleteFirst()
    {
        _list.RemoveFirst();
        return this;

    }

    public MyLinkedList<T> DeleteLast()
    {
        _list.RemoveLast();
        return this;
    }

    public MyLinkedList<T> Delete(int index)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
        var node = _list.First;
        if (node == null) throw new ArgumentOutOfRangeException(nameof(index));
        for (var i = 0; i < index; ++i)
        {
            node = node.Next;
            if (node == null) throw new ArgumentOutOfRangeException(nameof(index));
        }

        _list.Remove(node);
        return this;
    }

    public MyLinkedList<T> Reverse()
    {
        return new MyLinkedList<T>(_list.Reverse());
    }

    public static MyLinkedList<T> operator !(MyLinkedList<T> source)
    {
        return source.Reverse();
    }

    public static MyLinkedList<T> Concat(MyLinkedList<T> x, MyLinkedList<T> y)
    {
        return new MyLinkedList<T>(x._list.Concat(y._list));
    }
    
    public static MyLinkedList<T> operator +(MyLinkedList<T> x, MyLinkedList<T> y)
    {
        return Concat(x, y);
    }

    public static MyLinkedList<T> Intersection(MyLinkedList<T> x, MyLinkedList<T> y, IEqualityComparer<T> comparer)
    {
        return new MyLinkedList<T>(x._list.Intersect(y._list, comparer));
    }

    public static MyLinkedList<T> operator &(MyLinkedList<T> x, MyLinkedList<T> y)
    {
        return Intersection(x, y, EqualityComparer<T>.Default);     // default?
    }

    public static MyLinkedList<T> Unite(MyLinkedList<T> x, MyLinkedList<T> y, IEqualityComparer<T> comparer)
    {
        return new MyLinkedList<T>(x._list.Union(y._list, comparer));
    }
    
    public static MyLinkedList<T> operator |(MyLinkedList<T> x, MyLinkedList<T> y)
    {
        return Unite(x, y, EqualityComparer<T>.Default);            // default?
    }
    
    public static MyLinkedList<T> Subtraction(MyLinkedList<T> x, MyLinkedList<T> y, IEqualityComparer<T> comparer)
    {
        return new MyLinkedList<T>(x._list.Except(y._list, comparer));
    }
    
    public static MyLinkedList<T> operator -(MyLinkedList<T> x, MyLinkedList<T> y)
    {
        return Subtraction(x, y, EqualityComparer<T>.Default);     // default?
    }
    
    public MyLinkedList<T> Sorting(IComparer<T>? comparer)
    {
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        var comparerDelegate = new Comparison<T?>(comparer.Compare);
        var result = new List<T>(_list);
        
        InsertionSort(result, comparerDelegate);

        return new MyLinkedList<T>(result);
    }
    
    public MyLinkedList<T> Sorting(Comparer<T>? comparer)
    {
        if (comparer == null) throw new ArgumentNullException(nameof(comparer));
        var comparerDelegate = new Comparison<T?>(comparer.Compare);
        var result = new List<T>(_list);
        
        InsertionSort(result, comparerDelegate);

        return new MyLinkedList<T>(result);
    }
    
    public MyLinkedList<T> Sorting(Comparison<T>? comparerDelegate)
    {
        if (comparerDelegate == null) throw new ArgumentNullException(nameof(comparerDelegate));
        var result = new List<T>(_list);
        
        InsertionSort(result, comparerDelegate);

        return new MyLinkedList<T>(result);
    }

    private void InsertionSort(List<T> arr, Comparison<T> comparer)
    {
        var len = arr.Count;
        for (var i = 1; i < len; i++)
        for (var j = i; j > 0 && comparer.Invoke(arr[j - 1], arr[j]) > 0; --j)
        {
            (arr[j - 1], arr[j]) = (arr[j], arr[j - 1]);
        }
    }

    public void Action(Action<T>? action)
    {
        if (action == null) throw new ArgumentNullException(nameof(action));
        var node = _list.First;
        while (node != null)
        {
            action.Invoke(node.Value);
            node = node.Next;
        }
    }

    public static bool operator ==(MyLinkedList<T> x, MyLinkedList<T> y)
    {
        if (ReferenceEquals(x, null) && ReferenceEquals(y, null)) return true;
        if (ReferenceEquals(x, null) && !ReferenceEquals(y, null)) return false;
        if (!ReferenceEquals(x, null) && ReferenceEquals(y, null)) return false;
        return x!.Equals(y);
    }
    
    public static bool operator !=(MyLinkedList<T> x, MyLinkedList<T> y)
    {
        return !(x == y);
    }

    public static MyLinkedList<T> operator *(MyLinkedList<T>? x, MyLinkedList<T>? y)
    {
        if (ReferenceEquals(x, null)) throw new ArgumentNullException(nameof(x));
        if (ReferenceEquals(y, null)) throw new ArgumentNullException(nameof(y));

        var len = Math.Min(x._list.Count, y._list.Count);
        var result = new MyLinkedList<T>();
        var xNode = x._list.First;
        var yNode = y._list.First;
        
        for (var i = 0; i < len; ++i)
        {
            var item = (xNode!.Value as dynamic) * (yNode!.Value as dynamic);
            result._list.AddLast((T)item);
            xNode = xNode.Next;
            yNode = yNode.Next;
        }

        return result;
    }

    public override int GetHashCode()
    {
        return _list.GetHashCode();
    }

    public override string ToString()
    {
        return string.Join(' ', _list);
    }

    public override bool Equals(object? obj)
    {
        if (obj is MyLinkedList<T> list) return Equals(list);
        return false;
    }
    
    public bool Equals(MyLinkedList<T>? other)
    {
        if (ReferenceEquals(other, null)) return false;
        if (!_list.Count.Equals(other._list.Count)) return false;
        var xNode = _list.First;
        var yNode = other._list.First;
        while (xNode != null && yNode != null)
        {
            if (!xNode.Value!.Equals(yNode.Value)) return false;
            xNode = xNode.Next;
            yNode = yNode.Next;
        }

        return true;
    }
    
    public object Clone()
    {
        return new MyLinkedList<T>(_list);
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }
    
}