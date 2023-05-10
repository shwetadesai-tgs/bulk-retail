using Order.Core.Helper;

namespace Order.Core.Constants
{
    public class Enums
    {
        public enum ResultMessage
        {
            [StringValue("Something went wrong") ]
            InternalServerError,
            [StringValue("Success!")]
            Succeess,
            [StringValue("Record Not Found")]
            RecorNotFound
        }
    }

}
