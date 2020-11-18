using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsiConsulta.Models.Financiero
{
    public class Movimento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public Carteira Carteira { get; set; }
        public int CarteiraId { get; set; }

        public Movimento()
        {
        }
        public Movimento(DateTime data, decimal valor, Carteira carteira)
        {
            Data = data;
            Valor = valor;
            Carteira = carteira;
        }

        public void NovoMovimento(Movimento movimento)
        {

        }


    }
}