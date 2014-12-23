using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using Ridwan.Web.NasiLiwet.Web.Models;

namespace Ridwan.Web.NasiLiwet.Web.repository
{
    public class ProductRepository : IProductRepository
    {

        public List<Product> GetAllData()
        {
           // string appPath = "F:\\Project\\Api\\Ridwan.Web.NasiLiwet\\Ridwan.Web.NasiLiwet.Web\\data\\product.json";
           var appPath =  Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data\product.json");
            using (var r = new StreamReader(appPath))
            {
                string json = r.ReadToEnd();
                 return JsonConvert.DeserializeObject<List<Product>>(json);
            }
               
        }
    }
}