using AutoMapper;
using MyPortfolio.DAL.DAL.Models;
using MyPortfolio.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPortfolio.DAL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Contactmessage
            CreateMap<Contactmessage, CreateContactUs>();
            CreateMap<CreateContactUs, Contactmessage>();

            CreateMap<Contactmessage, ContactUsResult>();
            CreateMap<ContactUsResult, Contactmessage>();

            //Project
            CreateMap<ProjectResult, Project>();
            CreateMap<Project, ProjectResult>();

            CreateMap<Project, CreateProject>();
            CreateMap<CreateProject, Project>();

            CreateMap<Project, UpdateProject>();
            CreateMap<UpdateProject, Project>();

            //Experience
            CreateMap<ExperienceResult, Experience>();
            CreateMap<Experience, ExperienceResult>();

            CreateMap<Experience, CreateExperience>();
            CreateMap<CreateExperience, Experience>();

            CreateMap<Experience, UpdateExperience>();
            CreateMap<UpdateExperience, Experience>();

            //Education

            CreateMap<EducationResult, Education>();
            CreateMap<Education, EducationResult>();

            CreateMap<Education, CreateEducation>();
            CreateMap<CreateEducation, Education>();

            CreateMap<Education, UpdateEducation>();
            CreateMap<UpdateEducation, Education>();

            //Skill

            CreateMap<SkillResult, Skill>();
            CreateMap<Skill, SkillResult>();

            CreateMap<Skill, CreateSkill>();
            CreateMap<CreateSkill, Skill>();

            CreateMap<Skill, UpdateSkill>();
            CreateMap<UpdateSkill, Skill>();

            //Userprofile

            CreateMap<ProfileResult, Userprofile>();
            CreateMap<Userprofile, ProfileResult>();

            CreateMap<Userprofile, CreateProfile>();
            CreateMap<CreateProfile, Userprofile>();

            CreateMap<Userprofile, UpdateProfile>();
            CreateMap<UpdateProfile, Userprofile>();

            //Projectimage

            CreateMap<ProjectimageResult, Projectimage>();
            CreateMap<Projectimage, ProjectimageResult>();

            CreateMap<Projectimage, AddImagesToProject>();
            CreateMap<AddImagesToProject, Projectimage>();

            CreateMap<Projectimage, UpdateImageForProject>();
            CreateMap<UpdateImageForProject, Projectimage>();

            //Certification

            CreateMap<CertificationResult, Certification>();
            CreateMap<Certification, CertificationResult>();

            CreateMap<Certification, CreateCertification>();
            CreateMap<CreateCertification, Certification>();

            CreateMap<Certification, UpdateCertification>();
            CreateMap<UpdateCertification, Certification>();
        }
    }
}
