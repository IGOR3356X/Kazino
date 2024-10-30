using Kazino.Server.Dtos.Promo;
using Kazino.Server.Models;

namespace Kazino.Server.Interfaces
{
    public interface IPromoRepository
    {
        Task<List<Promo>> GetAllAsync();
        Task<Promo?> GetByIdAsync(int id);
        Task<Promo> CreatePromoAsync(Promo promoModel);
        Task<Promo?> DeletePromoAsync(int id);
        Task<Promo?> UpdatePromoAsync(int id,UpdatePromoRequestDto updatePromo);
    }
}
