using CFSE.Application.Interface;
using CFSE.Application.Users.Queries.GetUserById;
using CFSE.Persistance;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CFSE.RestApi.SecurityToken
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            if (context.UserName != context.Password)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect");

                return Task.FromResult<object>(null);
            }

            var identity = new ClaimsIdentity("JWT");

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "user"));

            for(int i = 0; i <= 50; i++)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "" + i));
            }

            context.Validated(identity);

            return Task.FromResult(0);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            try
            {
                var username = context.Parameters["username"];
                var password = context.Parameters["password"];

                // request: POST - BODY: username=sallen&password=sallen&grant_type=password

                if (username == password)
                {
                    //IDBContextCFSE db = new DBContextCFSE();
                    //IGetUserByIdQuery iGetUserByIdQuery = new GetUserByIdQuery(db);

                    //UserDetailDTO uDTO = iGetUserByIdQuery.Execute(2);

                    context.OwinContext.Set("otc:username", username);
                    context.Validated();
                }
                else
                {
                    context.SetError("Invalid credentials");
                    context.Rejected();
                }
            }
            catch
            {
                context.SetError("Server error");
                context.Rejected();
            }
            return Task.FromResult(0);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            return base.GrantRefreshToken(context);
        }
    }
}