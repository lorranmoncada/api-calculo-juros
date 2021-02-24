using CalcularJuros.Api.Domain.Model;
using CalcularJuros.ServiceJuros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcularJuros.Api.Domain.InterfaceService
{
    public interface IGitService
    {
        Task<IEnumerable<string>> GetRepositorioGit(string user);

        
    }
}
