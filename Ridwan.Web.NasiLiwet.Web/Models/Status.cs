using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ridwan.Web.NasiLiwet.Web.Models
{
    public class Status
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
    }

    public class StatusOngkir
    {
        public Status Status { get; set; }
        public List<City> City { get; set; }
    }
}