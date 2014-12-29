using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using Ridwan.Web.NasiLiwet.Web.Models;

namespace Ridwan.Web.NasiLiwet.Web.repository
{
    public class ProductRepository : IProductRepository
    {
        private IEnumerable<Product> _products;
        public ProductRepository()
        {
            var appPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"data/product.json");
            using (var r = new StreamReader(appPath))
            {
                string json = r.ReadToEnd();
                _products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json).ToList();
            }
        }

        public IEnumerable<Product> GetAllData()
        {
            return _products.ToList().Where(o=>o.IsAvailable);

        }

        public List<Product> GetRandomData()
        {
            var products = new List<Product>();
            if (_products.Any())
            {
                var rnd = new Random();
                int r = rnd.Next(1, _products.Count()-4);
                return _products.Skip(r).Take(4).ToList().ToList();
            }
            return null;
        }

        public Product GetOneById(int id)
        {
            return _products.First(p => p.Id == id);
        }
    }
}