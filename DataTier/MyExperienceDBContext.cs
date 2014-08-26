using System.Data.Entity;
using System.Data.Entity.Infrastructure;
 using ModelTier;

namespace data
{
    public partial class MyExperienceDBContext : DbContext
    {
         

        public MyExperienceDBContext()
            : base("Name=MyExperience")
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Certification> Certifications { get; set; }     
        public DbSet<Skill> Skills { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicantConfig());
            modelBuilder.Configurations.Add(new CertificationConfig());
       
            modelBuilder.Configurations.Add(new SkillConfig());
         
        }

        //static MyExperienceDBContext()
        //{
        //Database.SetInitializer(new MyExperienceDBContextInitializer());
        
        //}

    }
}
