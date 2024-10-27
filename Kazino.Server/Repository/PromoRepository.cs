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
        public async Task<List<Promo>> GetAllAsync()
        {
            return await _context.Promos.ToListAsync();
        }

        public async Task<Promo?> GetById(int id)
        {
            return await _context.Promos.FindAsync(id);
        }
    }
}
