using System;
using System.Collections.Generic;

namespace Kazino.Server.Models;

public partial class Promo
{
    public int Id { get; set; }

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

    public virtual Category? Category { get; set; }

    public virtual Tag? Tag { get; set; }

    public virtual ICollection<UserPromo> UserPromos { get; set; } = new List<UserPromo>();
}
