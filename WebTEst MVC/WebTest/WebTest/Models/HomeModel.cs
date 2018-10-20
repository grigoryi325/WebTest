using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebTest.Models
{
    public class HomeModel
    {
        private ProductContext db = new ProductContext(); 

        public Result<bool> Delete(int Id)
        {
            var result  = new Result<bool>();
            try
            {

                result.IsSucces = true;
                result.ResultObject = true;
            }
            catch(Exception e)
            {
                result.IsSucces = false;
                result.ResultObject = false;
                result.Message = "Some trouble on DB side!";
            }
            return result;
        }

        public Result<Product> AddNew(Product product)
        {
            var result = new Result<Product>();
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                result.IsSucces = true;
                
            }
            catch (Exception e)
            {
                result.IsSucces = false;
                result.ResultObject = null;
                result.Message = "Some trouble on DB side!";
            }
            return result;
        }

        public Result<Product> Edit(int id)
        {
            var result = new Result<Product>();
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
                 join Category c on c.Id = p.Category
				 where p.ProductID = @p0", id).FirstOrDefault();//db.Products.Where(x => x.ProductID == id).FirstOrDefault();
                result.IsSucces = true;

            }
            catch (Exception e)
            {
                result.IsSucces = false;
                result.ResultObject = null;
                result.Message = "Some trouble on DB side!";
            }
            return result;
        }

        public Result<bool> Edit(int id, Product product)
        {
            var result = new Result<bool>();
            try
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                result.IsSucces = true;

            }
            catch (Exception e)
            {
                result.IsSucces = false;
                result.ResultObject = false;
                result.Message = "Some trouble on DB side!";
            }
            return result;
        }

    }
}