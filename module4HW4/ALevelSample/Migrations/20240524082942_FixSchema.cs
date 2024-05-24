using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ALevelSample.Migrations
{
    public partial class FixSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Categories_category_id",
                table: "Breeds");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Categories_category_id",
                table: "Breeds",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Categories_category_id",
                table: "Breeds");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Categories_category_id",
                table: "Breeds",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
