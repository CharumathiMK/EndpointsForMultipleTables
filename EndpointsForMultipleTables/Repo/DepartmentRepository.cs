using EndpointsForMultipleTables.Interface;
using EndpointsForMultipleTables.Models;
using Microsoft.EntityFrameworkCore;

namespace EndpointsForMultipleTables.Repo
{
    public class DepartmentRepository : IDepartment
    {
        private readonly TaskDatabaseContext _context;
        public DepartmentRepository(TaskDatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Department> GetDep()
        {
            return _context.Departments.ToList();
        }
        public Department GetDepById(int id)
        {
            return _context.Departments.Find(id);
        }
        public void CreateDep(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }
        public void EditDep(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void DeleteDep(int departmentId)
        {
            var departmentToDelete = _context.Departments
                .Include(d => d.Employees) // Ensure related employees are loaded
                .FirstOrDefault(d => d.DepNo == departmentId);

            if (departmentToDelete != null)
            {
                // Manually delete associated employees
                _context.Employees.RemoveRange(departmentToDelete.Employees);

                // Remove the department
                _context.Departments.Remove(departmentToDelete);

                _context.SaveChanges();
            }
        }
    }
}
