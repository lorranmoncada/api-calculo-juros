using CalcularJuros.Api.Domain.InterfaceService;
using CalcularJuros.Api.Domain.Model;
using CalcularJuros.ServiceJuros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.Domain.Service
{
    public class GitService : IGitService
    {
        private readonly IApiGitService _gitService;
        public GitService(IApiGitService gitService) { _gitService = gitService; }
        public async Task<IEnumerable<string>> GetRepositorioGit(string user)
        {
            IEnumerable<GitResponse> repositorios = await _gitService.GetRepo(user);
            IEnumerable<string> showMeTheCodeRepositorie = repositorios.Select(r => r).Where(n => n.name.Contains("api-taxa-juros") || n.name.Contains("api-calculo-juros")).Select(p => p.html_url).ToList();


            return showMeTheCodeRepositorie;
        }
    }
}
