using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiFutebol.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JogadoresFutebol",
                columns: new[] { "Id", "Idade", "Nacionalidade", "Nome", "NumeroCamisa", "Posicao", "Status", "Time" },
                values: new object[] { 1, 39, "Guiana do Brasil", "Cristiano Ronaldo", 7, "Atacante", "Ativo", "Al-nassr" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JogadoresFutebol",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
