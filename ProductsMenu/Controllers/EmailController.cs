using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendingMail;
using BussinessLayer.Entity;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductsMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly Mailsending _mailSending;
        private readonly IConfiguration _configuration;

        public EmailController(Mailsending mailSending, IConfiguration configuration)
        {
            _configuration = configuration;
            _mailSending = mailSending;
        }
        // GET: api/<EmailController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmailController>
        [HttpPost]
        public ActionResult<EmailRequest> Post([FromBody] EmailRequest value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            
                var fromAddress = _configuration.GetValue<string>("SMTP:FromAddress");
            var password = _configuration.GetValue<string>("SMTP:Password");
            _mailSending.SendEmail(fromAddress, password, value.ToAddress, value.Subject, value.Body);
            return Ok("EMAIL SENT");
        }

        // PUT api/<EmailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
