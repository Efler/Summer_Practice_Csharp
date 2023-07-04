namespace Task1_project;


public class Student : IEquatable<Student>
{

    private readonly string _name;
    private readonly string _surname;
    private readonly string _patronymic;
    private readonly string _group;
    private readonly PracticeTopics _topic;

    public string Name => _name;
    public string Surname => _surname;
    public string Patronymic => _patronymic;
    public string Group => _group;
    public PracticeTopics Topic => _topic;
    
    public int CourseNumber =>
        // bruh moment...
        /*
            var admissionYear = int.Parse(_group.Substring(_group.LastIndexOf('-') + 1));
            var thisYear = DateTime.Now.Year;
            if (admissionYear < 100) admissionYear += thisYear / 1000 * 1000;
            var thisMonth = DateTime.Now.Month;
            var courseNumber = thisYear - admissionYear + 1;
            if (thisMonth < 9) courseNumber--;

            return courseNumber;
        */
        int.Parse(_group.Substring(_group.IndexOf('-') + 1, 1));

    public Student (string? surname, string? name, string? patronymic,
        string? group, PracticeTopics? topic)
    {
        if (name == null) throw new ArgumentNullException(nameof(name));
        if (surname == null) throw new ArgumentNullException(nameof(surname));
        if (patronymic == null) throw new ArgumentNullException(nameof(patronymic));
        if (group == null) throw new ArgumentNullException(nameof(group));
        if (topic == null) throw new ArgumentNullException(nameof(topic));

        const string message = "empty string";
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(message, nameof(name));
        if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentException(message, nameof(surname));
        if (string.IsNullOrWhiteSpace(patronymic)) throw new ArgumentException(message, nameof(patronymic));
        if (string.IsNullOrWhiteSpace(group)) throw new ArgumentException(message, nameof(group));

        _name = name;
        _surname = surname;
        _patronymic = patronymic;
        _group = group;
        _topic = (PracticeTopics) topic;
    }

    public override string ToString()
    {
        return $"{_surname} {_name} {_patronymic}, Group: {_group}, Practice: {_topic.ToString()}";
    }

    public override int GetHashCode()
    {
        return _name.GetHashCode() * 7 + _surname.GetHashCode() * 2 + _patronymic.GetHashCode() / 3 + _group.GetHashCode() + _topic.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is Student stud) return Equals(stud);
        return false;
    }
    public bool Equals(Student? other)
    {
        if (other == null) return false;
        return _name == other.Name &&
               _surname == other.Surname &&
               _patronymic == other.Patronymic &&
               _group == other.Group &&
               _topic == other.Topic;
    }
    
}