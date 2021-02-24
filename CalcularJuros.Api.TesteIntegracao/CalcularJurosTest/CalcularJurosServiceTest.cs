using CalcularJuros.Api.Domain.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.TesteIntegracao
{
    public class CalcularJurosServiceTest : ICalcularJurosService
    {
        public string CalcularJurosComposto(int meses, decimal valorInicial, decimal juros)
        {
            return "105,10";
        }
    }
}
