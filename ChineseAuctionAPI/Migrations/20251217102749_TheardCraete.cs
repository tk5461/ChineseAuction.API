using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class TheardCraete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Buyers_UserIdBayer",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Buyers_BuyersIdBayer",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers");

            migrationBuilder.RenameTable(
                name: "Buyers",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IdBayer");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Users_UserIdBayer",
                table: "Card",
                column: "UserIdBayer",
                principalTable: "Users",
                principalColumn: "IdBayer");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_BuyersIdBayer",
                table: "Orders",
                column: "BuyersIdBayer",
                principalTable: "Users",
                principalColumn: "IdBayer",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Users_UserIdBayer",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_BuyersIdBayer",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Buyers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers",
                column: "IdBayer");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Buyers_UserIdBayer",
                table: "Card",
                column: "UserIdBayer",
                principalTable: "Buyers",
                principalColumn: "IdBayer");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Buyers_BuyersIdBayer",
                table: "Orders",
                column: "BuyersIdBayer",
                principalTable: "Buyers",
                principalColumn: "IdBayer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
