using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using CFSE.RestApi.Exceptions;
using System.Data.Entity.Validation;

namespace CFSE.RestApi.HelperClasses.Handlers
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is ArgumentNullException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "ArgumentNullException"
                };

                context.Result = new ErrorMessageResult(context.Request, result);
            }
            else if(context.Exception is NotFoundException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Not Found"
                };

                context.Result = new ErrorMessageResult(context.Request, result);
            }
            else if (context.Exception is ConflictException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Conflict"
                };

                context.Result = new ErrorMessageResult(context.Request, result);
            }
            else if (context.Exception is BadRequestExeption)
            {
                var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "BadRequest"
                };

                context.Result = new ErrorMessageResult(context.Request, result);
            }
            else if(context.Exception is DbEntityValidationException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.Conflict)
                {
                    Content = new StringContent(context.Exception.Message),
                    ReasonPhrase = "Conflict"
                };

                context.Result = new ErrorMessageResult(context.Request, result);
            }
            else
            {
                // Handle other exceptions
            }
        }

        public class ErrorMessageResult : IHttpActionResult
        {
            private HttpRequestMessage _request;
            private HttpResponseMessage _httpResponseMessage;


            public ErrorMessageResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
            {
                _request = request;
                _httpResponseMessage = httpResponseMessage;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(_httpResponseMessage);
            }
            
        }

    }
}