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
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Logradouro inválido")]
        public string Logradouro { get; set; } = "";
        [DataMember]
        [Required(ErrorMessage = "Obrigatório!")]
        public int Numero { get; set; } = 0;
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(50, ErrorMessage = "Máximo 50 Caracteres!")]
        public string Complemento { get; set; } = "";
        [DataMember]
        [Required(ErrorMessage = "Bairro obrigatório!")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Bairro inválido")]
        public string Bairro { get; set; } = "";
        [DataMember]
        [Required(ErrorMessage = "Municipio obrigatório!")]
        public string Municipio { get; set; } = "";
        [DataMember]
        [Required(ErrorMessage = "UF obrigatório!")]
        public string UF { get; set; } = "";
        [DataMember]
        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(10, ErrorMessage = "Máximo 10 Caracteres!")]
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