using BirlesikOdeme.Business;
using BirlesikOdeme.Library.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirlesikOdeme.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<customerDTO> Get()
        {
            return customerDAL.GetInstance().GetAll();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public customerDTO GetById(int id)
        {
            return customerDAL.GetInstance().GetById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
