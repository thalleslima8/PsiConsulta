using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PsiConsulta.Models
{
    [DataContract]
    public class Pessoa
    {
        [DataMember]
        [Required]
        public int Id { get; set; }
        [DataMember]
        [Required(ErrorMessage = "CPF obrigatório!")]
        public string CPF { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string Nome { get; set; }

       
    }
}
