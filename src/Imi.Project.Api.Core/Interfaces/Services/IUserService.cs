using Imi.Project.Api.Core.DTO_S.Users;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseDTO> RegisterAsync(UserRegisterRequestDTO request);

        Task<UserResponseDTO> LoginAsync(UserLoginRequestDTO request);
    }
}
