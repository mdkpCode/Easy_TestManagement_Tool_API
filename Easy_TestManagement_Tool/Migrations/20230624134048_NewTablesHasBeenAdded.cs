using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy_TestManagement_Tool.Migrations
{
    /// <inheritdoc />
    public partial class NewTablesHasBeenAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRunTestCases_TB_TestCases_TestCaseId",
                table: "TestRunTestCases");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRunTestCases_TB_TestRuns_TestRunId",
                table: "TestRunTestCases");

            migrationBuilder.DropIndex(
                name: "IX_TestRunTestCases_TestCaseId",
                table: "TestRunTestCases");

            migrationBuilder.DropColumn(
                name: "TestCaseId",
                table: "TestRunTestCases");

            migrationBuilder.AlterColumn<int>(
                name: "TestRunId",
                table: "TestRunTestCases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TestCaseOnTestRunId",
                table: "TB_TestSteps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestCaseOnTestRunId",
                table: "TB_TestCases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TestRunTestCasesOnTestRun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualResult = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRunTestCasesOnTestRun", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TestSteps_TestCaseOnTestRunId",
                table: "TB_TestSteps",
                column: "TestCaseOnTestRunId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TestCases_TestCaseOnTestRunId",
                table: "TB_TestCases",
                column: "TestCaseOnTestRunId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_TB_TestCases_TestCaseOnTestRunId",
                table: "TB_TestCases");

            migrationBuilder.DropColumn(
                name: "TestCaseOnTestRunId",
                table: "TB_TestSteps");

            migrationBuilder.DropColumn(
                name: "TestCaseOnTestRunId",
                table: "TB_TestCases");

            migrationBuilder.AlterColumn<int>(
                name: "TestRunId",
                table: "TestRunTestCases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestCaseId",
                table: "TestRunTestCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestRunTestCases_TestCaseId",
                table: "TestRunTestCases",
                column: "TestCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRunTestCases_TB_TestCases_TestCaseId",
                table: "TestRunTestCases",
                column: "TestCaseId",
                principalTable: "TB_TestCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TestRunTestCases_TB_TestRuns_TestRunId",
                table: "TestRunTestCases",
                column: "TestRunId",
                principalTable: "TB_TestRuns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
