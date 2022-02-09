using System;
using System.Data;
using System.Linq;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestBuyBestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            var deptRepo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Type a new Department name");


            var newDepartment = Console.ReadLine();

            deptRepo.InsertDepartment(newDepartment);


           var  departments = deptRepo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine(dept.Name);
            }


        var productRepo = new DapperProductRepository(conn);
            // Create Section
            Console.WriteLine("type a new product name");
            var productName = Console.ReadLine();
            Console.WriteLine("type your product's price");
            var productPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("whats your catorgory id");
            var catagoryID = int.Parse(Console.ReadLine());

            productRepo.CreateProduct(productName, productPrice, catagoryID);
            productRepo.GetAllProducts().ToList().ForEach(duct => Console.WriteLine(duct.ProductName));

           
            // Updated Section
            Console.WriteLine("what is your updated name?");
            var updatedName = Console.ReadLine();
            Console.WriteLine("what is your product id");
            var productID = int.Parse(Console.ReadLine());
           productRepo.UpdateProductName(productID ,updatedName);
            productRepo.GetAllProducts().ToList().ForEach(duct => Console.WriteLine(duct.ProductName));




            // Delete Section
            Console.WriteLine("what product id do you want to delete");
           productID = int.Parse(Console.ReadLine());
            productRepo.DeleteProdudct(productID);
            productRepo.GetAllProducts().ToList().ForEach(duct => Console.WriteLine(duct.ProductName));





        }
    }
}
