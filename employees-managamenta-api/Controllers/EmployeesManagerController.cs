using employees_manager_api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace employees_managamenta_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesManagerController : ControllerBase
    {
        //private static List<Employee> employees = new List<Employee>
        //    { new Employee {
        //        Id = 5,
        //        FirstName = "Armin",
        //        LastName = "cicic",
        //        Email = "armincicic@gmail.com",
        //        Dob = "04.06.1990",
        //        Gender = "male",
        //        Education = "diploma",
        //        Company = "readydev",
        //        Experience = "two",

        //        }};

        private readonly DataContext dataContext;

        public EmployeesManagerController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {

            return Ok(await this.dataContext.Employees.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await this.dataContext.Employees.FindAsync(id);
            if (employee == null)

                return BadRequest("Employee is not found");
            return Ok(employee);



        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employee)
        {
            this.dataContext.Employees.Add(employee);
            await this.dataContext.SaveChangesAsync();

            return Ok(await this.dataContext.Employees.ToListAsync());
        }



        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee request)
        {
            var dbEmployee = await this.dataContext.Employees.FindAsync(request.Id);
            if (dbEmployee == null)

                return BadRequest("Employee is not found");
           

            dbEmployee.FirstName = request.FirstName;
            dbEmployee.LastName = request.LastName;
            dbEmployee.Email = request.Email;
            dbEmployee.Dob = request.Dob;
            dbEmployee.Gender = request.Gender;
            dbEmployee.Education = request.Education;
            dbEmployee.Company = request.Company;
            dbEmployee.Experience = request.Experience;

            await this.dataContext.SaveChangesAsync();

            return Ok(await this.dataContext.Employees.ToListAsync());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> Delete(int id)
        {
            var dbHero = await this.dataContext.Employees.FindAsync(id);
            if (dbHero == null)

                return BadRequest("Employee is not found");
          

            this.dataContext.Employees.Remove(dbHero);
            await this.dataContext.SaveChangesAsync();

            return Ok(await this.dataContext.Employees.ToListAsync());
        }
    }
}


