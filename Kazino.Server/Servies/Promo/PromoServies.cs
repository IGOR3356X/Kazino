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
            var promoRow = await _promoRepo.GetByIdAsync(id);

            if (promoRow == null)
            {
                return null;
            }
            else
            {
                return promoRow.ToPromoDto();
            }
        }

        public async Task<PromoDto> CreatePromo(CreatePromoRequestDto createPromo)
        {
            var promoModel = createPromo.ToPromoFromCreateDto();
            var answer = await _promoRepo.CreatePromoAsync(promoModel);
            return answer.ToPromoDto();
        }

        public async Task<bool> DeletePromo(int id)
        {
            var deletedEntry = await _promoRepo.DeletePromoAsync(id);
            if (deletedEntry == null)
            {
                return false;
            }

            return true;
        }

        public async Task<PromoDto?> UpdatePromo(int id, UpdatePromoRequestDto updatePromo)
        {
            var promoModel = await _promoRepo.UpdatePromoAsync(id, updatePromo);

            if (promoModel == null)
            {
                return null;
            }

            return promoModel.ToPromoDto();
        }
    }
}
