using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuncioWebMotors.Models.Interface
{
    public interface IMercado_APIservice
    {
        [Get("/api/OnlineChallenge/Vehicles?Page={id}")]
        Task<List<Class_Mercado>> GetMercadoAsync(int? id);
    }
}
