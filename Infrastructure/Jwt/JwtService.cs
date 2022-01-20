using Application.Common.Interfaces;
using Application.Common.Models;
using Infrastructure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Jwt
{
    public class JwtService : ITokenService
    {
        private IConfiguration _configuration {get; set;}

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Result> GetToken(string username)
        {
            if (username != null)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var jwtOpts = _configuration.GetSection(JwtOptions.Jwt)?.Get<JwtOptions>();
                if (jwtOpts == null) throw new Exception("Configuration error");

                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpts.Secret));

                var token = new JwtSecurityToken(
                    issuer: jwtOpts.ValidIssuer,
                    audience: jwtOpts.ValidAudience,
                    expires: DateTime.Now.AddHours(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );

                return await Task.FromResult(JwtResult.Success(new JwtSecurityTokenHandler().WriteToken(token)));
            }

            return null;
        }
    }
}
