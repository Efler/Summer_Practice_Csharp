namespace Task4_project;


public class SimpsonIntegration : IIntegration
{
    public string SolutionMethod => "Simpson Method";

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
        var sum1 = 0d;
        var sum2 = 0d;
        for (var k = 1; k <= accuracy; k++)
        {
            var xk = a + k * h;
            if (k <= accuracy - 1)
            {
                sum1 += function(xk);
            }

            var xk1 = a + (k - 1) * h;
            sum2 += function((xk + xk1) / 2);
        }

        var result = h / 3d * (1d / 2d * function(a) + sum1 + 2 * sum2 + 1d / 2d * function(b));
        if (flag) result = -result;
        
        return result;
    }
}