namespace Task4_project;


public class LeftBoxIntegration : IIntegration
{
    public string SolutionMethod => "Left Box Method";

    public double CalcIntegral(Func<double, double>? function, double a, double b, int accuracy)
    {
        var flag = false;
        if (function == null) throw new ArgumentNullException(nameof(function));
        if (accuracy <= 0) throw new ArgumentException("Invalid accuracy!", nameof(accuracy));
        if (a.CompareTo(b) == 0) return 0d;
        if (a.CompareTo(b) > 0)
        {
            (a, b) = (b, a);
            flag = true;
        }
        
        var h = (b - a) / accuracy;
        var sum = 0d;
        for(var i = 0; i < accuracy; ++i)
        {
            var x = a + i * h;
            sum += function(x);
        }
        
        var result = h * sum;
        if (flag) result = -result;

        return result;
    }
}