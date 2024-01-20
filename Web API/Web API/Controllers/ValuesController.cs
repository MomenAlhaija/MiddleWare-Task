using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace Web_API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpGet]
        public HttpResponseMessage Archive(int year,int month,int day) { 
        
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        [HttpPost]
        public IHttpActionResult httpActionResult(string customer)
        {
            return Ok(new string[] { "value1", "value2" } );
        }
        // POST api/values
        public async Task<IHttpActionResult> Post([FromBody] string value)
        {
            return Ok(value);
        }

        // PUT api/values/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] string value)
        {
            return Ok(value);
        }
       
        // DELETE api/values/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            return Ok(0);
        }
    }
}
