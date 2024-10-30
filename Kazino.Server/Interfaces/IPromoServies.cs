using Kazino.Server.Dtos.Promo;
using Kazino.Server.Models;

namespace Kazino.Server.Interfaces
{
    public interface IPromoServies
    {
        Task<List<PromoDto>> GetAllPromo();
        Task<PromoDto?> GetPromoById(int id);
        Task<PromoDto> CreatePromo(CreatePromoRequestDto createPromo);
        Task<bool> DeletePromo(int id);
        Task<PromoDto?> UpdatePromo(int id,UpdatePromoRequestDto updatePromo);
    }
}
