using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeCadastroJogos.Migrations
{
    /// <inheritdoc />
    public partial class DBinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGenero = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    IdJogo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeJogo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescricaoJogo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataLancamentoJogo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DesenvJogo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GeneroJogoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.IdJogo);
                    table.ForeignKey(
                        name: "FK_Jogos_Generos_GeneroJogoId",
                        column: x => x.GeneroJogoId,
                        principalTable: "Generos",
                        principalColumn: "IdGenero");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_GeneroJogoId",
                table: "Jogos",
                column: "GeneroJogoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Generos");
        }
    }
}
