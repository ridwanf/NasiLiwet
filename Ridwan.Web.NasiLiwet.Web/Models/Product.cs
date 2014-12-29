using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ridwan.Web.NasiLiwet.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Weight { get; set; }
        public string PicUrl { get; set; }
        public string PicUrlLg { get; set; }
        public double Brutto { get; set; }
        public decimal Long { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public string PriceString
        {
            get { return Price.ToString("N"); }
        }

    }
}