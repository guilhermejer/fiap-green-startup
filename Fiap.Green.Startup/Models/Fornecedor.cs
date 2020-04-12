using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Green.Startup.Models
{
    [Table("FORNECEDOR")]
    public class Fornecedor
    {
        [Key]
        [Column("IdFornecedor")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFornecedor { get; set; }
        public string CNPJ { get; set; }
        public Int64 NrVendas { get; set; }
        public int IdEmpresa { get; set; }
        public Empresa Empresa {get;set;}
        
    }
}