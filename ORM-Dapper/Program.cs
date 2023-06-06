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
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            string connString = config.GetConnectionString("DefaultConnection");//grabbing info from connectionstring and storing it in connString
            IDbConnection conn = new MySqlConnection(connString);
        }
    }
}