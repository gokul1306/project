using project.Model;
namespace project.Service
{
    public interface IProjectService
    {
        public  bool CreateProject(string projectName);
        public bool RemoveProject(int projectId);
        public IEnumerable<Project> ViewProjects();
    }
}