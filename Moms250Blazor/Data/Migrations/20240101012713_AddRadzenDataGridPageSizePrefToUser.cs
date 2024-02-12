using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moms250Blazor.Migrations
{
    /// <inheritdoc />
    public partial class AddRadzenDataGridPageSizePrefToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RadzenDataGridPageSizePref",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RadzenDataGridPageSizePref",
                table: "AspNetUsers");
        }
    }
}
