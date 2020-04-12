using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Green.Startup.Models
{
    [Table("TIPOPAGAMENTO")]
    public class TipoPagamento
    {
        [Key]
        [Column("IdTipoPagamento")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoPagamento { get; set; }
        public string Descricao { get; set; }
    }
}