using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy_TestManagement_Tool.Migrations
{
    /// <inheritdoc />
    public partial class NewTablesHasBeenAddedFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "TestRunTestCasesOnTestRun",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestRunTestCasesOnTestRun_StepId",
                table: "TestRunTestCasesOnTestRun",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestRunTestCasesOnTestRun_TB_TestSteps_StepId",
                table: "TestRunTestCasesOnTestRun",
                column: "StepId",
                principalTable: "TB_TestSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestRunTestCasesOnTestRun_TB_TestSteps_StepId",
                table: "TestRunTestCasesOnTestRun");

            migrationBuilder.DropIndex(
                name: "IX_TestRunTestCasesOnTestRun_StepId",
                table: "TestRunTestCasesOnTestRun");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "TestRunTestCasesOnTestRun");
        }
    }
}
