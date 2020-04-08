using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Green.Startup.Domain.Entitidades
{
    [Table("TB_FORNECEDOR")]
    public class Fornecedor
    {
        [Key]
        [Column("IdFornecedor")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFornecedor { get; set; }
        public string CNPJ { get; set; }
        public Int64 NrVendas { get; set; }
        
        [ForeignKey("Idempresa")]
        public int IdEmpresa { get; set; }
        //Navigation Property
        public Empresa Empresa {get;set;}
        
    }
}