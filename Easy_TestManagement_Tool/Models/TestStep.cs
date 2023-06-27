using System.ComponentModel.DataAnnotations;

namespace Easy_TestManagement_Tool.Models
{
    public class TestStep
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Description { get; set; }
        [Required]
        public required string ExpectedResults { get; set; }
    }
}