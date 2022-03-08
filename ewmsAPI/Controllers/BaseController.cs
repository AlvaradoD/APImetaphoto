using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace ewmsAPI.Controllers
{
    public class BaseController : ApiController
    {
        public string ewmsTimeZone = "";
        public string ewmsTimeZoneOffset = "";


        

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            try
            {
                ewmsTimeZone = Request.Headers.GetValues("ewms-timezone").FirstOrDefault();
                ewmsTimeZoneOffset = Request.Headers.GetValues("ewms-timezone-offset").FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
           
        }
    }
}