using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ridwan.Web.NasiLiwet.Web.helper;
using Ridwan.Web.NasiLiwet.Web.Models;
using Ridwan.Web.NasiLiwet.Web.repository;

namespace Ridwan.Web.NasiLiwet.Web.Controllers
{
    public class ProductController : ApiController
    {
        private IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Product> Get(bool isRandom = true)
        {
            IEnumerable<Product> data = isRandom ? _repo.GetRandomData() : _repo.GetAllData();
            return data;
        }

        public Product Get(int id)
        {

            return _repo.GetOneById(id);
        }

        //[AcceptVerbs("POST")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Mail newContact)
        {
            try
            {
                var a = MailHelper.SendEmail(newContact.Email, newContact.Name, null, newContact.Message);
                if (a)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotAcceptable);
                }

            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
