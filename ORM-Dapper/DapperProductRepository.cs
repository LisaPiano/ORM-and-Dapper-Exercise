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

        public void CreateProduct(int productId, string name, double price, int categoryId, int onSale, string stockLevel)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryId) VALUES (@name, @price, @categoryId );",
            new {name = name, price = price, categoryId = categoryId });
        }
        //This delete method is part of the bonus
        public void DeleteProduct(int productID)
        {

            _connection.Execute("DELETE FROM Sales WHERE ProductId = @productID;",
          new { productID = productID });

            _connection.Execute("DELETE FROM Products WHERE ProductID = @productID;",
           new { productID = productID });

            _connection.Execute("DELETE FROM Reviews WHERE ProductId = @productID;",
           new { productID = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            //dapper starts here
            //dapper extends IDbConnection
           return  _connection.Query<Product>("SELECT * FROM Products;");//returns the IEnumerable <Product>
        }

        //This is the first bonus
        public void UpdateProductName(int productID, string updatedName)
        {
            _connection.Execute(" UPDATE Products SET Name = @updatedName WHERE ProductID = @productID ;",
           new { productID = productID, updatedName = updatedName });
        }
    }//end class
}//end namespace
