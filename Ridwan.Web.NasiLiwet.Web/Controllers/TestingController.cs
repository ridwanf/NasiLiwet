using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ridwan.Web.NasiLiwet.Web.Models;

namespace Ridwan.Web.NasiLiwet.Web.Controllers
{
    public class TestingController : Controller
    {
        // GET: Testing
        public ActionResult Index()
        {
            var model = new Product();
            return View(model);
        }
    }
}