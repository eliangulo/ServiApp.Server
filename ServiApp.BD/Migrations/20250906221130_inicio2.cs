using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiApp.BD.Migrations
{
    /// <inheritdoc />
    public partial class inicio2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificacion_Solicitudes_SolicitudId",
                table: "Calificacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitudes_Prestadores_PrestadorId",
                table: "Solicitudes");

            migrationBuilder.DropIndex(
                name: "IX_Solicitudes_PrestadorId",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "IdPrestador",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "PrestadorId",
                table: "Solicitudes");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Validado",
                table: "Prestadores");

            migrationBuilder.RenameColumn(
                name: "IdServicio",
                table: "PrestadorServicio",
                newName: "IDServicio");

            migrationBuilder.RenameColumn(
                name: "IdPrestador",
                table: "PrestadorServicio",
                newName: "IDnumberoMatricula");

            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "Prestadores",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "SolicitudId",
                table: "Calificacion",
                newName: "UsuariosId");

            migrationBuilder.RenameColumn(
                name: "IdSolicitud",
                table: "Calificacion",
                newName: "idUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Calificacion_SolicitudId",
                table: "Calificacion",
                newName: "IX_Calificacion_UsuariosId");

            migrationBuilder.AddColumn<int>(
                name: "idUsuario",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Solicitudes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Servicos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategoria",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Prestadores",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IDdUsuario",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDnumeroMatricula",
                table: "Pagos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrestadorId",
                table: "Pagos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId",
                table: "Pagos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IDnumberoMatricula",
                table: "Calificacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrestadorId",
                table: "Calificacion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    nombre_categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Presupuesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDnumeroMatricula = table.Column<int>(type: "int", nullable: false),
                    PrestadorId = table.Column<int>(type: "int", nullable: true),
                    IDpresupuesto = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    tiempoDuracion = table.Column<int>(type: "int", maxLength: 42, nullable: false),
                    detalle_materiales = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    FechaVto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoRegistro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presupuesto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presupuesto_Prestadores_PrestadorId",
                        column: x => x.PrestadorId,
                        principalTable: "Prestadores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_CategoriaId",
                table: "Servicos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_PrestadorId",
                table: "Pagos",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_UsuariosId",
                table: "Pagos",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_PrestadorId",
                table: "Calificacion",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuesto_PrestadorId",
                table: "Presupuesto",
                column: "PrestadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificacion_Prestadores_PrestadorId",
                table: "Calificacion",
                column: "PrestadorId",
                principalTable: "Prestadores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificacion_Usuarios_UsuariosId",
                table: "Calificacion",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Prestadores_PrestadorId",
                table: "Pagos",
                column: "PrestadorId",
                principalTable: "Prestadores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pagos_Usuarios_UsuariosId",
                table: "Pagos",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_categorias_CategoriaId",
                table: "Servicos",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificacion_Prestadores_PrestadorId",
                table: "Calificacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificacion_Usuarios_UsuariosId",
                table: "Calificacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Prestadores_PrestadorId",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pagos_Usuarios_UsuariosId",
                table: "Pagos");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_categorias_CategoriaId",
                table: "Servicos");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "Presupuesto");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_CategoriaId",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_PrestadorId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Pagos_UsuariosId",
                table: "Pagos");

            migrationBuilder.DropIndex(
                name: "IX_Calificacion_PrestadorId",
                table: "Calificacion");

            migrationBuilder.DropColumn(
                name: "idUsuario",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Prestadores");

            migrationBuilder.DropColumn(
                name: "IDdUsuario",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "IDnumeroMatricula",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "PrestadorId",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "UsuariosId",
                table: "Pagos");

            migrationBuilder.DropColumn(
                name: "IDnumberoMatricula",
                table: "Calificacion");

            migrationBuilder.DropColumn(
                name: "PrestadorId",
                table: "Calificacion");

            migrationBuilder.RenameColumn(
                name: "IDServicio",
                table: "PrestadorServicio",
                newName: "IdServicio");

            migrationBuilder.RenameColumn(
                name: "IDnumberoMatricula",
                table: "PrestadorServicio",
                newName: "IdPrestador");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Prestadores",
                newName: "Contraseña");

            migrationBuilder.RenameColumn(
                name: "idUsuario",
                table: "Calificacion",
                newName: "IdSolicitud");

            migrationBuilder.RenameColumn(
                name: "UsuariosId",
                table: "Calificacion",
                newName: "SolicitudId");

            migrationBuilder.RenameIndex(
                name: "IX_Calificacion_UsuariosId",
                table: "Calificacion",
                newName: "IX_Calificacion_SolicitudId");

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Solicitudes",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IdPrestador",
                table: "Solicitudes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrestadorId",
                table: "Solicitudes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Servicos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Validado",
                table: "Prestadores",
                type: "bit",
                maxLength: 64,
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_PrestadorId",
                table: "Solicitudes",
                column: "PrestadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificacion_Solicitudes_SolicitudId",
                table: "Calificacion",
                column: "SolicitudId",
                principalTable: "Solicitudes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitudes_Prestadores_PrestadorId",
                table: "Solicitudes",
                column: "PrestadorId",
                principalTable: "Prestadores",
                principalColumn: "Id");
        }
    }
}
