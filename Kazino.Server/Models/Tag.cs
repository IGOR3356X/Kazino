using System;
using System.Collections.Generic;

namespace Kazino.Server.Models;

public partial class Tag
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Promo> Promos { get; set; } = new List<Promo>();
}
