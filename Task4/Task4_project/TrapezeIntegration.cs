namespace Task4_project;


public class TrapezeIntegration : IIntegration
{
    public string SolutionMethod => "Trapeze Method";

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
        var sum = function(a) + function(b);
        for (var i = 1; i <= accuracy - 1; ++i)
            sum += 2 * function(a + i * h);

        var result = sum * (h / 2);
        if (flag) result = -result;

        return result;
    }
}