namespace Task5_project;


public static class Program
{

    private static int MyIntComparerFoo(int x, int y)
    {
        return x.CompareTo(y);
    }

    private static void MyActionFoo(int x)
    {
        Console.WriteLine($"action worked with {x}");
    }
    
    public static void Main()
    {
        try
        {

            // constructor MyLinkedList<T>
            // ToString
            // InsertLast
            // InsertFirst
            
            Console.WriteLine($"{Environment.NewLine}--- constructor MyLinkedList<T> ---{Environment.NewLine}" +
                              $"--- ToString ---{Environment.NewLine}" +
                              $"--- InsertLast ---{Environment.NewLine}" +
                              $"--- InsertFirst ---{Environment.NewLine}");
            var a = new MyLinkedList<int>();
            Console.WriteLine(a);
            a.InsertLast(1).InsertLast(2).InsertLast(35).InsertLast(4).InsertLast(5);
            Console.WriteLine("a -> " + a);
            var b = new MyLinkedList<int>(a);
            Console.WriteLine("b -> " + b);
            b.InsertFirst(0);
            Console.WriteLine("b(after) -> " + b);

            // constructor IEnumerable<T>
            // indexer
            // Insert
            
            Console.WriteLine($"{Environment.NewLine}--- constructor IEnumerable<T> ---{Environment.NewLine}" +
                              $"--- indexer ---{Environment.NewLine}" +
                              $"--- Insert ---{Environment.NewLine}");
            Console.WriteLine(a[2]);
            a[3] = 8;
            Console.WriteLine("a(indexer) -> " + a);
            var test = new[] { 4, 3, 2, 1 };
            var c = new MyLinkedList<int>(test);
            Console.WriteLine("c -> " + c);
            c.Insert(800, 1);
            Console.WriteLine("c(insert) -> " + c);
            
            // DeleteFirst
            // DeleteLast
            // Delete

            Console.WriteLine($"{Environment.NewLine}--- DeleteFirst ---{Environment.NewLine}" +
                              $"--- DeleteLast ---{Environment.NewLine}" +
                              $"--- Delete ---{Environment.NewLine}");
            c.DeleteFirst().DeleteLast().Delete(1);
            Console.WriteLine("c(delete x3) -> " + c);
            
            // Reverse + operator!

            Console.WriteLine($"{Environment.NewLine}--- Reverse + operator! ---{Environment.NewLine}");
            a = a.Reverse();
            Console.WriteLine("a(reverse) -> " + a);
            Console.WriteLine("b(reverse) -> " + !b);
            
            // Concat + operator+
            
            Console.WriteLine($"{Environment.NewLine}--- Concat + operator+ ---{Environment.NewLine}");
            var d = a + b;
            var extra = MyLinkedList<int>.Concat(a, b);
            Console.WriteLine("d(concat a + b) -> " + d);
            
            // Intersection + operator&
            
            Console.WriteLine($"{Environment.NewLine}--- Intersection + operator& ---{Environment.NewLine}");
            var e = a & b;
            Console.WriteLine("e(intersection a & b) -> " + e);
            
            // Unite + operator|
            
            Console.WriteLine($"{Environment.NewLine}--- Unite + operator| ---{Environment.NewLine}");
            var f = a | b;
            Console.WriteLine("f(unite a | b) -> " + f);
            
            // Subtraction + operator-
            
            Console.WriteLine($"{Environment.NewLine}--- Subtraction + operator- ---{Environment.NewLine}");
            var g = a - b;
            Console.WriteLine("g(subtract a - b) -> " + g);
            
            // Sorting
            
            Console.WriteLine($"{Environment.NewLine}--- Sorting ---{Environment.NewLine}");
            var comp = new Comparison<int>(MyIntComparerFoo);
            var h = f.Sorting(comp);
            Console.WriteLine("h(sorting f) -> " + h);
            
            // Action
            
            Console.WriteLine($"{Environment.NewLine}--- Action ---{Environment.NewLine}");
            var act = new Action<int>(MyActionFoo);
            Console.WriteLine("h(action)");
            h.Action(act);

            // operator== operator!=
            
            Console.WriteLine($"{Environment.NewLine}--- operator== operator!= ---{Environment.NewLine}");
            Console.WriteLine(a == b);
            var i = new MyLinkedList<int>(h);
            Console.WriteLine(i != h);

            // operator*
            
            Console.WriteLine($"{Environment.NewLine}--- operator* ---{Environment.NewLine}");
            Console.WriteLine("a -> " + a);
            Console.WriteLine("b -> " + b);
            Console.WriteLine($"a * b -> {a * b}");
            
            // GetHashCode
            
            Console.WriteLine($"{Environment.NewLine}--- GetHashCode ---{Environment.NewLine}");
            Console.WriteLine("a(hash) -> " + a.GetHashCode());
            
            // ICloneable
            
            Console.WriteLine($"{Environment.NewLine}--- ICloneable ---{Environment.NewLine}");
            Console.WriteLine("a -> " + a);
            var clone = a.Clone() as MyLinkedList<int> ?? throw new Exception("impossible to throw");
            clone.InsertLast(999);
            Console.WriteLine("clone(+ insert 999) -> " + clone);
            
            // IEnumerable<T>
            
            Console.WriteLine($"{Environment.NewLine}--- IEnumerable<T> ---{Environment.NewLine}");
            foreach (var item in clone)
            {
                Console.Write(item + " ~ ");
            }

        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
}