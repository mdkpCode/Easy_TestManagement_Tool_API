using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy_TestManagement_Tool.Migrations
{
    /// <inheritdoc />
    public partial class NewTablesHasBeenAddedFixX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TestCases_TestRunTestCases_TestCaseOnTestRunId",
                table: "TB_TestCases");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_TestSteps_TestRunTestCases_TestCaseOnTestRunId",
                table: "TB_TestSteps");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRunTestCases_TB_TestRuns_TestRunId",
                table: "TestRunTestCases");

            migrationBuilder.DropTable(
                name: "TestRunTestCasesOnTestRun");

            migrationBuilder.DropIndex(
                name: "IX_TB_TestSteps_TestCaseOnTestRunId",
                table: "TB_TestSteps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TestRunTestCases",
                table: "TestRunTestCases");

            migrationBuilder.DropColumn(
                name: "TestCaseOnTestRunId",
                table: "TB_TestSteps");

            migrationBuilder.RenameTable(
                name: "TestRunTestCases",
                newName: "TB_TestCaseOnTestRun");

            migrationBuilder.RenameIndex(
                name: "IX_TestRunTestCases_TestRunId",
                table: "TB_TestCaseOnTestRun",
                newName: "IX_TB_TestCaseOnTestRun_TestRunId");

            migrationBuilder.AddColumn<long>(
                name: "StatusId",
                table: "TB_TestCaseOnTestRun",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_TestCaseOnTestRun",
                table: "TB_TestCaseOnTestRun",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_TB_TestCaseOnTestRun_StatusId",
                table: "TB_TestCaseOnTestRun",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TestCaseOnTestRun_TB_TestRuns_TestRunId",
                table: "TB_TestCaseOnTestRun",
                column: "TestRunId",
                principalTable: "TB_TestRuns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TestCaseOnTestRun_TestStatusDictionary_StatusId",
                table: "TB_TestCaseOnTestRun",
                column: "StatusId",
                principalTable: "TestStatusDictionary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TestCases_TB_TestCaseOnTestRun_TestCaseOnTestRunId",
                table: "TB_TestCases",
                column: "TestCaseOnTestRunId",
                principalTable: "TB_TestCaseOnTestRun",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TestCaseOnTestRun_TB_TestRuns_TestRunId",
                table: "TB_TestCaseOnTestRun");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_TestCaseOnTestRun_TestStatusDictionary_StatusId",
                table: "TB_TestCaseOnTestRun");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_TestCases_TB_TestCaseOnTestRun_TestCaseOnTestRunId",
                table: "TB_TestCases");

            migrationBuilder.DropTable(
                name: "TestStatusDictionary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_TestCaseOnTestRun",
                table: "TB_TestCaseOnTestRun");

            migrationBuilder.DropIndex(
                name: "IX_TB_TestCaseOnTestRun_StatusId",
                table: "TB_TestCaseOnTestRun");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "TB_TestCaseOnTestRun");

            migrationBuilder.RenameTable(
                name: "TB_TestCaseOnTestRun",
                newName: "TestRunTestCases");

            migrationBuilder.RenameIndex(
                name: "IX_TB_TestCaseOnTestRun_TestRunId",
                table: "TestRunTestCases",
                newName: "IX_TestRunTestCases_TestRunId");

            migrationBuilder.AddColumn<int>(
                name: "TestCaseOnTestRunId",
                table: "TB_TestSteps",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TestRunTestCases",
                table: "TestRunTestCases",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TestRunTestCasesOnTestRun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StepId = table.Column<int>(type: "int", nullable: false),
                    ActualResult = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRunTestCasesOnTestRun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestRunTestCasesOnTestRun_TB_TestSteps_StepId",
                        column: x => x.StepId,
                        principalTable: "TB_TestSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TestSteps_TestCaseOnTestRunId",
                table: "TB_TestSteps",
                column: "TestCaseOnTestRunId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRunTestCasesOnTestRun_StepId",
                table: "TestRunTestCasesOnTestRun",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TestCases_TestRunTestCases_TestCaseOnTestRunId",
                table: "TB_TestCases",
                column: "TestCaseOnTestRunId",
                principalTable: "TestRunTestCases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TestSteps_TestRunTestCases_TestCaseOnTestRunId",
                table: "TB_TestSteps",
                column: "TestCaseOnTestRunId",
                principalTable: "TestRunTestCases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRunTestCases_TB_TestRuns_TestRunId",
                table: "TestRunTestCases",
                column: "TestRunId",
                principalTable: "TB_TestRuns",
                principalColumn: "Id");
        }
    }
}
