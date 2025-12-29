using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class initallCraet7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Donors_DonorIdDonor",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Orders_Gifts_giftsIdGift",
                table: "Gifts_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Winners_Gifts_giftsIdGift",
                table: "Winners");

            migrationBuilder.DropForeignKey(
                name: "FK_Winners_Users_userId",
                table: "Winners");

            migrationBuilder.DropIndex(
                name: "IX_Winners_giftsIdGift",
                table: "Winners");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_Orders_giftsIdGift",
                table: "Gifts_Orders");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_DonorIdDonor",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "giftsIdGift",
                table: "Winners");

            migrationBuilder.DropColumn(
                name: "giftsIdGift",
                table: "Gifts_Orders");

            migrationBuilder.DropColumn(
                name: "DonorIdDonor",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Winners",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Winners_userId",
                table: "Winners",
                newName: "IX_Winners_UserId");

            migrationBuilder.RenameColumn(
                name: "WinnerUserId",
                table: "Gifts",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Qeuntity",
                table: "Gifts",
                newName: "Quantity");

            migrationBuilder.AlterColumn<string>(
                name: "Identity",
                table: "Users",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Packages",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gifts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Winners_IdGift",
                table: "Winners",
                column: "IdGift");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_Orders_IdGift",
                table: "Gifts_Orders",
                column: "IdGift");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_IdDonor",
                table: "Gifts",
                column: "IdDonor");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_userId",
                table: "Gifts",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donors_IdDonor",
                table: "Gifts",
                column: "IdDonor",
                principalTable: "Donors",
                principalColumn: "IdDonor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Users_userId",
                table: "Gifts",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Orders_Gifts_IdGift",
                table: "Gifts_Orders",
                column: "IdGift",
                principalTable: "Gifts",
                principalColumn: "IdGift",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Winners_Gifts_IdGift",
                table: "Winners",
                column: "IdGift",
                principalTable: "Gifts",
                principalColumn: "IdGift",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Winners_Users_UserId",
                table: "Winners",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Donors_IdDonor",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Users_userId",
                table: "Gifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Orders_Gifts_IdGift",
                table: "Gifts_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Winners_Gifts_IdGift",
                table: "Winners");

            migrationBuilder.DropForeignKey(
                name: "FK_Winners_Users_UserId",
                table: "Winners");

            migrationBuilder.DropIndex(
                name: "IX_Winners_IdGift",
                table: "Winners");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_Orders_IdGift",
                table: "Gifts_Orders");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_IdDonor",
                table: "Gifts");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_userId",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Winners",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Winners_UserId",
                table: "Winners",
                newName: "IX_Winners_userId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Gifts",
                newName: "WinnerUserId");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Gifts",
                newName: "Qeuntity");

            migrationBuilder.AddColumn<int>(
                name: "giftsIdGift",
                table: "Winners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "giftsIdGift",
                table: "Gifts_Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gifts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "DonorIdDonor",
                table: "Gifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Winners_giftsIdGift",
                table: "Winners",
                column: "giftsIdGift");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_Orders_giftsIdGift",
                table: "Gifts_Orders",
                column: "giftsIdGift");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_DonorIdDonor",
                table: "Gifts",
                column: "DonorIdDonor");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Donors_DonorIdDonor",
                table: "Gifts",
                column: "DonorIdDonor",
                principalTable: "Donors",
                principalColumn: "IdDonor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Orders_Gifts_giftsIdGift",
                table: "Gifts_Orders",
                column: "giftsIdGift",
                principalTable: "Gifts",
                principalColumn: "IdGift",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Winners_Gifts_giftsIdGift",
                table: "Winners",
                column: "giftsIdGift",
                principalTable: "Gifts",
                principalColumn: "IdGift",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Winners_Users_userId",
                table: "Winners",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
