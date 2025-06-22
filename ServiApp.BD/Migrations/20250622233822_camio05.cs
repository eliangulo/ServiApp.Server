using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiApp.BD.Migrations
{
    /// <inheritdoc />
    public partial class camio05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Calificacion",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PrestadorServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPrestador = table.Column<int>(type: "int", nullable: false),
                    PrestadorId = table.Column<int>(type: "int", nullable: true),
                    IdServicio = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: true),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestadorServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrestadorServicio_Prestadores_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Prestadores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PrestadorServicio_Servicos_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrestadorServicio_PrestadorId",
                table: "PrestadorServicio",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestadorServicio_ServicioId",
                table: "PrestadorServicio",
                column: "ServicioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrestadorServicio");

            migrationBuilder.AlterColumn<string>(
                name: "Comentario",
                table: "Calificacion",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);
        }
    }
}
