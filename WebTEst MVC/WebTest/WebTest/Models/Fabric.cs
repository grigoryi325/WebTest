using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Models
{
    public class Fabric
    {
        public Result<CreateViewModel> CreateViewModel()
        {
            var result = new Result<CreateViewModel>();
            try
            {
                var res = new LookUpProvider().GetCategories();
                if (res.IsSucces)
                {
                    result.ResultObject = new Models.CreateViewModel();
                    result.ResultObject.Categories = res.ResultObject;
                }
                else
                {
                    throw new Exception();
                }
                result.ResultObject.Product = new Product();
                result.IsSucces = true;
            }
            catch
            {
                result.IsSucces = false;
                result.Message = "Some error duriong model creation";
            }
            return result;
        }
    }
}