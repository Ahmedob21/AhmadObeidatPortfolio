﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.DTOs
{
    public class UpdateExperience
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Company { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Description { get; set; }
    }
}
