	//using UOW facade
	IMyExperienceUow uow = new MyExperienceUow();

   uow.Applicants.Add(newApplicant);
   // commit all changes to DB
   uow.Commit();

   var result= uow.Applicants.GetAll();