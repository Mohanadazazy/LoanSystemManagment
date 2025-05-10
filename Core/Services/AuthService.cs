using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Abstraction;
using Shared;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AuthService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            this._mapper = mapper;
        }

        

        public async Task<UserResultDto> SignInAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return null;
            var flag = await _userManager.CheckPasswordAsync(user,loginDto.Password);
            if (!flag) return null;
            return new UserResultDto()
            {
                Email = user.Email,
                UserId = user.Id,
                UserName = user.UserName,
                Token = "ssssss"
            };
        }

        public async Task<UserResultDto> SignUpAsync(RegisterDto registerDto)
        {
            var user = new AppUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.Phone,
            };

            var result = await _userManager.CreateAsync(user,registerDto.Password);

            if (!result.Succeeded) return null;
            return new UserResultDto()
            {
                Email = user.Email,
                UserId = user.Id,
                UserName = user.UserName,
                Token = "sssss"
            };
            
        }

        public async Task<IEnumerable<UsersResultDto>> GetAllUsersExceptOneAsync(string userId)
        {
            var users = await _userManager.Users.Where(U => U.Id != userId).ToListAsync();
            var UsersResult = _mapper.Map<IEnumerable<UsersResultDto>>(users);
            return UsersResult;
        }
    }
}
