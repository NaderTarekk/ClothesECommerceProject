using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopShopECommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToClothes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "TbClothes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "TbClothes");
        }
    }
}
