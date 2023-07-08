namespace Task3_project;


public class IntComparer: IComparer<int>
{
    public int Compare(int x, int y)
    {
        return x.CompareTo(y);
    }
}