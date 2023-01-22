using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAspNetProject.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddExpireForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Expire",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expire",
                table: "Products");
        }
    }
}
