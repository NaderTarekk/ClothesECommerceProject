using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopShopECommerceProject.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToClothesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "TbClothes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "TbClothes");
        }
    }
}
