using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VOD.Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class courses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "Sections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
