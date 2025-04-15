using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneProject.Business.Models;

namespace CapstoneProject.Business.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<string> Login(LoginModel model);
    }
}
