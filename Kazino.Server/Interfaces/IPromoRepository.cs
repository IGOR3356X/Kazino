using Kazino.Server.Dtos.Promo;
using Kazino.Server.Models;

namespace Kazino.Server.Interfaces
{
    public interface IPromoRepository
    {
        Task<List<Promo>> GetAllAsync();
        Task<Promo?> GetById(int id);
    }
}
