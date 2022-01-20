using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Jwt
{
    public class JwtResult : Result
    {
        public string Token { get; set; }

        public JwtResult(bool succeeded, IEnumerable<string> errors, string token) : base(succeeded, errors, null)
        {
            Token = token;
        }

        public static JwtResult Success(string token)
        {
            return new JwtResult(true, new string[] { }, token);
        }
    }
}
