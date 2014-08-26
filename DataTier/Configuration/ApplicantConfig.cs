using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ModelTier;
namespace data
{
    public class ApplicantConfig : EntityTypeConfiguration<Applicant>
    {
        public ApplicantConfig()
        {
            
        }
    }
}
