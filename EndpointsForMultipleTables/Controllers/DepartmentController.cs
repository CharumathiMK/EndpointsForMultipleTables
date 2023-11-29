using EndpointsForMultipleTables.Interface;
using EndpointsForMultipleTables.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndpointsForMultipleTables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        //private readonly IDepartment _departmentRepository;
        //private readonly IEmployee _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            //_departmentRepository = departmentRepository;
            //_employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            var departments =_unitOfWork.department.GetDep();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetById(int id)
        {
            var department = _unitOfWork.department.GetDepById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public ActionResult<Department> Post([FromBody] Department department)
        {////The [FromBody] attribute indicates that the student parameter is expected to be in the request body. 
            if (department == null)
            {
                return BadRequest();
            }

            _unitOfWork.department.CreateDep(department);
            return CreatedAtAction("Get", new { id = department.DepNo }, department);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, [FromBody] Department updatedDepartment)
        {
            // Retrieve the existing department from the repository
            var existingDepartment = _unitOfWork.department.GetDepById(id);

            if (existingDepartment == null)
            {
                return NotFound("Department not notfound");
            }

            try
            {
                // Update department properties
                existingDepartment.DepName = updatedDepartment.DepName;
                existingDepartment.Location = updatedDepartment.Location;

                // Update employees associated with the department
                foreach (var updatedEmployee in updatedDepartment.Employees)
                {
                    var existingEmployee = _unitOfWork.employee.GetEmployeeById(updatedEmployee.EmpNo);

                    if (existingEmployee != null)
                    {
                        // Update existing employee properties
                        existingEmployee.EmpName = updatedEmployee.EmpName;

                        // Update employee in repository
                        _unitOfWork.employee.EditEmp(existingEmployee);
                    }
                    
                }

                // Update department in repository
                _unitOfWork.department.EditDep(existingDepartment);

                // Save changes to the database
                _unitOfWork.department.SaveChanges();

                return Ok(updatedDepartment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating department: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDep(int id)
        {
            _unitOfWork.department.DeleteDep(id);
            return Ok();
        }
    }
}
