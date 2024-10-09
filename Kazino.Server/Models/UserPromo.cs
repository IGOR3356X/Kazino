using System;
using System.Collections.Generic;

namespace Kazino.Server.Models;

public partial class UserPromo
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PromoId { get; set; }

    public virtual Promo? Promo { get; set; }

    public virtual User? User { get; set; }
}
