using System;

public enum Gender
{
    Male,
    Female,
    Other
}

public abstract class User
{
    private string type;
    private string name;
    private Gender gender;
    private int age;

    public User(string type, string name, Gender gender, int age)
    {
        this.type = type;
        this.name = name;
        this.gender = gender;
        this.age = age;
    }

    public string GetUserName()
    {
        return name;
    }

    public string GetUserType()
    {
        return type;
    }

    public int GetAge()
    {
        return age;
    }

    public Gender GetGender()
    {
        return gender;
    }
}

public class Admin : User
{
    public Admin(string name, Gender gender, int age)
        : base("Admin", name, gender, age)
    {
    }
}

public class Moderator : User
{
    public Moderator(string name, Gender gender, int age)
        : base("Moderator", name, gender, age)
    {
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        // Read first user (Admin)
        string[] adminInput = Console.ReadLine().Split(' ');
        string adminName = adminInput[0];
        Gender adminGender = (Gender)Enum.Parse(typeof(Gender), adminInput[1]);
        int adminAge = int.Parse(adminInput[2]);

        Admin admin = new Admin(adminName, adminGender, adminAge);

        Console.WriteLine($"Type of user {admin.GetUserName()} is {admin.GetUserType()}");
        Console.WriteLine($"Age of user {admin.GetUserName()} is {admin.GetAge()}");
        Console.WriteLine($"Gender of user {admin.GetUserName()} is {admin.GetGender()}");

        // Read second user (Moderator)
        string[] modInput = Console.ReadLine().Split(' ');
        string modName = modInput[0];
        Gender modGender = (Gender)Enum.Parse(typeof(Gender), modInput[1]);
        int modAge = int.Parse(modInput[2]);

        Moderator mod = new Moderator(modName, modGender, modAge);

        Console.WriteLine($"Type of user {mod.GetUserName()} is {mod.GetUserType()}");
        Console.WriteLine($"Age of user {mod.GetUserName()} is {mod.GetAge()}");
        Console.WriteLine($"Gender of user {mod.GetUserName()} is {mod.GetGender()}");
    }
}