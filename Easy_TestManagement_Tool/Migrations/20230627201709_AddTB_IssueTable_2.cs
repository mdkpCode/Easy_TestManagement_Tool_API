using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Easy_TestManagement_Tool.Migrations
{
    /// <inheritdoc />
    public partial class AddTB_IssueTable_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "issueSeverityEnum",
                table: "TB_Issue",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "Severity",
                table: "TB_Issue",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Severity",
                table: "TB_Issue");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TB_Issue",
                newName: "issueSeverityEnum");
        }
    }
}
