using System;
using System.Collections.Generic;

namespace MyPortfolio.DAL.DAL.Models;

public partial class Projectimage
{
    public int Id { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int? ProjectId { get; set; }

    public virtual Project? Project { get; set; }
}
