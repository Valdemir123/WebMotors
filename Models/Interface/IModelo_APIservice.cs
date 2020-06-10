using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuncioWebMotors.Models.Interface
{
    public interface IModelo_APIservice
    {
        [Get("/api/OnlineChallenge/Model?MakeID={id}")]
        Task<List<Class_Modelo>> GetModeloAsync(int id);
    }
}
