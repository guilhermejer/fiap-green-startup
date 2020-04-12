using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fiap.Green.Startup.Models
{

    [Table("VENDA")]
    public class Venda
    {
        [Key]
        [Column("IdVenda")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenda { get; set; }
        public int? IdEmpresa { get; set; }
        public Empresa Empresa{ get; set; }
        public int? IdFornecedor { get; set; }
        public Fornecedor Fornecedor{ get; set; }
        public string Descricao { get; set; }
        public Int64 Estoque { get; set; }
        public Double Preco { get; set; }
        public int IdProduto { get; set; }
        public  Produto Produto{ get; set; }
    }
}