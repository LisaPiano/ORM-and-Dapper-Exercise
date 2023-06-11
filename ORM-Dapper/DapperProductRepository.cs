using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ORM_Dapper
{
    public class DapperProductRepository : IProductRepository 
    {
        //================================ENCAPSULATION
        public readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)//IN order to create a new instance of the class in the constructor
        //method, I need to enter the connection as a parameter to the constructor method
        {
            _connection = connection;
        }
        //++++++++++++++++++++++++++++++++++ENCAPSULATION

        public void CreateProduct(int productID, string name, double price, int categoryId, int onSale, string stockLevel)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryId) VALUES (@name, @price, @categoryId );",
            new {name = name, price = price, categoryId = categoryId });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            //dapper starts here
            //dapper extends IDbConnection
           return  _connection.Query<Product>("SELECT * FROM Products;");//returns the IEnumerable <Product>
        }


    }//end class
}//end namespace
