using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ewms.common.helpers
{
   public class DateTimeHelper
    {

        
        public DateTime Now()
        {
            // return DateTime.UtcNow;
            return DateTime.Now;
        }


        public DateTime? ToUtc(DateTime? date = null, int offset = 0)
        {
            if (date == null) return null;
            return ((DateTime)date).AddMinutes(offset);
        }

        public DateTime? FromUtc(DateTime? date = null, int offset = 0)
        {
            if (date == null) return null;
            offset = offset * -1;
            return ((DateTime)date).AddMinutes(offset);
        }

    }
}
