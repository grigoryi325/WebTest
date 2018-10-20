using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTest.Models.DataModel;

namespace WebTest.Models
{
    public class CreateViewModel
    {
        public List<Category> Categories { get; set; }
        public Product Product { get; set; }
    }
}