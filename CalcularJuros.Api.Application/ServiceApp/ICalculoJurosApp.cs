using CalcularJuros.ServiceJuros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.Application.ServiceApp
{
    public interface ICalculoJurosApp
    {
        string GetJurosComposto(int meses, decimal valorInicical, decimal juros);
        public Task<IEnumerable<string>> GetRepositorioGit(string user);
    }
}
