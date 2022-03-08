using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ewms.common.Helpers
{
 

    public class timeline
    {
        public DateTime? timeline_label { get; set; }

        public List<timeline_item> items { get; set; }

    }


    public class timeline_item
    {
        public string hour { get; set; }
        public string action { get; set; }

    }

    public class Formatter
    {
        public string SecondsToHHMMSS(decimal theValue)
        {
            string iResult = "";

            try
            {
                decimal iHours = 0;
                decimal iMinutes = 0;
                decimal iSeconds = 0;

                iHours = Math.Truncate ((theValue / (60 * 60)));
                iMinutes = Math.Truncate((theValue - (iHours * 60 * 60)) / 60);
                iSeconds = theValue - (iHours * 60 * 60) - (iMinutes * 60);

                iResult = iHours.ToString() + ":" + iMinutes.ToString().PadLeft(2, '0') + ":" + iSeconds.ToString().PadLeft(2, '0');
                

            } catch (Exception ex)
            {
                iResult = "";
            }

            return iResult;
        }

        public Boolean IsNumber(String value)
        {
            return value.All(Char.IsDigit);
        }
    }

}
