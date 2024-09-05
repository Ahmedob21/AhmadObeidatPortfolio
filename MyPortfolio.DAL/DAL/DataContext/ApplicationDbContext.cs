using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.DAL.Models;
using MyPortfolio.DAL.DTOs;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MyPortfolio.DAL.DAL.DataContext;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    // DTOs (not recommended to add DTOs as DbSet)
    public virtual DbSet<CreateContactUs> CreateContactUs { get; set; }
    public virtual DbSet<AddImagesToProject> AddImagesToProjects { get; set; }
    public virtual DbSet<ContactUsResult> ContactUsResults { get; set; }
    public virtual DbSet<CreateCertification> CreateCertifications { get; set; }
    public virtual DbSet<CreateEducation> CreateEducations { get; set; }
    public virtual DbSet<CreateExperience> CreateExperiences { get; set; }
    public virtual DbSet<CreateProfile> CreateProfiles { get; set; }
    public virtual DbSet<CreateProject> CreateProjects { get; set; }
    public virtual DbSet<CreateSkill> CreateSkills { get; set; }
    public virtual DbSet<UpdateCertification> UpdateCertifications { get; set; }
    public virtual DbSet<UpdateEducation> UpdateEducations { get; set; }
    public virtual DbSet<UpdateExperience> UpdateExperiences { get; set; }
    public virtual DbSet<UpdateImageForProject> UpdateImagesForProjects { get; set; }
    public virtual DbSet<UpdateProfile> UpdateProfiles { get; set; }
    public virtual DbSet<UpdateProject> UpdateProjects { get; set; }
    public virtual DbSet<UpdateSkill> UpdateSkills { get; set; }
    public virtual DbSet<CertificationResult> CertificationResults { get; set; }
    public virtual DbSet<EducationResult> EducationResults { get; set; }
    public virtual DbSet<ExperienceResult> ExperienceResults { get; set; }
    public virtual DbSet<ProfileResult> ProfileResults { get; set; }
    public virtual DbSet<ProjectimageResult> ProjectimageResults { get; set; }
    public virtual DbSet<ProjectResult> ProjectResults { get; set; }
    public virtual DbSet<SkillResult> SkillResults { get; set; }













    // Define DbSet properties for your entities
    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<Contactmessage> Contactmessages { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Projectimage> Projectimages { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Userprofile> Userprofiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user id=root;database=portfolio_db;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.HasIndex(e => e.AdminId, "FK_Admin_Id");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AdminId).HasColumnType("int(11)");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.AdminNavigation).WithMany(p => p.Admins)
                .HasForeignKey(d => d.AdminId)
                .HasConstraintName("FK_Admin_Id");
        });

        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("certification");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Authority).HasMaxLength(100);
            entity.Property(e => e.CredentialId).HasMaxLength(100);
            entity.Property(e => e.CredentialUrl).HasMaxLength(255);
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Contactmessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contactmessage");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SendDate).HasColumnType("datetime");
            entity.Property(e => e.Subject).HasMaxLength(255);
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("education");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Degree).HasMaxLength(100);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.FieldOfStudy).HasMaxLength(100);
            entity.Property(e => e.Grade).HasMaxLength(50);
            entity.Property(e => e.Institution).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("experience");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Company).HasMaxLength(100);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("project");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Projectimage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("projectimage");

            entity.HasIndex(e => e.ProjectId, "ProjectId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.ProjectId).HasColumnType("int(11)");

            entity.HasOne(d => d.Project).WithMany(p => p.Projectimages)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("projectimage_ibfk_1");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("skill");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Proficiency).HasMaxLength(100);
        });

        modelBuilder.Entity<Userprofile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("userprofile");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Bio).HasColumnType("text");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.ProfilePictureUrl).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
