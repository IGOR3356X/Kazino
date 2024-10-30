using Kazino.Server.Data;
using Kazino.Server.Dtos.Promo;
using Kazino.Server.Interfaces;
using Kazino.Server.Mappers;
using Kazino.Server.Repository;
using Kazino.Server.Servies.Promo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kazino.Server.Controllers
{
    [ApiController]
    [Route("api/kazino/[controller]")]
    public class KazinoContoller : ControllerBase
    {
        private readonly KazinoContext _context;
        private readonly IPromoServies _promoServies;

        public KazinoContoller(KazinoContext context,IPromoServies promoServies)
        {
            _context = context;
            _promoServies = promoServies;
        }

        [HttpGet]
        public async Task<IActionResult> GetPromo()
        {
            var promoList = await _promoServies.GetAllPromo();
            //await _promoRepository.GetAllAsync();

            return Ok(promoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId([FromRoute] int id)
        {
            var getId = await _promoServies.GetPromoById(id);

            if (getId == null)
            {
                return NotFound();
            }

            return Ok(getId);

        }
        
        [HttpPost]
        public async Task<IActionResult> CreatePromo([FromBody] CreatePromoRequestDto createPromo) 
        {
            var createResult = await _promoServies.CreatePromo(createPromo);
            return CreatedAtAction(nameof(GetId), new { createResult.Id }, createResult);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeletePromo([FromRoute] int id)
        {
            var deleteResult = await _promoServies.DeletePromo(id);

            if(deleteResult == false)
            {
                return NotFound();
            }

            return NoContent(); 
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdatePromo(int id,UpdatePromoRequestDto updatePromo)
        {
            var updateResult = await _promoServies.UpdatePromo(id, updatePromo);

            if(updatePromo == null)
            {
                return NotFound();
            }

            return Ok(updateResult);
        }
    }
}
