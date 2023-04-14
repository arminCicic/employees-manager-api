using employees_manager_api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace employees_managamenta_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesManagerController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
            { new Employee {
                Id = 1,
                FirstName = "Armin",
                LastName = "cicic",
                Email = "armincicic@gmail.com",
                Dob = "04.06.1990",
                Gender = "male",
                Education = "diploma",
                Company = "readydev",
                Experience = "two",

                }};

        [HttpGet]        
        public async Task<ActionResult<List<Employee>>> Get()
        {          

            return Ok(employees);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = employees.Find(e => e.Id == id);
            if (employee == null)
            
                return BadRequest("Hero is not found");
                return Ok(employee);
            

            
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            employees.Add(employee);

            return Ok(employees);
        }
    }
}


