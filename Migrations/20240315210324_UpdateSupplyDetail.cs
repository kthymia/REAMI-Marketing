using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REAMI_Marketing_Sales___Inventory_System.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSupplyDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Supply_Details_Product_ID",
                table: "Supply_Details",
                column: "Product_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Supply_Details_Products_Product_ID",
                table: "Supply_Details",
                column: "Product_ID",
                principalTable: "Products",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supply_Details_Products_Product_ID",
                table: "Supply_Details");

            migrationBuilder.DropIndex(
                name: "IX_Supply_Details_Product_ID",
                table: "Supply_Details");
        }
    }
}
