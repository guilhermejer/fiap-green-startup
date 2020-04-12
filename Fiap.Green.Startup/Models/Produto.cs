using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Green.Startup.Models
{
    [Table("PRODUTO")]
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
        public int IdTipoProduto { get; set; }
        public TipoProduto TipoProduto{ get; set;}
        public int? IdFornecedor { get; set; }
        public Fornecedor Fornecedor { get; set; }

    }
}