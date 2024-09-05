﻿using MyPortfolio.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.IService
{
    public interface IProjectService
    {
        Task CreateProject(CreateProject project);
        Task DeleteProject(int projectId);
        Task<IEnumerable<ProjectResult>> AllProjects();
        Task<ProjectResult> GeProjectByProjectId(int projectId);
        Task UpdateProject(UpdateProject project);
    }
}
