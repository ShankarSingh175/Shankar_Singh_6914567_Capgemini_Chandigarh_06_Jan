class Program {
    public static void Main(string[] args) {
        Console.WriteLine("Sum of digits is : " + UserProgramCode.sumOfDigits(["AAA1", "B2B", "4CCC", "A5", "ABCDE"]));

        string[] input1 = { "Ram", "Manager", "Ganesh", "Developer", "Srijith", "Developer" };
        string input2 = "Developer";

        Console.WriteLine(string.Join(" ", UserProgramCode.getEmployee(input1, input2)));

    }
}