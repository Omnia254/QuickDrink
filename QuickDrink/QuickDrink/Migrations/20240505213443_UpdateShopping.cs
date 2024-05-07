using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickDrink.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShopping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartitems_Drinks_DrinkId",
                table: "ShoppingCartitems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartitems",
                table: "ShoppingCartitems");

            migrationBuilder.RenameTable(
                name: "ShoppingCartitems",
                newName: "ShoppingCartItems");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartitems_DrinkId",
                table: "ShoppingCartItems",
                newName: "IX_ShoppingCartItems_DrinkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems",
                column: "ShoppingCartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Drinks_DrinkId",
                table: "ShoppingCartItems",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Drinks_DrinkId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartItems",
                table: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "ShoppingCartItems",
                newName: "ShoppingCartitems");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingCartItems_DrinkId",
                table: "ShoppingCartitems",
                newName: "IX_ShoppingCartitems_DrinkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartitems",
                table: "ShoppingCartitems",
                column: "ShoppingCartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartitems_Drinks_DrinkId",
                table: "ShoppingCartitems",
                column: "DrinkId",
                principalTable: "Drinks",
                principalColumn: "DrinkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
