using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NikeClone.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Types");

            migrationBuilder.AddColumn<bool>(
                name: "ForMen",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForMen",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Types",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });
        }
    }
}
