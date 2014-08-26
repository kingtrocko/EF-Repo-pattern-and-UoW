using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelTier;
namespace data
{
    /// <summary>
    /// this is customized repository interface for applicants 
    /// </summary>
   public interface IRepoApplicant:IRepository<Applicant>
    {
        
        //new customize method for applicants
        //gets applicants with specific skill
        IQueryable<Applicant> GetApplicantsWihSkillName(string SkillName);
 



    }
}
