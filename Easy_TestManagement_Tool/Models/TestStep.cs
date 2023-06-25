namespace Easy_TestManagement_Tool.Models
{
    public class TestStep
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string ExpectedResults { get; set; }
    }
}