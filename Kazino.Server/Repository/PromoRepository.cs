using Kazino.Server.Data;
using Kazino.Server.Dtos.Promo;
using Kazino.Server.Interfaces;
using Kazino.Server.Mappers;
using Kazino.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Kazino.Server.Repository
{
    public class PromoRepository : IPromoRepository
    {
        private readonly KazinoContext _context;

        public PromoRepository(KazinoContext context)
        {
            _context = context;
        }

        public async Task<Promo> CreatePromoAsync(Promo promoModel)
        {
            await _context.Promos.AddAsync(promoModel);
            await _context.SaveChangesAsync();
            return promoModel;
        }

        public async Task<Promo?> DeletePromoAsync(int id)
        {
            var deletedEntry = await _context.Promos.FirstOrDefaultAsync(x => x.Id == id);

            if (deletedEntry == null)
            {
                return null;
            }

            _context.Promos.Remove(deletedEntry);
            await _context.SaveChangesAsync();
            return deletedEntry;
        }

        public async Task<List<Promo>> GetAllAsync()
        {
            return await _context.Promos.ToListAsync();
        }

        public async Task<Promo?> GetByIdAsync(int id)
        {
            return await _context.Promos.FindAsync(id);
        }

        public async Task<Promo?> UpdatePromoAsync(int id,UpdatePromoRequestDto requestDto)
        {
            var ExitingPromo = await _context.Promos.FirstOrDefaultAsync(x => x.Id == id);

            if (ExitingPromo == null)
            {
                return null;
            }

            ExitingPromo.Title = requestDto.Title;
            ExitingPromo.ShortDiscription = requestDto.ShortDiscription;
            ExitingPromo.PromoText = requestDto.PromoText;
            ExitingPromo.Kod = requestDto.Kod;
            ExitingPromo.CategoryId = requestDto.CategoryId;
            ExitingPromo.LikeCount = requestDto.LikeCount;
            ExitingPromo.Image = requestDto.Image;
            ExitingPromo.StartDatetime = requestDto.StartDatetime;
            ExitingPromo.EndDatime = requestDto.EndDatime;
            ExitingPromo.TagId = requestDto.TagId;

            await _context.SaveChangesAsync();

            return ExitingPromo;
        }
    }
}
