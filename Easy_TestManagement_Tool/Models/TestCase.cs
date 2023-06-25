using Easy_TestManagement_Tool.Models.EnumModels;
using System.Collections.Generic;

namespace Easy_TestManagement_Tool.Models
{
    public class TestCase
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Precondition { get; set; } = string.Empty;
        public List<TestStep>? Steps { get; set; }
        public bool IsActive { get; set; }
        public TestStatusEnum Status { get; set; }
    }
}