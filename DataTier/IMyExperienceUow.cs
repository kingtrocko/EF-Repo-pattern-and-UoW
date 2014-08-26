using ModelTier;


namespace  data
{
    /// <summary>
    /// Interface for the My Experience Unit of Work"
    /// </summary>
    public interface IMyExperienceUow
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IRepository<Skill> Skills { get; }
        IRepository<Certification> Certifications { get; }
        IRepoApplicant Applicants { get; }
    }
}