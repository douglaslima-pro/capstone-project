using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneProject.Business.Entities;
using CapstoneProject.Business.Exceptions;
using CapstoneProject.Business.Interfaces.Repositories;
using CapstoneProject.Business.Interfaces.Services;
using CapstoneProject.Business.Models.User;

namespace CapstoneProject.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> UpdateAsync(int id, UserUpdateModel model)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException("User does not exist!");
            }

            user.Name = model.Name ?? user.Name;
            user.Email = model.Email ?? user.Email;
            user.Username = model.Username ?? user.Username;

            if (model.Password != null)
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
                user.PasswordHash = passwordHash;
            }

            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException("User does not exist!");
            }

            return await _userRepository.DeleteAsync(user);
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetAsync(x => x.Email == email);

            if (user == null)
            {
                throw new NotFoundException("User does not exist!");
            }

            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role,
            };
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException("User does not exist!");
            }

            return new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role,
            };
        }

        public async Task<IEnumerable<UserModel>> GetManyAsync()
        {
            var users = await _userRepository.GetManyAsync();

            return users.Select(user => new UserModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Username = user.Username,
                Role = user.Role,
            });
        }
    }
}
