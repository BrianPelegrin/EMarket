using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecnoMarket.Infraestructure.Migrations
{
    public partial class probando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatuId",
                table: "Pictures");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreator",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "12/15/2022 21:40:15",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "12/14/2022 18:31:17");

            migrationBuilder.AddColumn<int>(
                name: "StatuId1",
                table: "ProductsPictures",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 15, 21, 40, 15, 943, DateTimeKind.Local).AddTicks(1422),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 14, 18, 31, 17, 548, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 15, 21, 40, 15, 937, DateTimeKind.Local).AddTicks(5883),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 14, 18, 31, 17, 546, DateTimeKind.Local).AddTicks(9483));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 15, 21, 40, 15, 937, DateTimeKind.Local).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 15, 21, 40, 15, 937, DateTimeKind.Local).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 12, 15, 21, 40, 15, 937, DateTimeKind.Local).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 15, 21, 40, 15, 943, DateTimeKind.Local).AddTicks(1673));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 15, 21, 40, 15, 943, DateTimeKind.Local).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 12, 15, 21, 40, 15, 943, DateTimeKind.Local).AddTicks(1678));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 15, 21, 40, 15, 946, DateTimeKind.Local).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 15, 21, 40, 15, 946, DateTimeKind.Local).AddTicks(2047));

            migrationBuilder.CreateIndex(
                name: "IX_ProductsPictures_StatuId1",
                table: "ProductsPictures",
                column: "StatuId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPictures_Status_StatuId1",
                table: "ProductsPictures",
                column: "StatuId1",
                principalTable: "Status",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPictures_Status_StatuId1",
                table: "ProductsPictures");

            migrationBuilder.DropIndex(
                name: "IX_ProductsPictures_StatuId1",
                table: "ProductsPictures");

            migrationBuilder.DropColumn(
                name: "StatuId1",
                table: "ProductsPictures");

            migrationBuilder.AlterColumn<string>(
                name: "UserCreator",
                table: "Status",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "12/14/2022 18:31:17",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "12/15/2022 21:40:15");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 14, 18, 31, 17, 548, DateTimeKind.Local).AddTicks(7071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 15, 21, 40, 15, 943, DateTimeKind.Local).AddTicks(1422));

            migrationBuilder.AddColumn<int>(
                name: "StatuId",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 14, 18, 31, 17, 546, DateTimeKind.Local).AddTicks(9483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 12, 15, 21, 40, 15, 937, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 31, 17, 546, DateTimeKind.Local).AddTicks(9628));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 31, 17, 546, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 31, 17, 546, DateTimeKind.Local).AddTicks(9630));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 31, 17, 548, DateTimeKind.Local).AddTicks(7181));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 31, 17, 548, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 31, 17, 548, DateTimeKind.Local).AddTicks(7183));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 31, 17, 550, DateTimeKind.Local).AddTicks(1637));

            migrationBuilder.UpdateData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 14, 18, 31, 17, 550, DateTimeKind.Local).AddTicks(1638));
        }
    }
}
