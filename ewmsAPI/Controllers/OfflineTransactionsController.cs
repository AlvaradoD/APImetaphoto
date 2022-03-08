using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ewms.common.Helpers;
using ewms.common.models.ViewModels;

using System.Web.Script.Serialization;

namespace ewmsAPI.Controllers
{
    public class OfflineTransactionsController : ApiController
    {
        

        [HttpPost]
        public string ProcessTransactions(System.Net.Http.HttpRequestMessage request)//([FromBody]string transactions)
        {
            
            return "";
        }
    }
}