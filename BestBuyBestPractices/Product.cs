using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } 
        public double Price { get; set; }
        public int CatagoryID { get; set; }
        public int OnSale { get; set; }
        public int StockLevel { get; set; }
    }
}
