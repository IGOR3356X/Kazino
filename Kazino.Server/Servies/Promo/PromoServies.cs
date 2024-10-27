using Kazino.Server.Dtos.Promo;
using Kazino.Server.Interfaces;
using Kazino.Server.Mappers;
using Kazino.Server.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace Kazino.Server.Servies.Promo
{
    public class PromoServies : IPromoServies
    {
        private readonly IPromoRepository _promoRepo;

        public PromoServies(IPromoRepository repository)
        {
            _promoRepo = repository;
        }

        public async Task<List<PromoDto>> GetAllPromo()
        {
            var promoList = await _promoRepo.GetAllAsync();

            return promoList.Select(p => p.ToPromoDto()).ToList();
        }

        public async Task<PromoDto?> GetPromoById(int id)
        {
            var promoRow = await _promoRepo.GetById(id);

            if (promoRow == null)
            {
                return null;
            }
            else
            {
                return promoRow.ToPromoDto();
            }
        }
    }
}
