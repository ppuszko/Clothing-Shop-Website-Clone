using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NikeClone.Data.Migrations
{
    /// <inheritdoc />
    public partial class RedesignCategoryAndProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Types_TypeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_TypeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "MainImageId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryImageId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Types_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Types_TypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MainImageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SecondaryImageId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TypeId",
                table: "Categories",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Types_TypeId",
                table: "Categories",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
