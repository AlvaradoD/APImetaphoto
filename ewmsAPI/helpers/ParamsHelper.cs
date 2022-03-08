using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ewms.common.models.entity;
using ewms.common.Helpers;
using ewms.common.models.ViewModels;

namespace ewms.common.Helpers
{
    public class ParamsHelper
    {
        public string default_company = "";
        public bcgResult loadParameters()
        {
            bcgResult iResult = new bcgResult();

            try
            {              
                iResult = iResult.notify(true, "OK", "Parameters loaded successfully", "Params.loadParameters");
            }
            catch (Exception ex)
            {
                iResult = iResult.notify(false, "ERR", "Error loading parameters. ", "Params.loadParameters", 0, ex.Message);
            }

            return iResult;
        }

       

        private bool getValue(string iValue, bool iDefault = false)
        {
            if (iValue == "1")
                return true;
            else return false;
        }
    }
}
