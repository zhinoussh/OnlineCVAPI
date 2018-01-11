using Microsoft.EntityFrameworkCore;

namespace OnlineCVAPI.Models
{
    public class OnlineCVDBContext : DbContext
    {
        public OnlineCVDBContext(DbContextOptions<OnlineCVDBContext> options)
            : base(options)
        {
        }

        public DbSet<CV> CVs { get; set; }
        public DbSet<PersonalProfile> Profiles { get; set; }
        public DbSet<CVTemplate> CVTemplates { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CV>()
            .HasMany(s=>s.Skills)
            .WithOne(c=>c.cv)
            .IsRequired();

            modelBuilder.Entity<CV>()
            .HasMany(e=>e.Experiences)
            .WithOne(c=>c.cv)
            .IsRequired();

            modelBuilder.Entity<CV>()
            .HasMany(e=>e.Educations)
            .WithOne(c=>c.cv)
            .IsRequired();

            modelBuilder.Entity<CV>()
            .HasOne(t=>t.template)            
            .WithMany(c=>c.CVs);

            modelBuilder.Entity<CV>()
            .HasOne(p=>p.profile)            
            .WithMany(c=>c.CVs);

            //Override table names
            modelBuilder.Entity<CV>().ToTable("CV");
            modelBuilder.Entity<CVTemplate>().ToTable("CVTemplate");
            modelBuilder.Entity<PersonalProfile>().ToTable("PersonalProfile");
            modelBuilder.Entity<Education>().ToTable("Education");            
            modelBuilder.Entity<Experience>().ToTable("WorkHistory");            
            modelBuilder.Entity<Skill>().ToTable("SkillAndCertificate");            
        }
    }
}