using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Green.Startup.Domain.Entitidades
{
    [Table("TB_EMPRESA")]
    public class Empresa
    {
        [Key]
        [Column("IdEmpresa")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string SegmentoEmpresa { get; set; }
        public bool Green { get; set; }

    }
}