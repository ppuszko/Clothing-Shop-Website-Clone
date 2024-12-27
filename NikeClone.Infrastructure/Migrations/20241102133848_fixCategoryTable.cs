using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NikeClone.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Types_TypeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_TypeId",
                table: "Categories");
        }
    }
}
