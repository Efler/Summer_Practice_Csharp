namespace Task4_project;


public interface IIntegration
{
    public string SolutionMethod { get; }
    
    public double CalcIntegral(Func<double, double> function, double a, double b, int accuracy);
}