using Kazino.Server.Dtos.Promo;

namespace Kazino.Server.Interfaces
{
    public interface IPromoServies
    {
        Task<List<PromoDto>> GetAllPromo();
        Task<PromoDto?> GetPromoById(int id);

    }
}
