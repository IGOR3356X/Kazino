using System;
using System.Collections.Generic;

namespace Kazino.Server.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public string? Name { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<UserPromo> UserPromos { get; set; } = new List<UserPromo>();
}
