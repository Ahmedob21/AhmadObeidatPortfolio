using System;
using System.Collections.Generic;

namespace MyPortfolio.DAL.DAL.Models;

public partial class Certification
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Authority { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public string? CredentialId { get; set; }

    public string? CredentialUrl { get; set; }
}
