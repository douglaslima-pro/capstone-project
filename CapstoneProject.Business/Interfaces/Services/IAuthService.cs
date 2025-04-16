using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneProject.Business.Models.Auth;

namespace CapstoneProject.Business.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginModel model);
        Task<bool> RegisterAsync(RegisterModel model);
        Task<bool> AssignRoleByIdAsync(int id, string role);
    }
}
