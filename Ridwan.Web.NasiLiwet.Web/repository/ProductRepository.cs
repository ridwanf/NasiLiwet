using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Xml.Linq;
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


            return _products.ToList().Where(o => o.IsAvailable);

        }

        public List<Product> GetRandomData()
        {
            var products = new List<Product>();
            if (_products.Any())
            {
                var rnd = new Random();
                int r = rnd.Next(1, _products.Count() - 4);
                return _products.Skip(r).Take(4).ToList().ToList();
            }
            return null;
        }

        public Product GetOneById(int id)
        {
            return _products.First(p => p.Id == id);
        }

        public StatusOngkir GetStatusOngkir(string origin)
        {
            WebClient client = new WebClient();

            //Url Dari API
            string url = "http://api.ongkir.info/city/list";

            //POST Parameter
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("query", origin);
            nvc.Add("type", "destination");
            nvc.Add("courier", "jne");
            nvc.Add("API-Key", "516f7b791ec69f1a97b4af1506f2121f");
            //jika menggunakan method UploadValuesAsync()
            //  client.UploadValuesCompleted += new UploadValuesCompletedEventHandler(ClientUploadValuesCompleted);
            //mengambil response bertipe byte ketika melakukan Upload Value
            byte[] byteResponse = client.UploadValues(new Uri(url), "POST", nvc);
            //mengkonversi response dari byte ke string
            string response = Encoding.ASCII.GetString(byteResponse);
            //melakukan parsing XML dari string
            XElement xmlFeed = XElement.Parse(response);

            //Alternatif melakukan query status dari XML
            //var status = from StatusFeed in xmlFeed.Descendants("status")
            //             select new Status
            //             {
            //                 Code = StatusFeed.Element("code").Value,
            //                 Description = StatusFeed.Element("description").Value
            //             };

            //memperoleh kode status
            var status = xmlFeed.Descendants("status").Elements<XElement>("code");

            if (Int32.Parse(status.First<XElement>().Value) == 0)
            {
                //memperoleh semua item kota yang ada
                var cities = xmlFeed.Descendants("cities").Elements<XElement>("item");
                foreach (XElement city in cities)
                {
                    Console.WriteLine("Kota: " + city.Value);
                }

            }
            else
            {
                Console.WriteLine("Tidak ditemukan kota yang diawali dengan band.");
            }

            return null;
        }




    }
}