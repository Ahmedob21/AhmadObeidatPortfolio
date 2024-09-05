using System;
using System.Collections.Generic;

namespace MyPortfolio.DAL.DAL.Models;

public partial class Experience
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Company { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }
}
