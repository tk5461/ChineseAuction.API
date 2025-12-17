using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class fourthCraete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_UserIdBayer",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_BuyersIdBayer",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Winners_Users_BuyerIdBayer",
                table: "Winners");

            migrationBuilder.DropIndex(
                name: "IX_Winners_BuyerIdBayer",
                table: "Winners");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BuyersIdBayer",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Cards_UserIdBayer",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "BuyerIdBayer",
                table: "Winners");

            migrationBuilder.DropColumn(
                name: "BuyersIdBayer",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserIdBayer",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "IdBayer",
                table: "Winners",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "IdBayer",
                table: "Users",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "IdBayer",
                table: "Orders",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "IdBayer",
                table: "Cards",
                newName: "userId");

            migrationBuilder.AddColumn<int>(
                name: "password",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Winners_userId",
                table: "Winners",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_userId",
                table: "Cards",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_userId",
                table: "Cards",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_userId",
                table: "Orders",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Winners_Users_userId",
                table: "Winners",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Users_userId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_userId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Winners_Users_userId",
                table: "Winners");

            migrationBuilder.DropIndex(
                name: "IX_Winners_userId",
                table: "Winners");

            migrationBuilder.DropIndex(
                name: "IX_Orders_userId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Cards_userId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Winners",
                newName: "IdBayer");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "IdBayer");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Orders",
                newName: "IdBayer");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Cards",
                newName: "IdBayer");

            migrationBuilder.AddColumn<int>(
                name: "BuyerIdBayer",
                table: "Winners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuyersIdBayer",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserIdBayer",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Winners_BuyerIdBayer",
                table: "Winners",
                column: "BuyerIdBayer");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyersIdBayer",
                table: "Orders",
                column: "BuyersIdBayer");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserIdBayer",
                table: "Cards",
                column: "UserIdBayer");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Users_UserIdBayer",
                table: "Cards",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Winners_Users_BuyerIdBayer",
                table: "Winners",
                column: "BuyerIdBayer",
                principalTable: "Users",
                principalColumn: "IdBayer",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
