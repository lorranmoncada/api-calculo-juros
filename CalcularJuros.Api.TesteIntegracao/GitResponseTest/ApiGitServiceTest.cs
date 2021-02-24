using CalcularJuros.ServiceJuros;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.TesteIntegracao.GitResponseTest
{
    public class ApiGitServiceTest : IApiGitService
    {
        public async Task<List<GitResponse>> GetRepo([AliasAs("user")] string user)
        {
            return new List<GitResponse>();
        }
    }
}
