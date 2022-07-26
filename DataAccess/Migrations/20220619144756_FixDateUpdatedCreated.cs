using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class FixDateUpdatedCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                schema: "18118020",
                table: "Rooms",
                newName: "UpdatedDate_18118020");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                schema: "18118020",
                table: "Rooms",
                newName: "CreatedDate_18118020");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                schema: "18118020",
                table: "Amenities",
                newName: "UpdatedDate_18118020");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                schema: "18118020",
                table: "Amenities",
                newName: "CreatedDate_18118020");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate_18118020",
                schema: "18118020",
                table: "Rooms",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate_18118020",
                schema: "18118020",
                table: "Rooms",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdatedDate_18118020",
                schema: "18118020",
                table: "Amenities",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate_18118020",
                schema: "18118020",
                table: "Amenities",
                newName: "CreatedDate");
        }
    }
}
