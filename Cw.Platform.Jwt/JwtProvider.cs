using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cw.Platform.Jwt
{
    public class JwtProvider : IJwtProvider
    {
        readonly TokenValidationParameters _parameters;
        readonly Action<SecurityTokenDescriptor> _options;
        readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        public JwtProvider(TokenValidationParameters parameters, Action<SecurityTokenDescriptor> options)
        {
            _parameters = parameters;
            _options = options;
        }

        // Generate token method
        public string generateJwtToken(string role)
        {
            var key = Encoding.ASCII.GetBytes("WEF@%#$%ewfwe456464$%&$^fgd_2233eWE@#@RW@#@"); //secret should be encrypted and saved in db or key vault.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Role, role) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            return _jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
