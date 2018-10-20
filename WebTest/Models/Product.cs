using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public Category  ProductCategory { get; set; }
    }

    public enum Category
    {
        Product = 1,
        Service = 2
    }
}