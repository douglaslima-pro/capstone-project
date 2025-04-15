using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Business.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
