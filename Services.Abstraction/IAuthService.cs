using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Services.Abstraction
{
    public interface IAuthService
    {
        Task<UserResultDto> SignInAsync(LoginDto loginDto);

        Task<UserResultDto> SignUpAsync(RegisterDto registerDto);

        Task<IEnumerable<UsersResultDto>> GetAllUsersExceptOneAsync(string userId);
    }
}
