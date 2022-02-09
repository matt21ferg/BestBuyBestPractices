using System;
using Dapper;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        

        
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (name, price, categoryID) values (@name ,@price,@categoryID)",
                new { name, price, categoryID });
        }


           public void UpdateProductName(int productID, string updatedName)
            {
                _connection.Execute("UPDATE products SET Name = @updatedName WHERE ProductID = @productID;",
                    new { updatedName = updatedName, productID = productID });
            }



        public void DeleteProdudct(int productID)
        {
            _connection.Execute("Delete FROM products WHERE productID = @productID;",
                new { productID = productID });
            _connection.Execute("Delete FROM reviews WHERE productID = @productID;",
               new { productID = productID });
            _connection.Execute("Delete FROM sales WHERE productID = @productID;",
               new { productID = productID });
        }


            public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products");
        }
    }
}
