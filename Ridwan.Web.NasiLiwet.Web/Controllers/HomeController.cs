using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ridwan.Web.NasiLiwet.Web.repository;

namespace Ridwan.Web.NasiLiwet.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _repo;

        public HomeController(IProductRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Product()
        {
            ViewBag.Message = "Product";
            var model = _repo.GetAllData();

            return View(model);
        }

        public ActionResult CaraPenyajian()
        {
            ViewBag.Message = "Cara Penyajian";
            return View();
        }
    }
}