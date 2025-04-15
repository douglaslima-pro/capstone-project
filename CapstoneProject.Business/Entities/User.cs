using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Business.Entities
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
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
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
    }
}
