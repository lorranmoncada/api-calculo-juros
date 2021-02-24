using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.Domain.InterfaceService
{
    public interface ICalcularJurosService
    {
        string CalcularJurosComposto(int meses, decimal valorInicial, decimal juros);
    }
}
