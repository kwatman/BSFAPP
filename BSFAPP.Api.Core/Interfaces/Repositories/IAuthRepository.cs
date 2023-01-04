using System;
using System.Threading.Tasks;
using BSFAPP.Api.Core.Models;

namespace BSFAPP.Api.Core.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<Guid>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}