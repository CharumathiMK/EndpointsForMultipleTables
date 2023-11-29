//using EndpointsForMultipleTables.Models;
//using EndpointsForMultipleTables.Repository;
//using EndpointsForMultipleTables.EmpRepository;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace EndpointsForMultipleTables.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {
//        private readonly IEmployee _employeeRepository;

//        public EmployeeController(IEmployee employeeRepository)
//        {
//            _employeeRepository = employeeRepository;
//        }

//        [HttpGet]
//        public ActionResult<IEnumerable<Employee>> Get()
//        {
//            var employees = _employeeRepository.GetEmployee();
//            return Ok(employees);
//        }

//        [HttpGet("{id}")]
//        public ActionResult<Employee> Get(int id)
//        {
//            var employee = _employeeRepository.GetEmployeeById(id);
//            if (employee == null)
//            {
//                return NotFound();
//            }
//            return Ok(employee);
//        }

//        [HttpPost]
//        public ActionResult<Employee> Post([FromBody] Employee employee)
//        {////The [FromBody] attribute indicates that the student parameter is expected to be in the request body. 
//            if (employee == null)
//            {
//                return BadRequest();
//            }

//            _employeeRepository.CreateEmp(employee);
//            return CreatedAtAction("Get", new { id = employee.EmpNo }, employee);
//        }

//        [HttpPut("{id}")]
//        public IActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
//        {
//            var existingEmployee = _employeeRepository.GetEmployeeById(id);

//            if (existingEmployee == null)
//            {
//                return NotFound(); // or BadRequest() depending on your use case
//            }

//            // Update the existing employee with the new values
//            existingEmployee.EmpName = updatedEmployee.EmpName;
//            existingEmployee.DepNo = updatedEmployee.DepNo;

//            _employeeRepository.EditEmp(existingEmployee);

//            return NoContent(); // Indicates success with no response body
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var employee = _employeeRepository.GetEmployeeById(id);
//            if (employee == null)
//            {
//                return NotFound();
//            }

//            _employeeRepository.DeleteEmp(id);
//            return NoContent();
//        }
//    }
//}
