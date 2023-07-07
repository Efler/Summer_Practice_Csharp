using Task2_project;


var collection = new[]{'A', 'B', 'C', 'D'};


//      --- Combinations ---

try
{
    Console.WriteLine($"{Environment.NewLine} --- Combinations --- {Environment.NewLine}");
    var res = collection.Combinations(CustomComparer<char>.GetInstance, 3);

    var i = 1;
    foreach (var item in res)
    {
        Console.Write($"{i++}: ");
        foreach (var element in item)
        {
            Console.Write($"{element} ");
        }
        Console.Write($"{Environment.NewLine}");
    }
}
catch (ArgumentException ex)
{
     Console.WriteLine(ex.Message);
}


//      --- Subsets ---

try
{
    Console.WriteLine($"{Environment.NewLine} --- Subsets --- {Environment.NewLine}");
    var res = collection.Subsets(CustomComparer<char>.GetInstance);

    var i = 1;
    foreach (var item in res)
    {
        Console.Write($"{i++}: ");
        foreach (var element in item)
        {
            Console.Write($"{element} ");
        }
        Console.Write($"{Environment.NewLine}");
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}



//      --- Permutations ---

try
{
    Console.WriteLine($"{Environment.NewLine} --- Permutations --- {Environment.NewLine}");
    var res = collection.Permutations(CustomComparer<char>.GetInstance);

    var i = 1;
    foreach (var item in res)
    {
        Console.Write($"{i++}: ");
        foreach (var element in item)
        {
            Console.Write($"{element} ");
        }
        Console.Write($"{Environment.NewLine}");
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}