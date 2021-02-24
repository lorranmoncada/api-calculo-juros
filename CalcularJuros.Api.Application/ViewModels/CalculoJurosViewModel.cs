using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.Application.ViewModels
{
    // DTO da classe CalculoJuros
    public class CalculoJurosViewModel
    {
        public int Meses { get; set; }
        public decimal ValorInicial { get; set; }
    }
}
