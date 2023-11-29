using EndpointsForMultipleTables.Models;

namespace EndpointsForMultipleTables.Interface
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetEmployee();
        Employee GetEmployeeById(int id);
        void CreateEmp(Employee employee);
        void EditEmp(Employee employee);
        void DeleteEmp(int id);
    }
}
