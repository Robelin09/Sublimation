using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sublimation.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class AgregandoImagenes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagenURL",
                table: "ComprasDetalle",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagenURL",
                table: "ComprasDetalle");
        }
    }
}
