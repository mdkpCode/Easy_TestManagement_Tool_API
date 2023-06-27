using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy_TestManagement_Tool.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_TestRuns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TestRuns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestStatusDictionary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestStatusDictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TestCaseOnTestRun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    TestRunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TestCaseOnTestRun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TestCaseOnTestRun_TB_TestRuns_TestRunId",
                        column: x => x.TestRunId,
                        principalTable: "TB_TestRuns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_TestCaseOnTestRun_TestStatusDictionary_StatusId",
                        column: x => x.StatusId,
                        principalTable: "TestStatusDictionary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_TestCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TestCaseOnTestRunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TestCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TestCases_TB_TestCaseOnTestRun_TestCaseOnTestRunId",
                        column: x => x.TestCaseOnTestRunId,
                        principalTable: "TB_TestCaseOnTestRun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_TestSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedResults = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestCaseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TestSteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_TestSteps_TB_TestCases_TestCaseId",
                        column: x => x.TestCaseId,
                        principalTable: "TB_TestCases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TestCaseOnTestRun_StatusId",
                table: "TB_TestCaseOnTestRun",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TestCaseOnTestRun_TestRunId",
                table: "TB_TestCaseOnTestRun",
                column: "TestRunId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TestCases_TestCaseOnTestRunId",
                table: "TB_TestCases",
                column: "TestCaseOnTestRunId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TestSteps_TestCaseId",
                table: "TB_TestSteps",
                column: "TestCaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TestSteps");

            migrationBuilder.DropTable(
                name: "TB_TestCases");

            migrationBuilder.DropTable(
                name: "TB_TestCaseOnTestRun");

            migrationBuilder.DropTable(
                name: "TB_TestRuns");

            migrationBuilder.DropTable(
                name: "TestStatusDictionary");
        }
    }
}
