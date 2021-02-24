using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalcularJuros.ServiceJuros
{
    [Headers("User-Agent: lorranmoncada")]
    public interface IApiGitService
    {

        [Get("/users/{user}/repos")]
        Task<List<GitResponse>> GetRepo([AliasAs("user")]string user);
    }
}

