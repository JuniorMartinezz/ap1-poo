using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ap1_poo.Migrations
{
    /// <inheritdoc />
    public partial class removingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buy_Products_ProductId",
                table: "Buy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buy",
                table: "Buy");

            migrationBuilder.RenameTable(
                name: "Buy",
                newName: "Buys");

            migrationBuilder.RenameIndex(
                name: "IX_Buy_ProductId",
                table: "Buys",
                newName: "IX_Buys_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buys",
                table: "Buys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Products_ProductId",
                table: "Buys",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Products_ProductId",
                table: "Buys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buys",
                table: "Buys");

            migrationBuilder.RenameTable(
                name: "Buys",
                newName: "Buy");

            migrationBuilder.RenameIndex(
                name: "IX_Buys_ProductId",
                table: "Buy",
                newName: "IX_Buy_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buy",
                table: "Buy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buy_Products_ProductId",
                table: "Buy",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
