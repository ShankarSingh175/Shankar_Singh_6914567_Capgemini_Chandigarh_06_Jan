using System;
using Microsoft.Data.SqlClient;

class Program
{
    static string connectionString = "Server=localhost,1433;Database=UniversityDB;User Id=SA;Password=StrongPassword@123;TrustServerCertificate=True;";

    public static void Main()
    {
        Console.WriteLine("Connected Successfully!\n");

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Choose Operation:");
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Select");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    InsertRecord();
                    break;
                case 2:
                    UpdateRecord();
                    break;
                case 3:
                    DeleteRecord();
                    break;
                case 4:
                    SelectRecords();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice\n");
                    break;
            }
        }
    }

    // INSERT
    static void InsertRecord()
    {
        Console.Write("Enter Table Name: ");
        string table = Console.ReadLine();

        using SqlConnection conn = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_InsertRecord", conn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@TableName", table);

        if (table == "Departments")
        {
            Console.Write("Dept Name: ");
            cmd.Parameters.AddWithValue("@DeptName", Console.ReadLine());
        }
        else if (table == "Courses")
        {
            Console.Write("Course Name: ");
            cmd.Parameters.AddWithValue("@CourseName", Console.ReadLine());

            Console.Write("Dept Id: ");
            cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(Console.ReadLine()));
        }
        else if (table == "Students")
        {
            Console.Write("First Name: ");
            cmd.Parameters.AddWithValue("@FirstName", Console.ReadLine());

            Console.Write("Last Name: ");
            cmd.Parameters.AddWithValue("@LastName", Console.ReadLine());

            Console.Write("Email: ");
            cmd.Parameters.AddWithValue("@Email", Console.ReadLine());

            Console.Write("Dept Id: ");
            cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(Console.ReadLine()));
        }
        else if (table == "Enrollments")
        {
            Console.Write("Student Id: ");
            cmd.Parameters.AddWithValue("@StudentId", Convert.ToInt32(Console.ReadLine()));

            Console.Write("Course Id: ");
            cmd.Parameters.AddWithValue("@CourseId", Convert.ToInt32(Console.ReadLine()));

            Console.Write("Grade: ");
            cmd.Parameters.AddWithValue("@Grade", Console.ReadLine());
        }

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Record Inserted Successfully!\n");
    }

    // UPDATE
    static void UpdateRecord()
    {
        Console.Write("Enter Table Name: ");
        string table = Console.ReadLine();

        Console.Write("Enter Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        using SqlConnection conn = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_UpdateRecord", conn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@TableName", table);
        cmd.Parameters.AddWithValue("@Id", id);

        if (table == "Departments")
        {
            Console.Write("New Dept Name: ");
            cmd.Parameters.AddWithValue("@DeptName", Console.ReadLine());
        }
        else if (table == "Courses")
        {
            Console.Write("New Course Name: ");
            cmd.Parameters.AddWithValue("@CourseName", Console.ReadLine());

            Console.Write("Dept Id: ");
            cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(Console.ReadLine()));
        }
        else if (table == "Students")
        {
            Console.Write("First Name: ");
            cmd.Parameters.AddWithValue("@FirstName", Console.ReadLine());

            Console.Write("Last Name: ");
            cmd.Parameters.AddWithValue("@LastName", Console.ReadLine());

            Console.Write("Email: ");
            cmd.Parameters.AddWithValue("@Email", Console.ReadLine());

            Console.Write("Dept Id: ");
            cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(Console.ReadLine()));
        }
        else if (table == "Enrollments")
        {
            Console.Write("Student Id: ");
            cmd.Parameters.AddWithValue("@StudentId", Convert.ToInt32(Console.ReadLine()));

            Console.Write("Course Id: ");
            cmd.Parameters.AddWithValue("@CourseId", Convert.ToInt32(Console.ReadLine()));

            Console.Write("Grade: ");
            cmd.Parameters.AddWithValue("@Grade", Console.ReadLine());
        }

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Record Updated Successfully!\n");
    }

    // DELETE
    static void DeleteRecord()
    {
        Console.Write("Enter Table Name: ");
        string table = Console.ReadLine();

        Console.Write("Enter Id: ");
        int id = Convert.ToInt32(Console.ReadLine());

        using SqlConnection conn = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_DeleteRecord", conn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@TableName", table);
        cmd.Parameters.AddWithValue("@Id", id);

        conn.Open();
        cmd.ExecuteNonQuery();
        Console.WriteLine("Record Deleted Successfully!\n");
    }

    // SELECT
    static void SelectRecords()
    {
        Console.Write("Enter Table Name: ");
        string table = Console.ReadLine();

        Console.Write("Enter Id (0 for all): ");
        int id = Convert.ToInt32(Console.ReadLine());

        using SqlConnection conn = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_SelectRecords", conn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@TableName", table);

        if (id == 0)
            cmd.Parameters.AddWithValue("@Id", DBNull.Value);
        else
            cmd.Parameters.AddWithValue("@Id", id);

        conn.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        Console.WriteLine("\nResults:");
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write(reader[i] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}