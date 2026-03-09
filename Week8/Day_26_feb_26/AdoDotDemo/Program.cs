using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost,1433;Database=Employeedb;User Id=SA;Password=StrongPassword@123;TrustServerCertificate=True;";

        Console.WriteLine("Connected Successfully!\n");

        GetAllEmployees(connectionString);

        GetEmployeeByID(connectionString, 1);

        CreateEmployeeWithAddress(
            connectionString,
            "Shankar",
            "Singh",
            "shankarsingh0175@gmail.com",
            "Sunarian",
            "Rohtak",
            "Haryana",
            "124001"
        );

        UpdateEmployeeWithAddress(
            connectionString,
            1,
            "Shankar",
            "Singh",
            "shankarsingh0175@gmail.com",
            "Sunarian",
            "Rohtak",
            "Haryana",
            "124001",
            1
        );

        DeleteEmployee(connectionString, 5);
    }

    // =====================================================
    // GET ALL EMPLOYEES
    // =====================================================
    static void GetAllEmployees(string connectionString)
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        SqlCommand command =
            new SqlCommand("GetAllEmployees", connection);

        command.CommandType = CommandType.StoredProcedure;

        connection.Open();

        using SqlDataReader reader =
            command.ExecuteReader();

        Console.WriteLine("\n--- Employee List ---");

        while (reader.Read())
        {
            Console.WriteLine(
                $"ID:{reader["employee_id"]} | " +
                $"{reader["first_name"]} {reader["last_name"]}"
            );

            Console.WriteLine(
                $"{reader["street"]}, {reader["city"]}, " +
                $"{reader["state"]} - {reader["postal_code"]}\n"
            );
        }
    }

    // =====================================================
    // GET EMPLOYEE BY ID
    // =====================================================
    static void GetEmployeeByID(string connectionString, int employeeID)
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        SqlCommand command =
            new SqlCommand("GetEmployeeByID", connection);

        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@EmployeeID", employeeID);

        connection.Open();

        using SqlDataReader reader =
            command.ExecuteReader();

        Console.WriteLine("\n--- Employee By ID ---");

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["first_name"]} {reader["last_name"]} - {reader["email"]}"
            );
        }
    }

    // =====================================================
    // CREATE EMPLOYEE + ADDRESS
    // =====================================================
    static void CreateEmployeeWithAddress(
        string connectionString,
        string first_name,
        string last_name,
        string email,
        string street,
        string city,
        string state,
        string postal_code)
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        SqlCommand command =
            new SqlCommand("CreateEmployeeWithAddress", connection);

        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@first_name", first_name);
        command.Parameters.AddWithValue("@last_name", last_name);
        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@street", street);
        command.Parameters.AddWithValue("@city", city);
        command.Parameters.AddWithValue("@state", state);
        command.Parameters.AddWithValue("@postal_code", postal_code);

        connection.Open();

        command.ExecuteNonQuery();

        Console.WriteLine("\nEmployee Created Successfully.");
    }

    // =====================================================
    // UPDATE EMPLOYEE + ADDRESS
    // =====================================================
    static void UpdateEmployeeWithAddress(
        string connectionString,
        int employeeID,
        string firstName,
        string lastName,
        string email,
        string street,
        string city,
        string state,
        string postalCode,
        int addressID)
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        SqlCommand command =
            new SqlCommand("UpdateEmployeeWithAddress", connection);

        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.AddWithValue("@EmployeeID", employeeID);
        command.Parameters.AddWithValue("@FirstName", firstName);
        command.Parameters.AddWithValue("@LastName", lastName);
        command.Parameters.AddWithValue("@Email", email);
        command.Parameters.AddWithValue("@Street", street);
        command.Parameters.AddWithValue("@City", city);
        command.Parameters.AddWithValue("@State", state);
        command.Parameters.AddWithValue("@PostalCode", postalCode);
        command.Parameters.AddWithValue("@AddressID", addressID);

        connection.Open();

        command.ExecuteNonQuery();

        Console.WriteLine("\nEmployee Updated Successfully.");
    }

    // =====================================================
    // DELETE EMPLOYEE
    // =====================================================
    static void DeleteEmployee(string connectionString, int employeeID)
    {
        using SqlConnection connection =
            new SqlConnection(connectionString);

        SqlCommand command =
            new SqlCommand("DeleteEmployee", connection);

        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@EmployeeID", employeeID);

        connection.Open();

        int result = command.ExecuteNonQuery();

        if (result > 0)
            Console.WriteLine("\nEmployee Deleted Successfully.");
        else
            Console.WriteLine("\nEmployee Not Found.");
    }
}