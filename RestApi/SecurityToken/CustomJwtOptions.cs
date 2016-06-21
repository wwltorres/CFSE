using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CFSE.RestApi.SecurityToken
{
    public class CustomJwtOptions : JwtBearerAuthenticationOptions
    {
        public CustomJwtOptions()
        {
            var issuer = "cfseapp.com";
            var audience = "all";
            var key = TextEncodings.Base64Url.Decode("UHxNtYMRYwvfpO1dS5pWLKL0M2DgOj40");

            this.AuthenticationMode = 0;
            AllowedAudiences = new[] {audience};
            IssuerSecurityTokenProviders = new[]
            {
                new SymmetricKeyIssuerSecurityTokenProvider(issuer, key)
            };
        }
    }
}