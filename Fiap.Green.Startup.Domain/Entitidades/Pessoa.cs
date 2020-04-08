using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Fiap.Green.Startup.Domain.Entitidades
{
    [Table("TB_PESSOA")]
    public class Pessoa
    {
        [Key]
        [Column("IdPessoa")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty(PropertyName = "idPessoa")]
        public int? IdPessoa {get; set;}
        
        [JsonProperty(PropertyName = "nomePessoa")]
        public string NomePessoa { get; set; }
        [JsonProperty(PropertyName = "cpf")]
        public string CPF { get; set; }
        [JsonProperty(PropertyName = "dataNascimento")]
        public string DataNascimento { get; set; }
        [JsonProperty(PropertyName = "endereco")]
        public string Endereco { get; set; }
        [JsonProperty(PropertyName = "cep")]
        public string CEP { get; set; }
        
    }
}
