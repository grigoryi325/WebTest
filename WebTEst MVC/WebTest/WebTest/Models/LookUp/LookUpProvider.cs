using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTest.Models.DataModel;

namespace WebTest.Models
{
    public class LookUpProvider
    {
        private ProductContext db = new ProductContext();

        public Result<List<Category>> GetCategories()
        {
            var result = new Result<List<Category>>();
            try
            {
                result.ResultObject = db.Database.SqlQuery<Category>(@"select * from Category").ToList();
                result.IsSucces = true;
            }
            catch (Exception e)
            {
                result.IsSucces = false;
                result.ResultObject = null;
                result.Message = "Some problem in DB!";
            }
            return result;
        }

        public Result<List<Product>> GetProducts()
        {
            var result = new Result<List<Product>>();
            try
            {
                result.ResultObject = db.Database.SqlQuery<Product>(@"select 
	                p.ProductID,
	                p.Name,
	                p.Number,
	                p.Price,
                    c.Id as Category,
	                c.Value as CategoryName
                 from Products as p 
                 join Category c on c.Id = p.Category").ToList();
                result.IsSucces = true;
            }
            catch(Exception e)
            {
                result.IsSucces = false;
                result.Message = "Some trouble in DB";
            }
            return result;
        }
    }
}