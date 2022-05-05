using PROJECT.Model;

namespace PROJECT.Service
{
    
    public class ProjectService : IProjectService
    {
        private IProjectDataAccessLayer _projectDataAccessLayer = DataFactory.ProjectDataFactory.GetProjectDataAccessLayerObject();
        private Project _project = DataFactory.ProjectDataFactory.GetProjectObject();

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Project Name is not passed to this service method
        */
        public bool CreateProject(int departmentId,string projectName)
        {
            if (departmentId <= 0 || projectName == null)
                throw new ArgumentNullException("DepartmentId or Project Name  is not provided");

            try
            {
                _project.ProjectName = projectName;
                _project.DepartmentId= departmentId;
                return _projectDataAccessLayer.AddProjectToDatabase(_project) ? true : false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Project Id is not passed to this service method
        */

        public bool RemoveProject(int projectId)
        {
            if (projectId <= 0)
                throw new ArgumentNullException("project Id is not provided");

            try
            {
                return _projectDataAccessLayer.RemoveProjectFromDatabase(projectId) ? true :false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Throws Exception when Exception occured in DAL while fetching roles
        */
        public IEnumerable<Project> ViewProjects()
        {
            try
            {
                IEnumerable<Project> projects = new List<Project>();
                return Projects = from project in _projectDataAccessLayer.GetProjectsFromDatabase() where project.IsActive == true select project;
            }
            catch (Exception)
            {
                //Log "Exception occured in DAL while fetching roles"
                throw new Exception();
            }
        }

    }
}