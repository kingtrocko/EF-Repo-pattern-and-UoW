using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using ModelTier;



namespace data
{
    /// <summary>
    /// The "Unit of Work"
    ///     1) decouples the repos from the console,controllers,ASP.NET pages....
    ///     2) decouples the DbContext and EF from the controllers
    ///     3) manages the UoW
    /// </summary>
    /// <remarks>
    /// This class implements the "Unit of Work" pattern in which
    /// the "UoW" serves as a facade for querying and saving to the database.
    /// Querying is delegated to "repositories".
    /// Each repository serves as a container dedicated to a particular
    /// root entity type such as a applicant.
    /// A repository typically exposes "Get" methods for querying and
    /// will offer add, update, and delete methods if those features are supported.
    /// The repositories rely on their parent UoW to provide the interface to the
    /// data .
    /// </remarks>
    public class MyExperienceUow : IMyExperienceUow, IDisposable
    {


        private MyExperienceDBContext DbContext { get; set; }


        public MyExperienceUow()
        {
            CreateDbContext();
           
            
        }

        //repositories
        #region Repositries
        private IRepository<Skill> _skills;
        private IRepository<Certification> _certifications;
        private IRepoApplicant _applicants;
         
        
        //get Skills repo
        public IRepository<Skill> Skills
        {
            get 
            {
                if (_skills == null)
                {
                    _skills = new MyRepository<Skill>(DbContext);
                
                }
                return _skills;
            
            }
        }


        //get Certification repo
        public IRepository<Certification> Certifications
        {
            get
            {
                if (_certifications == null)
                {
                    _certifications = new MyRepository<Certification>(DbContext);

                }
                return _certifications;

            }
        }
        //get aplicants repo
        public IRepoApplicant Applicants
        {
            get
            {
                if (_applicants == null)
                {
                    _applicants = new RepoApplicant(DbContext);

                }

                return _applicants;

            }
        }

        #endregion
         
        /// <summary>
        /// Save pending changes to the database
        /// </summary>
        public void Commit()
        {
             
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new MyExperienceDBContext();
      

        

            // Do NOT enable proxied entities, else serialization fails
            //if false it will not get the associated certification and skills when we get the applicants
            DbContext.Configuration.ProxyCreationEnabled = false;

            // Load navigation properties explicitly (avoid serialization trouble)
           DbContext.Configuration.LazyLoadingEnabled = false;

            // Because Web API will perform validation, we don't need/want EF to do so
            DbContext.Configuration.ValidateOnSaveEnabled = false;

            //DbContext.Configuration.AutoDetectChangesEnabled = false;
            // We won't use this performance tweak because we don't need 
            // the extra performance and, when autodetect is false,
            // we'd have to be careful. We're not being that careful.
        }

         

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion


       
    }
}