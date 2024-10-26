using Kazino.Server.Data;
using Kazino.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kazino.Server.Controllers
{
    [ApiController]
    [Route("api/kazino/[controller]")]
    public class KazinoContoller : ControllerBase
    {
        private readonly KazinoContext _context;
        private readonly IPromoRepository _promoRepository;

        public KazinoContoller(KazinoContext context,IPromoRepository repository)
        {
            _context = context;
            _promoRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPromo()
        {
            var promoList = await _promoRepository.GetAllAsync();

            return Ok(promoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromoById([FromRoute] int id)
        {
            var getId = await _promoRepository.GetById(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);

        }

        //[HttpPost]
        //public async Task<IActionResult> CreatePromo()
        //{

        //}
        
    }
}
