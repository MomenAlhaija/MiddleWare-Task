using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Intalio_Task.Migrations
{
    /// <inheritdoc />
    public partial class dbddtype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Users");
        }
    }
}
