using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Admin.Controllers
{
    public class ApplicationListController : ApiController
    {
        // GET: api/ApplicationList
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ApplicationList/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ApplicationList
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ApplicationList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApplicationList/5
        public void Delete(int id)
        {
        }
    }
}
