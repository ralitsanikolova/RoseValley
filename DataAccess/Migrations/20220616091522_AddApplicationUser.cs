using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SqFt",
                schema: "18118020",
                table: "Rooms");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "18118020",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "18118020",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "SqFt",
                schema: "18118020",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
