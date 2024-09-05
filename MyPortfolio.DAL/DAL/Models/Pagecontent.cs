using System;
using System.Collections.Generic;

namespace MyPortfolio.DAL.DAL.Models;

public partial class Pagecontent
{
    public long Pagecontentid { get; set; }

    public string? Pagename { get; set; }

    public string? Contentkey { get; set; }

    public string? Contentvalue { get; set; }
}
