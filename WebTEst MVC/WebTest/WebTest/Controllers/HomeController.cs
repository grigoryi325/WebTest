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
        private LookUpProvider lp = new LookUpProvider();
        private Fabric fab =new  Fabric();
        private HomeModel hm = new HomeModel();

        public ActionResult Index()
        {
            var result = lp.GetProducts();
            if (result.IsSucces)
                return View(result.ResultObject);

            else return View("Error");
        }

        public ActionResult Create()
        {
            var result = fab.CreateViewModel();
            if(result.IsSucces)
            {
                return View(result.ResultObject);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            var result = hm.AddNew(product);
            if(result.IsSucces)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            var result = hm.Edit(id);
            if (result.IsSucces)
            {
                return View(result.ResultObject);
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            var result = hm.Edit(id, product);
            if(result.IsSucces)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        //public ActionResult Delete (int id)
        //{
        //    return View(db.Products.Where(x => x.ProductID == id).FirstOrDefault());
        //}

        //[HttpPost]
        //public ActionResult Delete (int id, FormCollection collection)
        //{
        //    try
        //    {
        //        Product product = db.Products.Where(x => x.ProductID == id).FirstOrDefault();
        //        db.Products.Remove(product);
        //        db.SaveChanges();

        //        return RedirectToAction("Index");

        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}