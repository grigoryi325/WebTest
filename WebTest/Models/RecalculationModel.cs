using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Models
{
    public class RecalculationModel
    {
        public double Indexing {
            get
            {
                Random rnd = new Random();
                return (rnd.Next(30,100));
            }
        }
    }
}