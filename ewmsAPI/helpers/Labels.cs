using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

namespace ewms.common.Helpers
{
    public class Labels
    {
        //private eWMSEntities dbEWMSLocal = new eWMSEntities();
        public void sendLabelToPrinter(string theZpl, string thePrinterUrl)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(thePrinterUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                vw_zpl iZpl = new vw_zpl();
                iZpl.zpl = theZpl;

                var response = client.GetAsync("api/Print?zpl=" + theZpl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string resultado = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {


            }

        }



        public bool printLabel(string theZpl, string thePrinterUrl)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(thePrinterUrl);
            bool iresponse = false;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                vw_zpl iZpl = new vw_zpl();
                if (!string.IsNullOrEmpty(theZpl))
                {
                    theZpl = theZpl.Replace("#", "");
                }
                iZpl.zpl = theZpl;
                //bcgHelper.saveLog(thePrinterUrl + "api/Print?zpl=" + theZpl, "Labels.printLabel");
                var response = client.GetAsync("api/Print?zpl=" + theZpl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string resultado = response.Content.ReadAsStringAsync().Result;
                    iresponse = true;
                }
            }
            catch (Exception ex)
            {
                iresponse = false;

            }
            return iresponse;

        }

    }

    class vw_zpl
    {
        public string zpl { get; set; }
    }

}
