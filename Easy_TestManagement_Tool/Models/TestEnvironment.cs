using System.ComponentModel.DataAnnotations;

namespace Easy_TestManagement_Tool.Models
{
    public class TestEnvironment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Url { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? Configuration { get; set; }
    }
}
