using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ewms.common.Helpers;
using ewms.common.models.ViewModels;

using System.Web.Script.Serialization;
using ewmsAPI.ViewModels;

namespace ewmsAPI.Controllers
{
    public class DomainsController : ApiController
    {
        

        [HttpGet]
        [ActionName("GetServerData")]
        [Route("api/Domains/GetServerData")]
        [ResponseType(typeof(bcgResult))]
        public bcgResult GetServerData()
        {
            return FGetServerData();

        }


        public bcgResult FGetServerData()
        {
            bcgResult result = new bcgResult();
            ServerDataVM data = new ServerDataVM();
            try
            {
                //eWMSEntities
                string constring = "";

                constring ="conection";
                string sServer = "", sDatabase = "", sDataserver = "", sEnvironment = "", sOwner = "";
                //var bldomain = new DefDomainsBL();

                var domainEnviro = "domainEnviro";
                var domainowner = "domainowner";

                if (domainEnviro != null)
                {
                    sEnvironment = "sEnvironment";
                    data.Environment = sEnvironment;
                    data.Database = "nodb";
                   
                }

                if (domainowner != null)
                {
                    sOwner = "sOwner";
                    data.Owner = sOwner;
                }

                result.success = true;
                result.related_data = data;

                sServer = Environment.MachineName;
                data.ServerName = sServer;
 
            }
            catch (Exception ex)
            {
                result = result.notify(false, "", ex.Message, "");
                return result;
            }
            return result;
        }




    }
}