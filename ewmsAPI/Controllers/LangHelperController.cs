using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ewms.common.Helpers;

using System.Web.Http.Description;

namespace ewmsAPI.Controllers
{
    public class LangHelperController : ApiController
    {
        LangHelper Thelper = new LangHelper();
        // GET: LangHelper
        [HttpGet]
        [Route("api/LangHelper/LoadTranslations")]
        [ResponseType(typeof(bcgResult))]
        public bcgResult LoadTranslations(string SelectedLang)
        {
            var encrypt = new EncryptionService();
            string s = encrypt.Encriptar("000-12345-abc");
            return Thelper.GetStrings(SelectedLang);
        }
    }
}