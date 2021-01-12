using Microsoft.EntityFrameworkCore;
using Skillz.Models.Companies;
using Skillz.Models.Consultants;
using Skillz.Models.Entities;
using Skillz.Models.Entities.Accounts;
using Skillz.Models.Entities.Consultants;
using Skillz.Models.Entities.Evaluations;
using Skillz.Models.Entities.People;
using Skillz.Models.Entities.Profiles;
using Skillz.Models.Entities.Skills;
using Skillz.Models.Evaluations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading;
using System.Threading.Tasks;

namespace Skillz.Data
{
    public class SkillzDbContext : DbContext
    {
        public SkillzDbContext(DbContextOptions<SkillzDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyAllConfigurations<SkillzDbContext>();
        }

        public override int SaveChanges()
        {
            this.AddAuditInfo();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.AddAuditInfo();
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<ConsultantNote> Notes { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<EvaluationQuestionCategory> EvaluationQuestionCategories { get; set; }
        public DbSet<EvaluationQuestionGroup> EvaluationQuestionGroups { get; set; }
        public DbSet<EvaluationQuestion> EvaluationQuestions { get; set; }
        public DbSet<EvaluationResponse> EvaluationResponses { get; set; }
        public DbSet<EvaluationQuestionType> EvaluationQuestionTypes { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ConsultantProfile> ConsultantProfiles { get; set; }
        public DbSet<ConsultantSkill> ConsultantSkills { get; set; }
        public DbSet<SkillProfile> SkillProfiles { get; set; }
        public DbSet<SkillGroup> SkillGroups { get; set; }
        public DbSet<SkillGroupSkill> SkillGroupSkills { get; set; }
        public DbSet<AccountManager> AccountManagers { get; set; }

    }
}
