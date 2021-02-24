using CalcularJuros.Api.Domain.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.TesteIntegracao.GitResponseTest
{
    public class GitServiceTest : IGitService
    {
        public GitServiceTest() { }
        public async Task<IEnumerable<string>> GetRepositorioGit(string user)
        {
            return new List<string>() { "api1", "api2"};
        }
    }
}
