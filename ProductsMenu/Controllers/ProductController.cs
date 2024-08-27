using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   

    public class ProductController : ControllerBase
    {

        IProductRepository source = null;
        public ProductController(IProductRepository prodRepo)
        {
            source = prodRepo;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            return source.ShowAllProducts();
            
        }

        // GET api/<ProductController>/5
        [HttpGet("{name}")]
        public Products Get(string name)
        {
            return source.Showproductbyname(name);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] Products value)
        {
            source.Registerproducts(value);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Products value)
        {
            source.Updateproducts(value);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            source.Deleteproducts(id);
        }
    }
}
