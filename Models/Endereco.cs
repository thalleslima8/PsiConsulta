using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PsiConsulta.Models
{
    [DataContract]
    public class Endereco
    {
        [DataMember]
        [Required]
        public int Id { get; set; }
        [DataMember]
        [Required(ErrorMessage = "Logradouro obrigatório!")]
        public string Logradouro { get; set; } = "";
        [DataMember]
        [Required(ErrorMessage = "Obrigatório!")]
        public int Numero { get; set; } = 0;
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Complemento { get; set; } = "";
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Bairro { get; set; } = "";
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Municipio { get; set; } = "";
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string UF { get; set; } = "";
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Cep { get; set; } = "";

        public Endereco() { }
        public Endereco(string log, int n, string comp, string bairro, string mun, string est, string cep)
        {
            Logradouro = log;
            Numero = n;
            Complemento = comp;
            Bairro = bairro;
            Municipio = mun;
            UF = est;
            Cep = cep;
        }
    }
}