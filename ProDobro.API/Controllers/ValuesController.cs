using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProDobro.API.Models;

namespace ProDobro.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly ProDobroContext currentContext;

        public ValuesController(ProDobroContext context)
        {
            currentContext = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return currentContext.Calendar.Select(item => item.Event.Name+item.Date+item.Event.User.Ssokey).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
