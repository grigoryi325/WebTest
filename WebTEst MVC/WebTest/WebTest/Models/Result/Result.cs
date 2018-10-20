using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Models
{
    public class Result<TEntity>
    {
        public TEntity ResultObject { get; set; }
        public bool IsSucces { get; set; }
        public string Message{ get; set; }
    }
}