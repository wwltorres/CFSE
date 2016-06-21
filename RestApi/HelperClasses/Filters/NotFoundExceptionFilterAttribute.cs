using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using CFSE.RestApi.Exceptions;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace CFSE.RestApi.HelperClasses.Filters
{
    public class NotFoundExceptionFilterAttribute : ExceptionFilterAttribute
    {
        //public override void OnException(HttpActionExecutedContext context)
        //{
        //    if (context.Exception is NotFoundException)
        //    {
        //        var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
        //        {
        //            Content = new StringContent(context.Exception.Message),
        //            ReasonPhrase = "NotFound"
        //        };


        //        throw new HttpResponseException(resp);
        //    }

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