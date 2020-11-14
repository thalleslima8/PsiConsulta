using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PsiConsulta.Models
{
    [DataContract]
    public class Pessoa
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CPF { get; set; }
        [DataMember]
        public string Nome { get; set; }

       
    }
}
