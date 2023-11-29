using EndpointsForMultipleTables.Interface;
using EndpointsForMultipleTables.Models;
using Microsoft.EntityFrameworkCore;

namespace EndpointsForMultipleTables.Repo
{
    public class EmployeeRepository : IEmployee
    {
        private readonly TaskDatabaseContext _context;
        public EmployeeRepository(TaskDatabaseContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetEmployee()
        {
            return _context.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }
        public void CreateEmp(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public void EditEmp(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void DeleteEmp(int id)
        {
            var EmpToDelete = _context.Employees.Find(id);
            if (EmpToDelete != null)
            {
                _context.Employees.Remove(EmpToDelete);
                _context.SaveChanges();
            }
        }
    }
}
