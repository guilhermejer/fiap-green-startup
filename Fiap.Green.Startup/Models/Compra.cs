using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Green.Startup.Models
{

    [Table("COMPRA")]
    public class Compra
    {

        [Key]
        [Column("IdCompra")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCompra { get; set; }
        public int IdProduto {get; set;}
        public  Produto Produto { get; set; }
        public int IdTipoProduto { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public int? IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }
        public int IdTipoPagamento { get; set; }
        public Double Preco { get; set; }
        public Guid Ordem { get; set; } 
    }
}