using ASF.Framework.Exceptions;

namespace ASF.Business
{
    public class BusinessException : ApiException
    {
        public BusinessException(string message) : base(message,"B")
        {
        }
    }
}
