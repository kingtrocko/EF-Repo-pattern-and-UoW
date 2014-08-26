using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelTier;

namespace data
{
  public  class RepoApplicant :MyRepository<Applicant> ,IRepoApplicant  
    {

      public RepoApplicant(DbContext context):base(context) 
      {
      
      }



      //new customize method for applicants
      //gets applicants with specific skill
        public IQueryable<Applicant> GetApplicantsWihSkillName(string SkillName)
        {
            return GetAll().Where(p => p.Skills.Any(o => o.Description.ToLower() == SkillName.ToLower() ));
        }
    }
}
