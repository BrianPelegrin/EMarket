using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecnoMarket.Infraestructure.Migrations
{
    public partial class statucart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserCreator",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "12/16/2022 21:07:57",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "12/16/2022 00:26:23");

            migrationBuilder.AddColumn<int>(
                name: "StatuId",
                table: "ShoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 16, 21, 7, 57, 150, DateTimeKind.Local).AddTicks(755),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 16, 0, 26, 23, 470, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 16, 21, 7, 57, 146, DateTimeKind.Local).AddTicks(8162),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 16, 0, 26, 23, 467, DateTimeKind.Local).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 7, 57, 146, DateTimeKind.Local).AddTicks(8331));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 7, 57, 146, DateTimeKind.Local).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 7, 57, 146, DateTimeKind.Local).AddTicks(8333));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 7, 57, 150, DateTimeKind.Local).AddTicks(904));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 7, 57, 150, DateTimeKind.Local).AddTicks(905));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 7, 57, 150, DateTimeKind.Local).AddTicks(906));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 7, 57, 152, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 21, 7, 57, 152, DateTimeKind.Local).AddTicks(1406));

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_StatuId",
                table: "ShoppingCarts",
                column: "StatuId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCarts_Status_StatuId",
                table: "ShoppingCarts",
                column: "StatuId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCarts_Status_StatuId",
                table: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCarts_StatuId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "StatuId",
                table: "ShoppingCarts");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreator",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "12/16/2022 00:26:23",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "12/16/2022 21:07:57");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 16, 0, 26, 23, 470, DateTimeKind.Local).AddTicks(4511),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 16, 21, 7, 57, 150, DateTimeKind.Local).AddTicks(755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 16, 0, 26, 23, 467, DateTimeKind.Local).AddTicks(4799),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 16, 21, 7, 57, 146, DateTimeKind.Local).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 0, 26, 23, 467, DateTimeKind.Local).AddTicks(4976));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 0, 26, 23, 467, DateTimeKind.Local).AddTicks(4977));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 0, 26, 23, 467, DateTimeKind.Local).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 0, 26, 23, 470, DateTimeKind.Local).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 0, 26, 23, 470, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 0, 26, 23, 470, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 0, 26, 23, 472, DateTimeKind.Local).AddTicks(5568));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 16, 0, 26, 23, 472, DateTimeKind.Local).AddTicks(5570));
        }
    }
}
