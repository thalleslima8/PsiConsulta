using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsiConsulta.Models.Enums
{
    public enum StatusConsulta
    {
        Agendada = 0,
        Realizada = 1,
        PendentePagamento = 2,
        PagamentoOk = 3,
        Cancelada = 4
    }
}
