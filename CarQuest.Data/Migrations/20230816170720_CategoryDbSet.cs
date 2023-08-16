using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarQuest.Data.Migrations
{
    public partial class CategoryDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarCategory_Cars_CarId",
                table: "CarCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_CarCategory_Category_CategoryId",
                table: "CarCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarCategory",
                table: "CarCategory");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "CarCategory",
                newName: "CarsCategories");

            migrationBuilder.RenameIndex(
                name: "IX_CarCategory_CategoryId",
                table: "CarsCategories",
                newName: "IX_CarsCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarsCategories",
                table: "CarsCategories",
                columns: new[] { "CarId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarsCategories_Cars_CarId",
                table: "CarsCategories",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsCategories_Categories_CategoryId",
                table: "CarsCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarsCategories_Cars_CarId",
                table: "CarsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsCategories_Categories_CategoryId",
                table: "CarsCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarsCategories",
                table: "CarsCategories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "CarsCategories",
                newName: "CarCategory");

            migrationBuilder.RenameIndex(
                name: "IX_CarsCategories_CategoryId",
                table: "CarCategory",
                newName: "IX_CarCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarCategory",
                table: "CarCategory",
                columns: new[] { "CarId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarCategory_Cars_CarId",
                table: "CarCategory",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarCategory_Category_CategoryId",
                table: "CarCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
