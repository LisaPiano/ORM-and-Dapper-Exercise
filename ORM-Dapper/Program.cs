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

            //Below is the code for the first project assignment--for the Departments

            //    var repo = new DapperDepartmentRepository(conn);
            //    Console.WriteLine("Hello User! Here is the list of the current departments: ");
            //    Console.WriteLine("Please press enter...");
            //    Console.ReadLine();

            //    var departments = repo.GetAllDepartments();
            //    Print(repo.GetAllDepartments());


            //    Console.WriteLine("");
            //    Console.WriteLine("Do you want to add a department?");
            //    string userResponse = Console.ReadLine();
            //    if (userResponse.ToLower() == "yes")
            //    {
            //        Console.WriteLine("What is the name of your new department?");
            //        userResponse = Console.ReadLine();
            //        repo.InsertDepartment(userResponse);
            //        Console.WriteLine("");
            //        Console.WriteLine("Here is an updated list with your added department: ");
            //        Console.WriteLine("");
            //        Print(repo.GetAllDepartments());
            //        Console.WriteLine(" ");
            //        Console.WriteLine("Thanks for inserting a department! Goodbye!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("");
            //        Console.WriteLine("OK. No inserted department today. Goodbye!!!");
            //    }
            //}//end main method

            //private static void Print(IEnumerable<Department> departments)
            //{
            //    foreach (Department department in departments)
            //    {
            //        Console.WriteLine($"Department ID: {department.DepartmentID} Department Name: {department.Name}");
            //    }
            //}

            //Here begins the code for the second part of the assignments, using Products

            var repoProduct = new DapperProductRepository(conn);
            repoProduct.CreateProduct(32, "New Stuff", 1, 5, 6, "New");
            var products = repoProduct.GetAllProducts();//GetAllProducts() belongs to the instance of the DapperProduct Repository, which is repoProduct

            foreach (var product in products)
            {
                Console.WriteLine($" Product ID: {product.ProductId} Product Name: {product.Name} Product Price: {product.Price} Product Category ID: {product.CategoryId} Product On Sale: {product.OnSale} Product Stock Level: {product.StockLevel}");
            }
        }//end main method for the second part of the project 
    }//end program class
}//end namespace