using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneProject.Business.Models;

namespace CapstoneProject.Business.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> CreateAsync(RegisterModel model);
        Task<bool> UpdateAsync(int id, UserModel model);
        Task<bool> DeleteAsync(int id);
        Task<UserModel> GetByIdAsync(int id);
        Task<UserModel> GetByEmailAsync(string email);
        Task<IEnumerable<UserModel>> GetManyAsync();
    }
}