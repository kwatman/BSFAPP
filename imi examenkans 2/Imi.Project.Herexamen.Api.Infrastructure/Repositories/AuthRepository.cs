using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Herexamen.Api.Core.Interfaces.Repositories;
using Imi.Project.Herexamen.Api.Core.Models;
using Imi.Project.Herexamen.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Imi.Project.Herexamen.Api.Infrastucture.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _ctx;
        private readonly IConfiguration _config;

        public AuthRepository(AppDbContext ctx, IConfiguration config)
        {
            _ctx = ctx;
            _config = config;
        }

        // REGISTER
        public static void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _ctx.Users.AnyAsync(u => u.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ServiceResponse<Guid>> Register(User user, string password)
        {
            ServiceResponse<Guid> response = new ServiceResponse<Guid>();

            if (await UserExists(user.Username))
            {
                response.Success = false;
                response.Message = "User already exists!";
                return response;
            }
            else
            {
                HashPassword(password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _ctx.Users.AddAsync(user);
                await _ctx.SaveChangesAsync();

                response.Data = user.Id;
                return response;
            }
        }

        //LOGIN
        private bool CheckPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private string CreateJwt(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("HasAcceptedTermsAndConditions", user.HasAcceptedTermsAndConditions.ToString())
            };

            SymmetricSecurityKey key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            SecurityToken jwt = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(jwt);
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            User user = await _ctx.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else if (!CheckPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password";
            }
            else
            {
                response.Data = CreateJwt(user);
            }

            return response;
        }
    }
}