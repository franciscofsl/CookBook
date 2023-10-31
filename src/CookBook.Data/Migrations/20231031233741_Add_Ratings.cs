using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Ratings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ratings",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ratings",
                table: "Recipes");
        }
    }
}
