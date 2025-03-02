using System;

namespace FrejaClient.Extensions
{
    public class FrejaException : Exception
    {
        public FrejaException(string message) : base(message)
        {
        }
    }
}
