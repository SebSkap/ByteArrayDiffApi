using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DescartesDiffApi.Controllers.v1
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DiffController : ControllerBase
    {
        public int publicId;

        // GET api/<DiffController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return /*id*/publicId.ToString();
        }

        // POST api/<DiffController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DiffController>/5
        [HttpPut("{id}/{direction}")]
        public void Put(int id, string direction/*, [FromBody] string value*/)
        {
            if (direction == "right")
            {
                publicId = id;
            }
            else if (direction == "left")
            {
                publicId = id * 2;
            }
        }

        // DELETE api/<DiffController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
