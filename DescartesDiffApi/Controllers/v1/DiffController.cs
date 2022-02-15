using DescartesDiffApi.Model.v1;
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
        public void Put(int id, string direction, ValueToDiff valueToDiff)
        {
            if (direction == "Right")
            {
                var base64EncodedBytes = System.Convert.FromBase64String(valueToDiff.data);
                var base64EncodedBytesDisplay = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                publicId = id;
            }
            else if (direction == "Left")
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
