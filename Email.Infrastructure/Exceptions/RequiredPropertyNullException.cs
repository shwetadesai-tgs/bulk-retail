using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Infrastructure.Exceptions
{
    public class RequiredPropertyNullException : ArgumentNullException
    {
        public RequiredPropertyNullException()
        {
        }

        public RequiredPropertyNullException(string paramName) : base(paramName)
        {
        }

        public RequiredPropertyNullException(string paramName, string message) : base(paramName, message)
        {
        }

        public RequiredPropertyNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
