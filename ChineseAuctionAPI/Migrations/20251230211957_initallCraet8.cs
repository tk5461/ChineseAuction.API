using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class initallCraet8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Packages_PackageIdPackage",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_PackageIdPackage",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "PackageIdPackage",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "PackageIdPackage",
                table: "Gifts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_PackageIdPackage",
                table: "Gifts",
                column: "PackageIdPackage");

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_Packages_PackageIdPackage",
                table: "Gifts",
                column: "PackageIdPackage",
                principalTable: "Packages",
                principalColumn: "IdPackage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_Packages_PackageIdPackage",
                table: "Gifts");

            migrationBuilder.DropIndex(
                name: "IX_Gifts_PackageIdPackage",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "PackageIdPackage",
                table: "Gifts");

            migrationBuilder.AddColumn<int>(
                name: "PackageIdPackage",
                table: "Cards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PackageIdPackage",
                table: "Cards",
                column: "PackageIdPackage");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Packages_PackageIdPackage",
                table: "Cards",
                column: "PackageIdPackage",
                principalTable: "Packages",
                principalColumn: "IdPackage");
        }
    }
}
