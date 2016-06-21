using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CFSE.RestApi.Exceptions
{
    public class BadRequestExeption : Exception
    {
        public BadRequestExeption() : base() { }
        public BadRequestExeption(string message) : base(message) { }
        public BadRequestExeption(string message, Exception ex) : base(message, ex) { }
    }
}