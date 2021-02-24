using CalcularJuros.ServiceJuros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.TesteIntegracao
{
    public class JurosServiceTest : IJurosService
    {
        public async Task<decimal> GetJuros()
        {
            return 0.01M;
        }
    }
}
