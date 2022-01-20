using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Auth
{
    public class RegisterCommand : IRequest<Result>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result>
    {
        private readonly IUserManager _identityService;

        public RegisterCommandHandler(IUserManager identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.CreateUserAsync(request.Email, request.Username, request.Password);
        }
    }
}
