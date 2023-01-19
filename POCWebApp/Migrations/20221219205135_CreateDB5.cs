using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POCWebApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_fbResults",
                table: "fbResults");

            migrationBuilder.RenameTable(
                name: "fbResults",
                newName: "FBResults");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FBResults",
                table: "FBResults",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FBResults",
                table: "FBResults");

            migrationBuilder.RenameTable(
                name: "FBResults",
                newName: "fbResults");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fbResults",
                table: "fbResults",
                column: "Id");
        }
    }
}
