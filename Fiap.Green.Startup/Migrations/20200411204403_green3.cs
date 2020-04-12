using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace Fiap.Green.Startup.Migrations
{
    public partial class green3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RM81792");

            migrationBuilder.CreateTable(
                name: "EMPRESA",
                schema: "RM81792",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NomeEmpresa = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    SegmentoEmpresa = table.Column<string>(nullable: true),
                    ProgramaGreen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPRESA", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "PESSOA",
                schema: "RM81792",
                columns: table => new
                {
                    IdPessoa = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NomePessoa = table.Column<string>(nullable: true),
                    RG = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PESSOA", x => x.IdPessoa);
                });

            migrationBuilder.CreateTable(
                name: "TIPOPAGAMENTO",
                schema: "RM81792",
                columns: table => new
                {
                    IdTipoPagamento = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOPAGAMENTO", x => x.IdTipoPagamento);
                });

            migrationBuilder.CreateTable(
                name: "TIPOPRODUTO",
                schema: "RM81792",
                columns: table => new
                {
                    IdTipoProduto = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NomeTipoProduto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPOPRODUTO", x => x.IdTipoProduto);
                });

            migrationBuilder.CreateTable(
                name: "FORNECEDOR",
                schema: "RM81792",
                columns: table => new
                {
                    IdFornecedor = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<string>(nullable: true),
                    NrVendas = table.Column<long>(nullable: false),
                    IdEmpresa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORNECEDOR", x => x.IdFornecedor);
                    table.ForeignKey(
                        name: "FK_FORNECEDOR_EMPRESA_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalSchema: "RM81792",
                        principalTable: "EMPRESA",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTE",
                schema: "RM81792",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    DtUltimaCompra = table.Column<DateTime>(nullable: false),
                    QntCompras = table.Column<long>(nullable: false),
                    NrPontos = table.Column<long>(nullable: false),
                    IdPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_CLIENTE_PESSOA_IdPessoa",
                        column: x => x.IdPessoa,
                        principalSchema: "RM81792",
                        principalTable: "PESSOA",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                schema: "RM81792",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NomeUsuario = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    ativo = table.Column<bool>(nullable: false),
                    IdPessoa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_USUARIO_PESSOA_IdPessoa",
                        column: x => x.IdPessoa,
                        principalSchema: "RM81792",
                        principalTable: "PESSOA",
                        principalColumn: "IdPessoa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PAGAMENTO",
                schema: "RM81792",
                columns: table => new
                {
                    IdPagamento = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    IdTipoPagamento = table.Column<int>(nullable: false),
                    DadosPagamento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAGAMENTO", x => x.IdPagamento);
                    table.ForeignKey(
                        name: "FK_PAGAMENTO_TIPOPAGAMENTO_IdTipoPagamento",
                        column: x => x.IdTipoPagamento,
                        principalSchema: "RM81792",
                        principalTable: "TIPOPAGAMENTO",
                        principalColumn: "IdTipoPagamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTO",
                schema: "RM81792",
                columns: table => new
                {
                    IdProduto = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    NomeProduto = table.Column<string>(nullable: true),
                    Quantidade = table.Column<long>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: false),
                    IdTipoProduto = table.Column<int>(nullable: false),
                    IdFornecedor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_PRODUTO_FORNECEDOR_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalSchema: "RM81792",
                        principalTable: "FORNECEDOR",
                        principalColumn: "IdFornecedor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRODUTO_TIPOPRODUTO_IdTipoProduto",
                        column: x => x.IdTipoProduto,
                        principalSchema: "RM81792",
                        principalTable: "TIPOPRODUTO",
                        principalColumn: "IdTipoProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COMPRA",
                schema: "RM81792",
                columns: table => new
                {
                    IdCompra = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    IdProduto = table.Column<int>(nullable: false),
                    IdTipoProduto = table.Column<int>(nullable: false),
                    IdEmpresa = table.Column<int>(nullable: true),
                    IdTipoPagamento = table.Column<int>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    Ordem = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPRA", x => x.IdCompra);
                    table.ForeignKey(
                        name: "FK_COMPRA_EMPRESA_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalSchema: "RM81792",
                        principalTable: "EMPRESA",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_COMPRA_PRODUTO_IdProduto",
                        column: x => x.IdProduto,
                        principalSchema: "RM81792",
                        principalTable: "PRODUTO",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMPRA_TIPOPRODUTO_IdTipoProduto",
                        column: x => x.IdTipoProduto,
                        principalSchema: "RM81792",
                        principalTable: "TIPOPRODUTO",
                        principalColumn: "IdTipoProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VENDA",
                schema: "RM81792",
                columns: table => new
                {
                    IdVenda = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    IdEmpresa = table.Column<int>(nullable: true),
                    IdFornecedor = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Estoque = table.Column<long>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    IdProduto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENDA", x => x.IdVenda);
                    table.ForeignKey(
                        name: "FK_VENDA_EMPRESA_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalSchema: "RM81792",
                        principalTable: "EMPRESA",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VENDA_FORNECEDOR_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalSchema: "RM81792",
                        principalTable: "FORNECEDOR",
                        principalColumn: "IdFornecedor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VENDA_PRODUTO_IdProduto",
                        column: x => x.IdProduto,
                        principalSchema: "RM81792",
                        principalTable: "PRODUTO",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_IdPessoa",
                schema: "RM81792",
                table: "CLIENTE",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRA_IdEmpresa",
                schema: "RM81792",
                table: "COMPRA",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRA_IdProduto",
                schema: "RM81792",
                table: "COMPRA",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_COMPRA_IdTipoProduto",
                schema: "RM81792",
                table: "COMPRA",
                column: "IdTipoProduto");

            migrationBuilder.CreateIndex(
                name: "IX_FORNECEDOR_IdEmpresa",
                schema: "RM81792",
                table: "FORNECEDOR",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_PAGAMENTO_IdTipoPagamento",
                schema: "RM81792",
                table: "PAGAMENTO",
                column: "IdTipoPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_IdFornecedor",
                schema: "RM81792",
                table: "PRODUTO",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_IdTipoProduto",
                schema: "RM81792",
                table: "PRODUTO",
                column: "IdTipoProduto");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_IdPessoa",
                schema: "RM81792",
                table: "USUARIO",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_VENDA_IdEmpresa",
                schema: "RM81792",
                table: "VENDA",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_VENDA_IdFornecedor",
                schema: "RM81792",
                table: "VENDA",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_VENDA_IdProduto",
                schema: "RM81792",
                table: "VENDA",
                column: "IdProduto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CLIENTE",
                schema: "RM81792");

            migrationBuilder.DropTable(
                name: "COMPRA",
                schema: "RM81792");

            migrationBuilder.DropTable(
                name: "PAGAMENTO",
                schema: "RM81792");

            migrationBuilder.DropTable(
                name: "USUARIO",
                schema: "RM81792");

            migrationBuilder.DropTable(
                name: "VENDA",
                schema: "RM81792");

            migrationBuilder.DropTable(
                name: "TIPOPAGAMENTO",
                schema: "RM81792");

            migrationBuilder.DropTable(
                name: "PESSOA",
                schema: "RM81792");

            migrationBuilder.DropTable(
                name: "PRODUTO",
                schema: "RM81792");

            migrationBuilder.DropTable(
                name: "FORNECEDOR",
                schema: "RM81792");

            migrationBuilder.DropTable(
                name: "TIPOPRODUTO",
                schema: "RM81792");

            migrationBuilder.DropTable(
                name: "EMPRESA",
                schema: "RM81792");
        }
    }
}
