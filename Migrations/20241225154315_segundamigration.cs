using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_One_Trick_Pony_Br.Migrations
{
    /// <inheritdoc />
    public partial class segundamigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlatformName",
                table: "Pony");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Pony");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlatformName",
                table: "Pony",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Pony",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
