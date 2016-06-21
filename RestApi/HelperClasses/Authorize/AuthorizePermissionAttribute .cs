using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CFSE.RestApi.Authorize
{
    public class AuthorizePermissionAttribute : AuthorizeAttribute
    {
        public AuthorizePermissionAttribute(params string[] permissions) : base()
    {
            Roles = string.Join(",", permissions);
        }
    }
}