using EndpointsForMultipleTables.Models;

namespace EndpointsForMultipleTables.Interface
{
    public interface IDepartment
    {
        IEnumerable<Department> GetDep();
        Department GetDepById(int id);
        void CreateDep(Department department);
        void EditDep(Department updatedDepartment);
        void DeleteDep(int id);
        void SaveChanges();
    }
}
