using System;


namespace ASF.Framework.Exceptions
{
    public class ApiException : Exception
    {

        public String Code { get; set; }

        public ApiException(String _message, String code) : base(_message)
        {
            Code = code;
        }

    }
}
