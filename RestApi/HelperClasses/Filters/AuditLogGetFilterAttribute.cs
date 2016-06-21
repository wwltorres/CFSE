using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CFSE.RestApi.HelperClasses.Filters
{
    public class AuditLogGetFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionContext)
        {
            // TODO: Logging into DB all GET transaction from front end by user
        }
    }
}