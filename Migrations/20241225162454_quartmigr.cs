using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_One_Trick_Pony_Br.Migrations
{
    /// <inheritdoc />
    public partial class quartmigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutorID",
                table: "Comment",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutorID",
                table: "Comment");
        }
    }
}
