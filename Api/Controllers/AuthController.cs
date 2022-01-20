using Application.Auth;
using Application.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        [HttpPost]
        [Route("register")]
        public async Task<Result> Register([FromBody] RegisterCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        [Route("login")]
        public async Task<Result> Login([FromBody] LoginCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
