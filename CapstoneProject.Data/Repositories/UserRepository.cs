using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneProject.Business.Entities;
using CapstoneProject.Business.Interfaces.Repositories;
using CapstoneProject.Data.Context;

namespace CapstoneProject.Data.Repositories
{
    public class UserRepository : Repository<User, ApplicationDbContext>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
    }
}
