using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CFSE.RestApi.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException() : base() { }
        public ConflictException(string message) : base(message) { }
        public ConflictException(string message, Exception ex) : base(message, ex) { }
    }
    
}