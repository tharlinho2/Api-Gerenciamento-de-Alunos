using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alunos.Infra.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar", nullable: false),
                    Email = table.Column<string>(type: "varchar", nullable: false),
                    RA = table.Column<string>(type: "varchar", nullable: false),
                    CPF = table.Column<string>(type: "varchar", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CadastradoEm = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");
        }
    }
}
