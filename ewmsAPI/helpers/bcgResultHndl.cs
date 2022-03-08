using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ewms.common.Helpers
{
    public class bcgResult
    {

        public bool success;
        public string message;
        public string error_code;
        public string source;
        public int debugLevel;
        public string error_detail = "";
        public string data;
        public Object related_data;
        public string api_response = "";
    

        public bcgResult notify (bool isSuccess, string theErrorCode, string theMessage, string theSource, int theDebugLevel = 0, string theErrorDetail = "", string theRelatedData = "") {

            bcgResult iResult = new bcgResult();

            //iResult.success = false;
            iResult.message = "";
            iResult.error_code = "";
            iResult.source = "";
            iResult.debugLevel = 0;
            iResult.error_detail = "";
            iResult.data = "";

            try
            {
                iResult.success = isSuccess;
                iResult.error_code = theErrorCode;
                iResult.message = theMessage.Replace("\"","").Replace("'","");
                iResult.source = theSource;
                iResult.debugLevel = theDebugLevel;
                iResult.error_detail = theErrorDetail;
                iResult.data = theRelatedData;

            } catch (Exception ex)
            {
                iResult.message = ex.Message;
            }

            return iResult;
        }
    }

    public class ASIResult
    {
        public int response_code { get; set; }
        public string response_message { get; set; }
        public Object response_data { get; set; }
    }



    //result OLMECA INTERFACES

    public class OLMECA_sendReceivingByProductionConfirmation_result {

        public string Order_Number { get; set; }
        public string Or_Ty { get; set; }
        public string Branch_Plant { get; set; }

        public string status { get; set; }



    }


    public class OLMECA_esult
    {
        public string result_code { get; set; }
        public string result_text { get; set; }
        
    }



    public class OLMECA_sendAjustesInventario_result
    {

        //[JsonPropertyName(".net version")]
        public string PreviousDoc { get; set; }
        public string PrevDocType { get; set; }

     
    }

    public class OLMECA_sendTransferencias_result
    {

        //[JsonPropertyName(".net version")]
        public string PrevDocument { get; set; }
        public string PrevDocType { get; set; }
        public string BatchNumber { get; set; }


    }

    public class OLMECA_sendReclasificacion_result
    {

        
        public string PrevDocument { get; set; }
        public string PrevDocType { get; set; }
        //public string BatchNumber { get; set; }


    }




    public class OLMECA_sendCreditosParcial_result
    {
        public string PreviousOrder { get; set; }
        public string PreviousOrderType { get; set; }
        public string PrevOrderCompany { get; set; }

    }


    public class OLMECA_sendCreditosTotal_result {
        public string PreviousOrder { get; set; }
        public string PreviousOrderType { get; set; }
        public string PrevOrderCompany { get; set; }
    }


}
