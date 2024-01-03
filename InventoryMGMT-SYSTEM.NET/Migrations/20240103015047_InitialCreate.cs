using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryMGMT_SYSTEM.NET.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item_Type",
                columns: table => new
                {
                    Item_Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Type_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Item_Typ__335FBDF248E18D61", x => x.Item_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "Notification_Type",
                columns: table => new
                {
                    Notification_Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notification_Type_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__7732B56108420CCE", x => x.Notification_Type_ID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Status_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Status__519009AC522F7CB6", x => x.Status_ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    User_Type = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__206D9190B98B7B29", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Item_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Item_Details = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Item_Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true),
                    Item_Type_ID = table.Column<int>(type: "int", nullable: true),
                    Item_Status_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Item__3FB50F949A8F0955", x => x.Item_ID);
                    table.ForeignKey(
                        name: "FK__Item__Item_Statu__04E4BC85",
                        column: x => x.Item_Status_ID,
                        principalTable: "Status",
                        principalColumn: "Status_ID");
                    table.ForeignKey(
                        name: "FK__Item__Item_Type___03F0984C",
                        column: x => x.Item_Type_ID,
                        principalTable: "Item_Type",
                        principalColumn: "Item_Type_ID");
                });

            migrationBuilder.CreateTable(
                name: "Rental_Order",
                columns: table => new
                {
                    Rental_Order_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Start_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    End_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Total_Cost = table.Column<decimal>(type: "decimal(19,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rental_O__AB32D1ABDCEAAD35", x => x.Rental_Order_ID);
                    table.ForeignKey(
                        name: "FK__Rental_Or__User___07C12930",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Notification_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Rental_Order_ID = table.Column<int>(type: "int", nullable: true),
                    Notification_Type_ID = table.Column<int>(type: "int", nullable: true),
                    Notification_Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__8C1160B5CE770171", x => x.Notification_ID);
                    table.ForeignKey(
                        name: "FK__Notificat__Notif__10566F31",
                        column: x => x.Notification_Type_ID,
                        principalTable: "Notification_Type",
                        principalColumn: "Notification_Type_ID");
                    table.ForeignKey(
                        name: "FK__Notificat__Renta__0F624AF8",
                        column: x => x.Rental_Order_ID,
                        principalTable: "Rental_Order",
                        principalColumn: "Rental_Order_ID");
                    table.ForeignKey(
                        name: "FK__Notificat__User___0E6E26BF",
                        column: x => x.User_ID,
                        principalTable: "User",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateTable(
                name: "Rental_Order_Item",
                columns: table => new
                {
                    Rental_Order_ID = table.Column<int>(type: "int", nullable: false),
                    Item_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rental_O__F8C98152F0112091", x => new { x.Rental_Order_ID, x.Item_ID });
                    table.ForeignKey(
                        name: "FK__Rental_Or__Item___0B91BA14",
                        column: x => x.Item_ID,
                        principalTable: "Item",
                        principalColumn: "Item_ID");
                    table.ForeignKey(
                        name: "FK__Rental_Or__Renta__0A9D95DB",
                        column: x => x.Rental_Order_ID,
                        principalTable: "Rental_Order",
                        principalColumn: "Rental_Order_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_Item_Status_ID",
                table: "Item",
                column: "Item_Status_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Item_Type_ID",
                table: "Item",
                column: "Item_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Notification_Type_ID",
                table: "Notification",
                column: "Notification_Type_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Rental_Order_ID",
                table: "Notification",
                column: "Rental_Order_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_User_ID",
                table: "Notification",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_Order_User_ID",
                table: "Rental_Order",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rental_Order_Item_Item_ID",
                table: "Rental_Order_Item",
                column: "Item_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Rental_Order_Item");

            migrationBuilder.DropTable(
                name: "Notification_Type");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Rental_Order");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Item_Type");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
