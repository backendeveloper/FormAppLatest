using FeesExpensesClaimForm.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FormContext : DbContext
    {
        public FormContext(DbContextOptions<FormContext> options) : base(options) { }

        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        // public DbSet<TaxDeclaration> TaxDeclarations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PersonalInfo>().ToTable("PersonalInfo").HasIndex(x => x.Id);
            // builder.Entity<TaxDeclaration>().ToTable("TaxDeclaration").HasIndex(x => x.Id);
            builder.Entity<Question>(opt =>
                                     {
                                         opt.ToTable("Question");
                                         opt.HasIndex(x => x.Id);

                                     });
            builder.Entity<Answer>(opt =>
                                   {
                                       opt.ToTable("Answers");
                                       opt.HasIndex(x => x.Id);
                                   });
        }
    }
}
