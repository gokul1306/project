
namespace project.DataFactory
{
    public static class DbContextDataFactory{
        public static Departmentcontext GetDepartmentContextObject()
        {
            return new Departmentcontext();
        }
    }
}