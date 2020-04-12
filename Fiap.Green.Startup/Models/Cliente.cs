using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Green.Startup.Models
{
   [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("IdCliente")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idcliente { get; set; }
        public DateTime DtUltimaCompra { get; set; }
        public Int64 QntCompras { get; set; }
        public Int64 NrPontos { get; set; }
        public int IdPessoa { get; set; }
        //Navigation Property
        public Pessoa Pessoa {get;set;}

    }
}