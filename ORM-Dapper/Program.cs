using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace ORM_Dapper
{
    public class Program
    {
        private static void Main(string[] args)
        {
            #region Configuration
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            string connString = config.GetConnectionString("DefaultConnection");//grabbing info from connectionstring and storing it in connString
            IDbConnection conn = new MySqlConnection(connString);

            Console.WriteLine(connString);
            Console.WriteLine("");
            #endregion

            var repo = new DapperDepartmentRepository(conn);
            Console.WriteLine("Hello User! Here are the current departments: ");
            Console.WriteLine("Please press enter...");
            Console.ReadLine();
            IEnumerable<Department> departments = repo.GetAllDepartments();

            foreach (Department department in departments)
            {
                Console.WriteLine($"Department ID: {department.DepartmentID} Department Name: {department.Name}");
            }

            Console.WriteLine("Do you want to add a department?");
            string userResponse = Console.ReadLine();
            if (userResponse.ToLower() == "yes")
            {
                Console.WriteLine("What is the name of your new department?");
                userResponse = Console.ReadLine();
                repo.InsertDepartment(userResponse);
            }
            Console.WriteLine("Oh well. Goodbye!!!");


        }//end main method
    }//end program class
}//end namespace