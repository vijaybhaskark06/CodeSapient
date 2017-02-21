using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GloboMart.APIService.Models;
using GloboMart.APIService.DataAccessRepository;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http.Description;


namespace GloboMart.APIService.Controllers
{
    public class ProductAPIController : ApiController
    {
        private IDataAccessRepository<Product, int> _repository;
        //Inject the DataAccessRepository using Construction Injection 
        public ProductAPIController(IDataAccessRepository<Product, int> r)
        {
            _repository = r;
        }
        public IEnumerable<Product> Get()
        {
            return _repository.Get();
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {
            return Ok(_repository.Get(id));
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult Post(Product emp)
        {
            _repository.Post(emp);
            return Ok(emp);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Product emp)
        {
            _repository.Put(id, emp);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            _repository.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }

}
