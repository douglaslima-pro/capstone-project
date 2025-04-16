using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CapstoneProject.Business.Entities;
using CapstoneProject.Business.Exceptions;
using CapstoneProject.Business.Interfaces.Repositories;
using CapstoneProject.Business.Interfaces.Services;
using CapstoneProject.Business.Models.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CapstoneProject.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthService(
            IConfiguration configuration,
            IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<string> LoginAsync(LoginModel model)
        {
            var user = await _userRepository.GetAsync(x => x.Email == model.Email);

            if (user == null)
            {
                throw new InvalidLoginAttemptException("Invalid login attempt!");
            }

            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                throw new InvalidLoginAttemptException("Invalid login attempt!");
            }

            // Generates JWT token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("role", user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken
            (
                issuer: "CapstoneProject",
                audience: "CapstoneProject",
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> RegisterAsync(RegisterModel model)
        {
            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Username = model.Username,
                Role = "User",
            };

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            user.PasswordHash = passwordHash;

            return await _userRepository.CreateAsync(user);
        }

        public async Task<bool> AssignRoleByIdAsync(int id, string role)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException("User does not exist!");
            }

            user.Role = role;

            return await _userRepository.UpdateAsync(user);
        }
    }
}
