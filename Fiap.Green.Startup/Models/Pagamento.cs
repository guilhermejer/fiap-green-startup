using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Green.Startup.Models
{
    [Table("PAGAMENTO")]
    public class Pagamento
    {
        [Key]
        [Column("IdPagamento")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPagamento { get; set; }
        public int IdTipoPagamento { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public string DadosPagamento {get; set;}
    }
}