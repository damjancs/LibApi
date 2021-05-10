using AutoMapper;
using LibApi.Entities;
using LibApi.Exceptions;
using LibApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LibApi.Service
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwtToken(LoginDto dto);
    }
    public class UserService : IUserService
    {
        private LibraryDbContext _dbContext;
        private IMapper _mapper;
        private IPasswordHasher<User> _passwordHasher;
        private AuthenticationSettings _authenticationSettings;

        public UserService(LibraryDbContext dbContext, IMapper mapper, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public string GenerateJwtToken(LoginDto dto)
        {
            var user = _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);

            if (user is null)
            {
                throw new BadRequestException("Invalid username or password.");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password.");
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim("BirthDate", user.BirthDate.ToString("yyyy-mm-dd"))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(
                _authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                BirthDate = dto.BirthDate,
                RoleId = dto.RoleId
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}
