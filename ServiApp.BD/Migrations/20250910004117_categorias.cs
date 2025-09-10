using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiApp.BD.Migrations
{
    /// <inheritdoc />
    public partial class Categorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "Presupuesto");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "PrestadorServicio");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "EstadoRegistro",
                table: "Calificacion");

            migrationBuilder.RenameColumn(
                name: "IDnumberoMatricula",
                table: "PrestadorServicio",
                newName: "IDnumeroMatricula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDnumeroMatricula",
                table: "PrestadorServicio",
                newName: "IDnumberoMatricula");

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "Presupuesto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "PrestadorServicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "Prestadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoRegistro",
                table: "Calificacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                column: "EstadoRegistro",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "EstadoRegistro",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "EstadoRegistro",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "EstadoRegistro",
                value: 0);
        }
    }
}
