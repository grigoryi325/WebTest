using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ProductContext db = new ProductContext();

        public ActionResult Index()
        {
            return View(db.Products);
        }

        public ActionResult Create()
        {     
                return View();      
        } 


        [HttpPost]
        public ActionResult Create(Product product)
        {
            try 
            {
                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            } catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(db.Products.Where(x => x.ProductID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            } catch
            {
                return View();
            }
        }

        public ActionResult Delete (int id)
        {
            return View(db.Products.Where(x => x.ProductID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Delete (int id, FormCollection collection)
        {
            try
            {
                Product product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
                db.Products.Remove(product);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }


        public ActionResult Recalculation()
        {
            try { 
            RecalculationModel rnd = new RecalculationModel();
            decimal resault = Convert.ToDecimal(rnd.Indexing);

            foreach (var Product in db.Products)
            {
                Product.Price = Product.Price + resault ;               
            }
            db.SaveChanges();
            return RedirectToAction("Index");
            } catch
            {
                return View();
            }
        }
    }
}