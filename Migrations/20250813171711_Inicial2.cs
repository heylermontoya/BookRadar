using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookRadar.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AutorBuscado",
                table: "HistorialBusquedas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutorBuscado",
                table: "HistorialBusquedas");
        }
    }
}
