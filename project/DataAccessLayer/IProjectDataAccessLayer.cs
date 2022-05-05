using project.Model;

namespace Project.DataAccessLayer
{
     public interface IProjectDataAccessLayer{
        public bool AddProjectToDatabase(project project);
         public bool RemoveProjectFromDatabase(int departmentId,int projectId);
         public List<Project> GetProjectsFromDatabase();
}