namespace Task2_project;


public class CustomComparer<T>: IEqualityComparer<T>
{
    
    private static CustomComparer<T>? _instance;
    
    private CustomComparer(){}
    
    public static CustomComparer<T> GetInstance =>
        _instance ??= new CustomComparer<T>();
    
    public bool Equals(T? x, T? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        return x.GetType() == y.GetType() && x.Equals(y);
    }

    public int GetHashCode(T? x)
    {
        return x?.GetHashCode() ?? 0;
    }
    
}