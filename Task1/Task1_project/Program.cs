using Task1_project;


try
{
    
    Console.WriteLine("\n----- 1 -----");
    var stud1 = new Student(
        "Сарафанников", "Ян", "Владимирович", "M8О-211Б-21", PracticeTopics.Csharp);
    Console.WriteLine(stud1.Name);
    Console.WriteLine(stud1.Group);
    Console.WriteLine(stud1.Topic);
    Console.WriteLine(stud1.Topic.ToString());
    Console.WriteLine(stud1.CourseNumber);
    // stud1.Group = "123";     // no setter
    Console.WriteLine(stud1.ToString());
    Console.WriteLine(stud1.GetHashCode());
    
    Console.WriteLine("\n----- 2 -----");
    object stud2 = new Student(
        "Свэгович", "Райан", "Гослинг", "M8О-111Х-23", PracticeTopics.InfrastructureActivities);
    Console.WriteLine(stud2.ToString());
    Console.WriteLine(((Student)stud2).CourseNumber);
    Console.WriteLine(stud2.GetHashCode());
    
    Console.WriteLine("\n----- 3 -----");
    Console.WriteLine(stud1.Equals(stud2));
    
    Console.WriteLine("\n----- 4 -----");
    Student? stud3 = null;
    Console.WriteLine(stud1.Equals(stud3));
    Console.WriteLine(stud2.Equals(stud3));
    
    Console.WriteLine("\n----- 5 -----");
    object stud4 = new Student(
        "Сарафанников", "Ян", "Владимирович", "M8О-211Б-21", PracticeTopics.Csharp);
    Console.WriteLine(stud1.Equals(stud4));
    
    Console.WriteLine("\n----- 6 -----");
    // var stud6 = new Student(
    //     "Сарафанников", "Ян", "Владимирович", null, PracticeTopics.Csharp);   //null arg
    // Console.WriteLine(stud6.ToString());
    
    Console.WriteLine("\n----- 7 -----");
    var stud7 = new Student(
        "Сарафанников", "Ян", "Владимирович", "", PracticeTopics.Csharp);     //empty arg
    Console.WriteLine(stud7.ToString());
    
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}