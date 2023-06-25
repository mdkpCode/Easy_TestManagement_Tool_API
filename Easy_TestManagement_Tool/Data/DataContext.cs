
using Easy_TestManagement_Tool.Models.EnumModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Easy_TestManagement_Tool.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=testmanagementdb;Trusted_Connection=true;TrustServerCertificate=true");
        }



        // Tables
        public DbSet<TestCase> TB_TestCases { get; set; }

        public DbSet<TestStep> TB_TestSteps { get; set; }

        public DbSet<TestRun> TB_TestRuns { get; set; }

        public DbSet<TestCaseOnTestRun> TB_TestCaseOnTestRun { get; set; }

        //public DbSet<TestStepOnTestRun> TB_TestStepOnTestRun { get; }

        // Dictionaries
        //public DbSet<TestStatus> DC_TestRunStatus { get; set; }
        //public DbSet<TestRunStatus> DC_TestStatus { get; set; }

    }
}
