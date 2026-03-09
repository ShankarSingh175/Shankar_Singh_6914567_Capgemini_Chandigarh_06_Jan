class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, int> studentGrades = new Dictionary<int, int>
        {
            {101, 78},
            {102, 42},
            {103, 65},
            {104, 35},
            {105, 90}
        };
        Func<Dictionary<int, int>, double> calculateAverage =
            grades => grades.Values.Average();

        Console.WriteLine("Average Grade: " + calculateAverage(studentGrades));
        Predicate<int> isAtRisk = grade => grade < 40;

        Console.WriteLine("\n---- At-Risk Students ----");
        foreach (var student in studentGrades)
        {
            if (isAtRisk(student.Value))
            {
                Console.WriteLine($"Roll No: {student.Key}, Grade: {student.Value}");
            }
        }
        int rollToUpdate = 104;
        studentGrades[rollToUpdate] = 55;

        Console.WriteLine("\nUpdated Grade for Roll No 104");

        if (isAtRisk(studentGrades[rollToUpdate]))
            Console.WriteLine("Student is still at risk.");
        else
            Console.WriteLine("Student is no longer at risk.");
    }
}
