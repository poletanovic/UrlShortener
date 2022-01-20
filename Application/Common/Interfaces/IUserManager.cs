using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<Result> CreateUserAsync(string email, string username, string password);
        Task<Result> LoginAsync(string username, string password);
    }
}
