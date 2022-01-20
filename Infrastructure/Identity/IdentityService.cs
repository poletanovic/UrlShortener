using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Infrastructure.Jwt;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class IdentityService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IApplicationDbContext _context;

        public IdentityService(UserManager<ApplicationUser> userManager, ITokenService tokenService, IApplicationDbContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }

        public async Task<Result> CreateUserAsync(string email, string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                var newUser = new ApplicationUser
                {
                    UserName = username,
                    Email = username,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                var result = await _userManager.CreateAsync(new ApplicationUser { Email = username, UserName = username }, password);

                if (result.Succeeded)
                {
                    _context.Authors.Add(new Author() { UserId = newUser.Id, Username = newUser.UserName });

                    await _context.SaveChangesAsync(new System.Threading.CancellationToken());

                    return Result.Success(new Tuple<string, object>("AuthorId", _context.Authors.FirstOrDefault(o => o.UserId == newUser.Id)?.Id));
                }
                else
                {
                    return result.ToApplicationResult();
                }               
            }

            return Result.Failure(new string[] { "User already exist!" });
        }

        public async Task<ApplicationUser> GetAuthenticatedUser(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return user;
            }

            return null;
        }

        public async Task<Result> LoginAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return await _tokenService.GetToken(username);
            }

            return Result.Failure(new string[] { "User does not exist!" });
        }
    }
}
