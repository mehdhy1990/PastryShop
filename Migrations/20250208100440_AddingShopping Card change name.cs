using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PastryShop.Migrations
{
    /// <inheritdoc />
    public partial class AddingShoppingCardchangename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Type_Pies_PieId",
                table: "Type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type",
                table: "Type");

            migrationBuilder.RenameTable(
                name: "Type",
                newName: "ShoppingCardItems");

            migrationBuilder.RenameIndex(
                name: "IX_Type_PieId",
                table: "ShoppingCardItems",
                newName: "IX_ShoppingCardItems_PieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCardItems",
                table: "ShoppingCardItems",
                column: "ShoppingCardItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCardItems_Pies_PieId",
                table: "ShoppingCardItems",
                column: "PieId",
                principalTable: "Pies",
                principalColumn: "PieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCardItems_Pies_PieId",
                table: "ShoppingCardItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCardItems",
                table: "ShoppingCardItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCardItems",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCardItems_PieId",
                table: "Type",
                newName: "IX_Type_PieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type",
                table: "Type",
                column: "ShoppingCardItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Pies_PieId",
                table: "Type",
                column: "PieId",
                principalTable: "Pies",
                principalColumn: "PieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
