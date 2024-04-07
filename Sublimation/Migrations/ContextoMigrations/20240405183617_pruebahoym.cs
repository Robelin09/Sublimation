using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sublimation.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class pruebahoym : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "VentasDetalle");

            migrationBuilder.DropColumn(
                name: "ServicioId",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "ComprasDetalle");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "VentasDetalle",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicioId",
                table: "VentasDetalle",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Ventas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Precio",
                table: "Insumos",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "ServiciosDetalle",
                columns: table => new
                {
                    ServiciosDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InsumoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    ServicioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosDetalle", x => x.ServiciosDetalleId);
                    table.ForeignKey(
                        name: "FK_ServiciosDetalle_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "ServicioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosDetalle_ServicioId",
                table: "ServiciosDetalle",
                column: "ServicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiciosDetalle");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "VentasDetalle");

            migrationBuilder.DropColumn(
                name: "ServicioId",
                table: "VentasDetalle");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Insumos");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "VentasDetalle",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ServicioId",
                table: "Ventas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Precio",
                table: "ComprasDetalle",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
