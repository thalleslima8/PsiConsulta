using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsiConsulta.Models.Financiero
{
    public class Carteira
    {
        public int Id { get; set; }
        public decimal Saldo { get; set; }
        public List<Movimento> Movimentos { get; set; }

        public Carteira()
        {
            Saldo = 0;
        }

        public void AdicionaMovimento(Movimento movimento)
        {
            Movimentos.Add(movimento);
        }

        public decimal GetSaldo()
        {
            return Movimentos.Sum(p => p.Valor);
        }

        public decimal GetSaldoNaData(DateTime initial, DateTime final)
        {
            return Movimentos.Where(p => p.Data >= initial && p.Data <= final).Sum(p => p.Valor);
        }
    }
}