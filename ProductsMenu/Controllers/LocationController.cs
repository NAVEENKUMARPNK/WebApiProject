using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        ILocationinterface regs = null;
        public LocationController(ILocationinterface source)
        {
            regs = source;
        }
        // GET: api/<LocationController>
        [HttpGet]
        public IEnumerable<Location> Get()
        {
            return regs.selectalllocation();
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public IActionResult Getbyid(int id)
        {
            return Ok( regs.selectbyid(id));
        }

        // POST api/<LocationController>
        [HttpPost]
        public IActionResult Post([FromBody] Location value)
        {
            regs.insertlocation(value);
            return Ok();
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Location value)
        {
            regs.Updatelocation(value);
            return Ok();
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            regs.Deletelocation(id);
            return Ok();
        }
    }
}
