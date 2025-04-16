using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Business.Models.User
{
    public class UserUpdateModel
    {
        [StringLength(150)]
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [MinLength(6)]
        [MaxLength(30)]
        public string? Username { get; set; }
        [MinLength(6)]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
