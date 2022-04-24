using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn.Migrations
{
    public partial class updateRoomAmenity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenity_Amenities_AmenityID",
                table: "RoomAmenity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity");

            migrationBuilder.DropColumn(
                name: "AmenitiesID",
                table: "RoomAmenity");

            migrationBuilder.AlterColumn<int>(
                name: "AmenityID",
                table: "RoomAmenity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity",
                columns: new[] { "RoomID", "AmenityID" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenity_Amenities_AmenityID",
                table: "RoomAmenity",
                column: "AmenityID",
                principalTable: "Amenities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomAmenity_Amenities_AmenityID",
                table: "RoomAmenity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity");

            migrationBuilder.AlterColumn<int>(
                name: "AmenityID",
                table: "RoomAmenity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AmenitiesID",
                table: "RoomAmenity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomAmenity",
                table: "RoomAmenity",
                columns: new[] { "RoomID", "AmenitiesID" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomAmenity_Amenities_AmenityID",
                table: "RoomAmenity",
                column: "AmenityID",
                principalTable: "Amenities",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
