using System.ComponentModel.DataAnnotations;

namespace Easy_TestManagement_Tool.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public UserRoleEnum Role { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
