using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolucaoSimpar2.Migrations
{
    public partial class Inicialcriacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_caminhao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ds_marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ds_modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ds_placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ds_eixo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_caminhao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_motorista",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ds_nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ds_sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaminhaoId = table.Column<int>(type: "int", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_motorista", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_motorista_tb_caminhao_CaminhaoId",
                        column: x => x.CaminhaoId,
                        principalTable: "tb_caminhao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_viagem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dt_viagem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ds_local_entrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ds_local_saida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ds_km_total = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotoristaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_viagem", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_viagem_tb_motorista_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "tb_motorista",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_motorista_CaminhaoId",
                table: "tb_motorista",
                column: "CaminhaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_viagem_MotoristaId",
                table: "tb_viagem",
                column: "MotoristaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_viagem");

            migrationBuilder.DropTable(
                name: "tb_motorista");

            migrationBuilder.DropTable(
                name: "tb_caminhao");
        }
    }
}
