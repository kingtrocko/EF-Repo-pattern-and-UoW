using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ModelTier;
namespace data
{
    public class SkillConfig : EntityTypeConfiguration<Skill>
    {
        public SkillConfig()
        {
            
            // Relationships.
            //skill has relation with applicant.
            //applicant has many skills (one applicant has many skills )
            //forign key on skill is ApplicantID
            this.HasRequired(t => t.Applicant)
                .WithMany(n => n.Skills)
                .HasForeignKey(d => d.ApplicantID);

        }
    }
}
