using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChineseAuctionAPI.Migrations
{
    /// <inheritdoc />
    public partial class initallCraet1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyers",
                columns: table => new
                {
                    IdBayer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhonNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyers", x => x.IdBayer);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    IdDonor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    L_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phonNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.IdDonor);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    IdPackage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount_Regular = table.Column<int>(type: "int", nullable: false),
                    Amount_PrimPremium = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.IdPackage);
                });

            migrationBuilder.CreateTable(
                name: "gifts",
                columns: table => new
                {
                    IdGift = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qeuntity = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDonor = table.Column<int>(type: "int", nullable: false),
                    DonorsIdDonor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gifts", x => x.IdGift);
                    table.ForeignKey(
                        name: "FK_gifts_Donors_DonorsIdDonor",
                        column: x => x.DonorsIdDonor,
                        principalTable: "Donors",
                        principalColumn: "IdDonor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBayer = table.Column<int>(type: "int", nullable: false),
                    BuyersIdBayer = table.Column<int>(type: "int", nullable: false),
                    IdPackage = table.Column<int>(type: "int", nullable: false),
                    PackagesIdPackage = table.Column<int>(type: "int", nullable: false),
                    AmountOrders = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Buyers_BuyersIdBayer",
                        column: x => x.BuyersIdBayer,
                        principalTable: "Buyers",
                        principalColumn: "IdBayer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Packages_PackagesIdPackage",
                        column: x => x.PackagesIdPackage,
                        principalTable: "Packages",
                        principalColumn: "IdPackage",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gifts_Orders",
                columns: table => new
                {
                    IdGiftOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGift = table.Column<int>(type: "int", nullable: false),
                    giftsIdGift = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrdersOrderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts_Orders", x => x.IdGiftOrder);
                    table.ForeignKey(
                        name: "FK_Gifts_Orders_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gifts_Orders_gifts_giftsIdGift",
                        column: x => x.giftsIdGift,
                        principalTable: "gifts",
                        principalColumn: "IdGift",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gifts_DonorsIdDonor",
                table: "gifts",
                column: "DonorsIdDonor");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_Orders_giftsIdGift",
                table: "Gifts_Orders",
                column: "giftsIdGift");

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_Orders_OrdersOrderId",
                table: "Gifts_Orders",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyersIdBayer",
                table: "Orders",
                column: "BuyersIdBayer");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PackagesIdPackage",
                table: "Orders",
                column: "PackagesIdPackage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gifts_Orders");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "gifts");

            migrationBuilder.DropTable(
                name: "Buyers");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Donors");
        }
    }
}
