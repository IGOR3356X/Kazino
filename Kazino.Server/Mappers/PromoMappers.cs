using Kazino.Server.Dtos.Promo;
using Kazino.Server.Models;

namespace Kazino.Server.Mappers
{
    public static class PromoMappers
    {
        public static PromoDto ToPromoDto(this Promo promoModel)
        {
            return new PromoDto
            {
                Id = promoModel.Id,
                Title = promoModel.Title,
                ShortDiscription = promoModel.ShortDiscription,
                PromoText = promoModel.PromoText,
                Kod = promoModel.Kod,
                CategoryId = promoModel.CategoryId,
                LikeCount = promoModel.LikeCount,
                Image = promoModel.Image,
                StartDatetime = promoModel.StartDatetime,
                EndDatime = promoModel.EndDatime,
                TagId = promoModel.TagId,
            };
        }
    }
}
