using ApplicationTrackingSytem.Domain.Entities.User;
using ApplicationTrackingSytem.Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTrackingSystem.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Employer> Employers => Set<Employer>();
        public DbSet<Candidate> Candidates => Set<Candidate>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<CandidateSkill> CandidateSkills => Set<CandidateSkill>();
        public DbSet<CandidateExperience> CandidateExperiences => Set<CandidateExperience>();
        public DbSet<CandidateEducation> CandidateEducations => Set<CandidateEducation>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<JobCategory> JobCategories => Set<JobCategory>();
        public DbSet<JobSkill> JobSkills => Set<JobSkill>();
       // public DbSet<Application> Applications => Set<Application>();
        public DbSet<ApplicationHistory> ApplicationStatusHistories => Set<ApplicationHistory>();
        public DbSet<Interview> Interviews => Set<Interview>();
        public DbSet<EmailLog> EmailLogs => Set<EmailLog>();
        public DbSet<Notification> Notifications => Set<Notification>();

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            // Composite keys
            mb.Entity<CandidateSkill>().HasKey(cs => new { cs.CandidateId, cs.SkillId });
            mb.Entity<JobSkill>().HasKey(js => new { js.JobId, js.SkillId });

            // Unique constraints
            
            mb.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();

            // Enum conversions
            mb.Entity<User>().Property(u => u.Role).HasConversion<string>();
            mb.Entity<Job>().Property(j => j.JobType).HasConversion<string>();
            mb.Entity<Job>().Property(j => j.ExperienceLevel).HasConversion<string>();
            mb.Entity<Job>().Property(j => j.Status).HasConversion<string>();
            mb.Entity<Application>().Property(a => a.Status).HasConversion<string>();
            mb.Entity<CandidateSkill>().Property(cs => cs.Proficiency).HasConversion<string>();
            mb.Entity<Interview>().Property(i => i.InterviewType).HasConversion<string>();
            mb.Entity<EmailLog>().Property(e => e.Status).HasConversion<string>();

            // Decimal precision
            mb.Entity<Job>().Property(j => j.SalaryMin).HasPrecision(12, 2);
            mb.Entity<Job>().Property(j => j.SalaryMax).HasPrecision(12, 2);

            // Cascade rules
            mb.Entity<User>().HasOne(u => u.Employer).WithOne(e => e.User)
                .HasForeignKey<Employer>(e => e.UserId);
            mb.Entity<User>().HasOne(u => u.Candidate).WithOne(c => c.User)
                .HasForeignKey<Candidate>(c => c.UserId);

           

            // Seed
            mb.Entity<JobCategory>().HasData(
                new JobCategory { Id = 1, Name = "Software Engineering" },
                new JobCategory { Id = 2, Name = "Data Science" },
                new JobCategory { Id = 3, Name = "Marketing" },
                new JobCategory { Id = 4, Name = "Finance" },
                new JobCategory { Id = 5, Name = "Human Resources" },
                new JobCategory { Id = 6, Name = "Design" },
                new JobCategory { Id = 7, Name = "Sales" },
                new JobCategory { Id = 8, Name = "Operations" }
            );

            mb.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C#" }, new Skill { Id = 2, Name = ".NET" },
                new Skill { Id = 3, Name = "Angular" }, new Skill { Id = 4, Name = "React" },
                new Skill { Id = 5, Name = "Node.js" }, new Skill { Id = 6, Name = "Python" },
                new Skill { Id = 7, Name = "SQL Server" }, new Skill { Id = 8, Name = "PostgreSQL" },
                new Skill { Id = 9, Name = "Docker" }, new Skill { Id = 10, Name = "Azure" },
                new Skill { Id = 11, Name = "AWS" }, new Skill { Id = 12, Name = "TypeScript" },
                new Skill { Id = 13, Name = "JavaScript" }, new Skill { Id = 14, Name = "Java" },
                new Skill { Id = 15, Name = "Communication" }, new Skill { Id = 16, Name = "Leadership" },
                new Skill { Id = 17, Name = "Agile/Scrum" }, new Skill { Id = 18, Name = "MongoDB" }
            );
        }

    }
}
