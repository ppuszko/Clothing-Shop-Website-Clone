using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NikeClone.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddProductImagePriorityColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImageUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SecondaryImageUrl",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "ProductImages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSecondary",
                table: "ProductImages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "IsSecondary",
                table: "ProductImages");

            migrationBuilder.AddColumn<string>(
                name: "MainImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
