using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Green.Startup.Domain.Entitidades
{
    [Table("TB_CLIENTE")]
    public class Cliente
    {
        [Key]
        [Column("IdCliente")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idcliente { get; set; }

        public DateTime DtUltimaCompra { get; set; }
        public Int64 QntCompras { get; set; }
        public Int64 NrPontos { get; set; }

        [ForeignKey("IdPessoa")]
        [Required(ErrorMessage= "IdPessoa eh obrigatória!")]
        public int IdPessoa { get; set; }
        
        //Navigation Property
        public Pessoa Pessoa {get;set;}

        [ForeignKey("IdUsuario")]
        [Required(ErrorMessage= "IdUsuario eh obrigatória!")]
        public int IdUsuario { get; set; }
        
        //Navigation Property
        public Usuario Usuario {get;set;}

    }
}