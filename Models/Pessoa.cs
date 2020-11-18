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
        [StringLength(11, MinimumLength = 11)]
        public string CPF { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Nome obrigatório!")]
        [StringLength(60, MinimumLength = 3)]
        public string Nome { get; set; }

       
    }
}
