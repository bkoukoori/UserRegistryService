using System.ComponentModel.DataAnnotations;

namespace UserRegistryService.DBContext
{
    public class UserProfile
    {
        [Key]
        [Required]
        public Guid AccountId { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Username must be alphanumeric only.")]
        public string? Username { get; set; }
    }
}