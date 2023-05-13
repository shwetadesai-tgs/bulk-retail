using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Infrastructure.Extensions
{
    /// <summary>
    /// Extensions on the DateTime object
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Get the current Unix Epoch time in seconds since 1/1/1970
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static long ToUnixTime(this DateTime date)
        {
            var t = (date.ToUniversalTime() - new DateTime(1970, 1, 1));
            return (int)t.TotalSeconds;
        }
    }
}
