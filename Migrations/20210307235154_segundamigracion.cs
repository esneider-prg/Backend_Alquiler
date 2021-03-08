using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend_Alquiler.Migrations
{
    public partial class segundamigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlquilerId",
                table: "DetalleAlquileres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleAlquileres_AlquilerId",
                table: "DetalleAlquileres",
                column: "AlquilerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleAlquileres_Alquileres_AlquilerId",
                table: "DetalleAlquileres",
                column: "AlquilerId",
                principalTable: "Alquileres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleAlquileres_Alquileres_AlquilerId",
                table: "DetalleAlquileres");

            migrationBuilder.DropIndex(
                name: "IX_DetalleAlquileres_AlquilerId",
                table: "DetalleAlquileres");

            migrationBuilder.DropColumn(
                name: "AlquilerId",
                table: "DetalleAlquileres");
        }
    }
}
