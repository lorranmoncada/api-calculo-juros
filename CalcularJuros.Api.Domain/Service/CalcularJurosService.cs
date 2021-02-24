using CalcularJuros.Api.Domain.InterfaceService;
using CalcularJuros.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.Domain.Service
{
    public class CalcularJurosService : ICalcularJurosService
    {
        // A função de calculo do juros composto também poderia ter sido feito dentro da minha camada de serviço 
        // mas achei mais apropriado ser responsabilidade da minha classe CalculoJuros
        public string CalcularJurosComposto(int meses, decimal valorInicial, decimal juros)
        {
            CalculoJuros calculo = new CalculoJuros(meses, valorInicial);

            return calculo.CalcularJurosComposto(juros);
        }
    }
}
