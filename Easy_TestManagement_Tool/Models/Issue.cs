using System.ComponentModel.DataAnnotations;

namespace Easy_TestManagement_Tool.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public IssueSeverityEnum Severity { get; set; }
        [Required]
        public IssueStatusEnum Status { get; set; }
    }
}
