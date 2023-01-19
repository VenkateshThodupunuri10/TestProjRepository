using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POCWebApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fbResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFromSet = table.Column<bool>(type: "bit", nullable: false),
                    IsUsedForSaveOnly = table.Column<bool>(type: "bit", nullable: false),
                    IsStageSubmitted = table.Column<bool>(type: "bit", nullable: false),
                    ResultSetID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserCreated = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormWorkflowStageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCollaborationStage = table.Column<bool>(type: "bit", nullable: false),
                    TokenGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Revision = table.Column<int>(type: "int", nullable: false),
                    TimeSpentonStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fbResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fbResults");
        }
    }
}
