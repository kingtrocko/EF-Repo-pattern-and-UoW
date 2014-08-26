using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ModelTier;
namespace data
{
    public class CertificationConfig : EntityTypeConfiguration<Certification>
    {
        public CertificationConfig()
        {
            

            // Relationships
            //Certification has relation with applicant.
            //applicant has many Certification (one applicant has many Certification )
            //forign key on Certification is ApplicantID
            this.HasRequired(t => t.Applicant)
                .WithMany(t => t.Certifications)
                .HasForeignKey(d => d.ApplicantID);

        }
    }
}
