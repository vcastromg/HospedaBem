using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddressEntityAndRoomPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Hotels",
                newName: "Rate");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Rooms",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "AddressId",
                table: "Hotels",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    AddressLine = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_AddressId",
                table: "Hotels",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Address_AddressId",
                table: "Hotels",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Address_AddressId",
                table: "Hotels");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_AddressId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Hotels",
                newName: "Longitude");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Hotels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Hotels",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
