using System.ComponentModel.DataAnnotations;

namespace Easy_TestManagement_Tool.Models
{
    public class Raport
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
