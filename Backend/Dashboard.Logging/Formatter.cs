using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Logging
{
    public class LoggingFormatter : IFormatProvider
    {
        readonly IFormatProvider basedOn;
        readonly string shortDatePattern;
        public LoggingFormatter(string shortDatePattern, IFormatProvider basedOn)
        {
            this.shortDatePattern = shortDatePattern;
            this.basedOn = basedOn;
        }
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(DateTimeFormatInfo))
            {
                var basedOnFormatInfo = (DateTimeFormatInfo)basedOn.GetFormat(formatType);
                var dateFormatInfo = (DateTimeFormatInfo)basedOnFormatInfo.Clone();
                dateFormatInfo.ShortDatePattern = this.shortDatePattern;
                return dateFormatInfo;
            }
            return this.basedOn.GetFormat(formatType);
        }
    }
}
