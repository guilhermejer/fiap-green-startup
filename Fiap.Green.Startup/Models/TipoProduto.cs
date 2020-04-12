using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fiap.Green.Startup.Models
{

     [Table("TIPOPRODUTO")]
    public class TipoProduto
    {
        [Key]
        [Column("IdTipoProduto")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoProduto { get; set; }
        public string NomeTipoProduto { get; set; }

    }
}