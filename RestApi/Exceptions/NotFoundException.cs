using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CFSE.RestApi.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception ex) : base(message, ex) { }
    }
}