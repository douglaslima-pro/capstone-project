using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.API.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(150)]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        public string? Username { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
