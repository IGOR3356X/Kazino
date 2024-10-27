using Kazino.Server.Dtos.Promo;
using Kazino.Server.Dtos.UserProms;
using Kazino.Server.Models;

namespace Kazino.Server.Mappers
{
    public static class UserPromoMappers
    {
        public static UserPromoDto toUserPromoDto(this UserPromo userPromo)
        {
            return new UserPromoDto
            {
                Id = userPromo.Id,
                PromoId = userPromo.PromoId,
                UserId = userPromo.UserId,
            };
        }
    }
}
