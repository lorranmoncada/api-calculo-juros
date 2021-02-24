using CalcularJuros.Api.Domain.InterfaceService;
using CalcularJuros.ServiceJuros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.Application.ServiceApp
{
    public class CalculoJurosApp : ICalculoJurosApp
    {
        private readonly ICalcularJurosService _calcularJurosService;

        private readonly IGitService _gitService;
        public CalculoJurosApp(ICalcularJurosService calcularJurosService, IGitService gitService)
        {
            _calcularJurosService = calcularJurosService;
            _gitService = gitService;
        }
        public string GetJurosComposto(int meses, decimal valorInicical, decimal juros)
        {
            return _calcularJurosService.CalcularJurosComposto(meses, valorInicical,juros);
        }

        public Task<IEnumerable<string>> GetRepositorioGit(string user)
        {
            return _gitService.GetRepositorioGit(user);
        }
    }
}
