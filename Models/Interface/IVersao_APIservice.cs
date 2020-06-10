using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnuncioWebMotors.Models.Interface
{
    public interface IVersao_APIservice
    {
        [Get("/api/OnlineChallenge/Version?ModelID={id}")]
        Task<List<Class_Versao>> GetVersaoAsync(int id);
    }
}
