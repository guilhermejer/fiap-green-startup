using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fiap.Green.Startup.Domain.Entitidades
{
    [Table("TB_PRODUTO")]
    public class Produto
    {
        [Key]
        [Column("IdProduto")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public Int64 Quantidade { get; set; }
        public bool Ativo { get; set; }
        public double Preco { get; set; }
        public DateTime DataAtualizacao { get; set; }
        
        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; }
        public Fornecedor Fornecedor { get; set; }

    }
}