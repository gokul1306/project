namespace Project.DataAccessLayer
{
    public ProjectDataAccessLayer : IProjectDataAccessLayer
    {
          {
        private Departmentcontext _db = DataFactory.DbContextDataFactory.GetDepartmentContextObject();

        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role object is not passed 
        */

        //private readonly ILogger _logger = new ILogger<RoleDataAccessLayer>();        
        public bool AddProjectToDatabase(Project project)
        {
            if (project == null)
                throw new ArgumentNullException("DepartmentId and ProjectName is not provided");
            try
            {
                _db.Projects.Add(project);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }
        }



        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role Id is not passed 
        */
        public bool RemoveProjectFromDatabase(int projectId)
        {
            if (projectId <=0 )
                throw new ArgumentNullException("Project Id is not provided ");

            try
            {
                var project = _db.Projects.Find(projectId);
                project.IsActive = false;
                _db.Departments.Update(project);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }

        }

        /*  
            Throws Exception when Exception occured in Database Connectivity
        */
        public List<Project> GetProjectsFromDatabase()
        {
            try
            {
                return _db.Projects.ToList();
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                throw new DbUpdateException();
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                throw new OperationCanceledException();
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                throw new Exception();
            }
        }

    }
}