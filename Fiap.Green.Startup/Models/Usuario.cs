using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.Green.Startup.Models
{
    [Table("USUARIO")]
    public class Usuario
    
    {
        [Key]
        [Column("IdUsuario")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool ativo { get; set; }
        public int IdPessoa { get; set; }
        //Navigation Property
        public Pessoa Pessoa {get;set;}
    }
}