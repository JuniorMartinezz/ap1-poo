using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ap1_poo.Migrations
{
    /// <inheritdoc />
    public partial class removingAttributeOnBuysTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProduct",
                table: "Buys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProduct",
                table: "Buys",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
