using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CFSE.RestApi.SecurityToken
{
    public class CustomOAuthOptions : OAuthAuthorizationServerOptions
    {
        public CustomOAuthOptions()
        {
            TokenEndpointPath = new PathString("/Token");
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60);
            AccessTokenFormat = new CustomJwtFormat();
            Provider = new CustomOAuthProvider();
            RefreshTokenProvider = new ApplicationRefreshTokenProvider();
            AllowInsecureHttp = true;
            
        }
    }
}