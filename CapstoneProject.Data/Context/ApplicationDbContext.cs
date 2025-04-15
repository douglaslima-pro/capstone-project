using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapstoneProject.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapstoneProject.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
