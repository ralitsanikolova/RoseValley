using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class RemoveUnnesesrythings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualCheckIn",
                schema: "18118020",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "ActualCheckOut",
                schema: "18118020",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "IsPaymentSuccessful",
                schema: "18118020",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "StripeSessionId",
                schema: "18118020",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                schema: "18118020",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "TotalDays",
                schema: "18118020",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "18118020",
                table: "RoomBookings");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "18118020",
                table: "RoomBookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                schema: "18118020",
                table: "RoomBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckIn",
                schema: "18118020",
                table: "RoomBookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckOut",
                schema: "18118020",
                table: "RoomBookings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaymentSuccessful",
                schema: "18118020",
                table: "RoomBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StripeSessionId",
                schema: "18118020",
                table: "RoomBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "TotalCost",
                schema: "18118020",
                table: "RoomBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalDays",
                schema: "18118020",
                table: "RoomBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "18118020",
                table: "RoomBookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
