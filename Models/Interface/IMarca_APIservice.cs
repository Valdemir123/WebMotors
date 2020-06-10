using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuncioWebMotors.Models.Interface
{
    public interface IMarca_APIservice
    {
        [Get("/api/OnlineChallenge/Make")]
        Task<List<Class_Marca>> GetMarcaAsync();
    }
}
