using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPlatform.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public string ErrorCode { get; }

        public DomainException(string message)
            : base(message)
        {
            ErrorCode = "DOMAIN_ERROR";
        }

        public DomainException(string message, string errorCode)
            : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
