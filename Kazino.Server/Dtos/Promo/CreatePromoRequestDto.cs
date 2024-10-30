namespace Kazino.Server.Dtos.Promo
{
    public class CreatePromoRequestDto
    {
        public string? Title { get; set; }

        public string? ShortDiscription { get; set; }

        public string? PromoText { get; set; }

        public string? Kod { get; set; }

        public int? CategoryId { get; set; }

        public int? LikeCount { get; set; }

        public string? Image { get; set; }

        public DateTime? StartDatetime { get; set; }

        public DateTime? EndDatime { get; set; }

        public int? TagId { get; set; }
    }
}
