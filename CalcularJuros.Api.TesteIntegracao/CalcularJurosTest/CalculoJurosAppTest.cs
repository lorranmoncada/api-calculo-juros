using CalcularJuros.Api.Application.ServiceApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.TesteIntegracao
{
    public class CalcularJurosAppTest : ICalculoJurosApp
    {
        private readonly string valorFinal;
        private IEnumerable<string> repoGit;
        public CalcularJurosAppTest()
        {
           valorFinal = "10.05";
           repoGit = new List<string>() { "api1","api2"};
        }

        public string GetJurosComposto(int meses, decimal valorInicical, decimal juros)
        {
            return valorFinal;
        }

        public async Task<IEnumerable<string>> GetRepositorioGit(string user)
        {
            return  repoGit;
        }
    }
}
