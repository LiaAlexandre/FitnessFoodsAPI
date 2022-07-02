using FitnessFoods.API.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessFoods.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessFoodsController : ControllerBase
    {
        IConfiguration _configuration;

        public FitnessFoodsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/<FitnessFoodsController>
        [ApiKey]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FitnessFoodsController>/5
        [ApiKey]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FitnessFoodsController>
        [ApiKey]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FitnessFoodsController>/5
        [ApiKey]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FitnessFoodsController>/5
        [ApiKey]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
