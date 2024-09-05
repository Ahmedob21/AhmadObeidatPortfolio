using System;
using System.Collections.Generic;

namespace MyPortfolio.DAL.DAL.Models;

public partial class Contactmessage
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Subject { get; set; }

    public string? Message { get; set; }

    public DateTime SendDate { get; set; }
}
