using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ewms.common.models.ViewModels;
using ewms.common.Helpers;
using System.Web.Http.Description;

namespace ewmsAPI.Controllers
{
    public class UsersController : ApiController
    {



        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
        

    }
}
