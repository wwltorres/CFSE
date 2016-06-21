using Microsoft.Owin.Security;
using System;
using System.IdentityModel.Tokens;

namespace CFSE.RestApi.SecurityToken
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private string SignatureAlgorithm = "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256";
        private string DigestAlgorithm = "http://www.w3.org/2001/04/xmlenc#sha256";

        public CustomJwtFormat(){}

        public string Protect(AuthenticationTicket data)
        {
            if (data == null) throw new ArgumentNullException("data");

            var issuer = "cfseapp.com";
            var audience = "all";
            var key = Convert.FromBase64String("UHxNtYMRYwvfpO1dS5pWLKL0M2DgOj40");
            var now = DateTime.UtcNow;
            var expires = data.Properties.ExpiresUtc;
            var signingCredentials = new SigningCredentials(
                                        new InMemorySymmetricSecurityKey(key),
                                        SignatureAlgorithm,
                                        DigestAlgorithm);

            var token = new JwtSecurityToken(issuer, audience, data.Identity.Claims,
                                             now, expires.Value.UtcDateTime, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}