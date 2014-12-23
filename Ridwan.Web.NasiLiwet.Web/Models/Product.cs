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

    }
}