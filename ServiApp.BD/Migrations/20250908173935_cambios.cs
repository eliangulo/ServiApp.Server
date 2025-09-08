using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiApp.BD.Migrations
{
    /// <inheritdoc />
    public partial class cambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_categorias_CategoriaId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_CategoriaId",
                table: "Servicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categorias",
                table: "categorias");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "categorias");

            migrationBuilder.RenameTable(
                name: "categorias",
                newName: "Categorias");

            migrationBuilder.RenameColumn(
                name: "descripcion",
                table: "Categorias",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "nombre_categoria",
                table: "Categorias",
                newName: "NombreCategoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "EstadoRegistro", "NombreCategoria" },
                values: new object[,]
                {
                    { 1, "Servicios de cañerías y grifos", 0, "Plomería" },
                    { 2, "Instalaciones y reparaciones eléctricas", 0, "Electricidad" },
                    { 3, "Pintado de interiores y exteriores", 0, "Pintura" },
                    { 4, "Servicios de limpieza para el hogar y oficina", 0, "Limpieza" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_IdCategoria",
                table: "Servicos",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Categorias_IdCategoria",
                table: "Servicos",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Categorias_IdCategoria",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_IdCategoria",
                table: "Servicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "categorias");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "categorias",
                newName: "descripcion");

            migrationBuilder.RenameColumn(
                name: "NombreCategoria",
                table: "categorias",
                newName: "nombre_categoria");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Servicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_categorias",
                table: "categorias",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_CategoriaId",
                table: "Servicos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_categorias_CategoriaId",
                table: "Servicos",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id");
        }
    }
}
