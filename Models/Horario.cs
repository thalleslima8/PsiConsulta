using System;

namespace PsiConsulta.Models
{
    public class Horario
    {
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }

        public Horario(DateTime dateTime)
        {
        }
    }
}