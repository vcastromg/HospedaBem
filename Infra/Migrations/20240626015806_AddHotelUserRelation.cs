using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddHotelUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManagerId",
                table: "Hotels",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_ManagerId",
                table: "Hotels",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_AspNetUsers_ManagerId",
                table: "Hotels",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_AspNetUsers_ManagerId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_ManagerId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Hotels");
        }
    }
}
