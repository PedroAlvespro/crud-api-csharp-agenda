using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRIMAPAPI.Migrations.Linha
{
    /// <inheritdoc />
    public partial class LinhaTel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Linha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLinha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtivoLinha = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linha", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Linha");
        }
    }
}
