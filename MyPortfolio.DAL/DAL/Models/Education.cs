using System;
using System.Collections.Generic;

namespace MyPortfolio.DAL.DAL.Models;

public partial class Education
{
    public int Id { get; set; }

    public string Degree { get; set; } = null!;

    public string Institution { get; set; } = null!;

    public string FieldOfStudy { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Grade { get; set; }

    public string? Description { get; set; }
}
