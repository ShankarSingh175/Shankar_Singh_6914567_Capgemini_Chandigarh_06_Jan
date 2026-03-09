using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class User
{
    public int Id { get; set; }
    public string? IdentityNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Gender { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? ZipCode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Department { get; set; }
    public string? Roles { get; set; }
    public DateOnly? JoinDate { get; set; }
    public decimal Credit { get; set; }
    public string? Status { get; set; }
}

static class UserManager
{
    public static (List<User> updated, List<User> inserted) CompareUsers(
        List<User> usersListInDB,
        List<User> newUsersList)
    {
        List<User> updated = new List<User>();
        List<User> inserted = new List<User>();

        foreach (var newUser in newUsersList)
        {
            var existingUser = usersListInDB
                .FirstOrDefault(u => u.IdentityNumber == newUser.IdentityNumber);

            if (existingUser == null)
            {
                inserted.Add(newUser);
            }
            else
            {
                bool isDifferent = typeof(User)
                    .GetProperties()
                    .Any(prop =>
                    {
                        var oldValue = prop.GetValue(existingUser);
                        var newValue = prop.GetValue(newUser);
                        return !Equals(oldValue, newValue);
                    });

                if (isDifferent)
                    updated.Add(newUser);
            }
        }

        return (updated, inserted);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        var outputPath = Environment.GetEnvironmentVariable("OUTPUT_PATH");
        TextWriter textWriter = string.IsNullOrEmpty(outputPath) ? Console.Out : new StreamWriter(outputPath, true);

        List<User> usersListInDB = new List<User>();
        List<User> newUsersList = new List<User>();

        int userInDbCount = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 0; i < userInDbCount; i++)
        {
            var u = Console.ReadLine().Trim().Split(',');
            var usr = new User()
            {
                Id = string.IsNullOrEmpty(u[0]) ? 0 : Convert.ToInt32(u[0]),
                IdentityNumber = u[1],
                FirstName = u[2],
                LastName = u[3],
                Age = string.IsNullOrEmpty(u[4]) ? 0 : Convert.ToInt32(u[4]),
                BirthDate = string.IsNullOrEmpty(u[5]) ? null : new DateOnly(Convert.ToInt32(u[5].Split('.')[0]), Convert.ToInt32(u[5].Split('.')[1]), Convert.ToInt32(u[5].Split('.')[2])),
                Email = u[6],
                Gender = u[7],
                Country = u[8],
                City = u[9],
                Address = u[10],
                ZipCode = u[11],
                PhoneNumber = u[12],
                Department = u[13],
                Roles = u[14],
                JoinDate = string.IsNullOrEmpty(u[15]) ? null : new DateOnly(Convert.ToInt32(u[15].Split('.')[0]), Convert.ToInt32(u[15].Split('.')[1]), Convert.ToInt32(u[15].Split('.')[2])),
                Credit = string.IsNullOrEmpty(u[16]) ? 0 : Convert.ToDecimal(u[16]),
                Status = u[17]
            };
            usersListInDB.Add(usr);
        }

        int newUsersCount = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 0; i < newUsersCount; i++)
        {
            var u = Console.ReadLine().Trim().Split(',');
            var usr = new User()
            {
                Id = string.IsNullOrEmpty(u[0]) ? 0 : Convert.ToInt32(u[0]),
                IdentityNumber = u[1],
                FirstName = u[2],
                LastName = u[3],
                Age = string.IsNullOrEmpty(u[4]) ? 0 : Convert.ToInt32(u[4]),
                BirthDate = string.IsNullOrEmpty(u[5]) ? null : new DateOnly(Convert.ToInt32(u[5].Split('.')[0]), Convert.ToInt32(u[5].Split('.')[1]), Convert.ToInt32(u[5].Split('.')[2])),
                Email = u[6],
                Gender = u[7],
                Country = u[8],
                City = u[9],
                Address = u[10],
                ZipCode = u[11],
                PhoneNumber = u[12],
                Department = u[13],
                Roles = u[14],
                JoinDate = string.IsNullOrEmpty(u[15]) ? null : new DateOnly(Convert.ToInt32(u[15].Split('.')[0]), Convert.ToInt32(u[15].Split('.')[1]), Convert.ToInt32(u[15].Split('.')[2])),
                Credit = string.IsNullOrEmpty(u[16]) ? 0 : Convert.ToDecimal(u[16]),
                Status = u[17]
            };
            newUsersList.Add(usr);
        }

        var (updated, inserted) = UserManager.CompareUsers(usersListInDB, newUsersList);

        textWriter.WriteLine("Updated Users:" + updated.Count);
        textWriter.WriteLine("Inserted Users:" + inserted.Count);
        textWriter.Flush();
        if (textWriter != Console.Out)
            textWriter.Close();
    }
}