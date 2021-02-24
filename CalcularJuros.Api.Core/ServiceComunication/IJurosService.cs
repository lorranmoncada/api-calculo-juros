using Refit;
using System.Threading.Tasks;

namespace CalcularJuros.ServiceJuros
{
    public interface IJurosService
    {
        [Get("/api/taxajuros")]
        Task<decimal> GetJuros();
    }
}
