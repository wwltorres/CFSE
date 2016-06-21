using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using CFSE.RestApi.Exceptions;

namespace CFSE.RestApi.HelperClasses.Filters
{
    public class ConflictExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //public override void OnException(HttpActionExecutedContext context)
        //{
        //    if (context.Exception is ConflictException)
        //    {
        //        var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
        //        {
        //            Content = new StringContent(context.Exception.Message),
        //            ReasonPhrase = "NotFound"
        //        };

        //        throw new HttpResponseException(resp);
        //    }
        //}
    }
}