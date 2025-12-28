using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class initallCrat_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_GiftCategory_CategoryId",
                table: "Gifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GiftCategory",
                table: "GiftCategory");

            migrationBuilder.RenameTable(
                name: "GiftCategory",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Categories_CategoryId",
                table: "Gifts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Categories_CategoryId",
                table: "Gifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "GiftCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiftCategory",
                table: "GiftCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_GiftCategory_CategoryId",
                table: "Gifts",
                column: "CategoryId",
                principalTable: "GiftCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
