namespace Task4_project;


public static class Program
{

    private static double Foo(double x)
    {
        return Math.Pow(x, 3) + 1;
    }
    
    
    public static void Main()
    {
        
        var integratorsArray = new IIntegration[]
        {
            new LeftBoxIntegration(), new RightBoxIntegration(), new CentralBoxIntegration(),
            new SimpsonIntegration(), new TrapezeIntegration()
        };
        var myDelegate = new Func<double, double>(Foo);


        foreach (var integrator in integratorsArray)
        {
            Console.WriteLine($"{Environment.NewLine}{integrator.SolutionMethod}");
            Console.WriteLine($"{integrator.CalcIntegral(myDelegate, 1, 5, 1000000)}");
        }

    }
}