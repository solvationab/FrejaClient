using System;
using FrejaClient.Dto;

namespace FrejaClient.Extensions
{
    public class FrejaException : Exception
    {
        public FrejaException(FrejaErrorResponse frejaErrorResponse) : base("Error message") // TODO: Fix this to use correct message
        {
            FrejaErrorResponse = frejaErrorResponse;
        }

        public FrejaErrorResponse FrejaErrorResponse { get; }
    }
}
