using employees_manager_api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection;

namespace employees_managamenta_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesManagerController : ControllerBase
    {
     

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

            DateTime datePublished = DateTime.ParseExact(request.DoB.ToString("yyyy-mm-dd"), "yyyy-mm-dd", CultureInfo.InvariantCulture);

            dbEmployee.FirstName = request.FirstName;
            dbEmployee.LastName = request.LastName;
            dbEmployee.Email = request.Email;
            dbEmployee.DoB = datePublished;
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
            var dbEmployee = await this.dataContext.Employees.FindAsync(id);
            if (dbEmployee == null)

                return BadRequest("Employee is not found");
          

            this.dataContext.Employees.Remove(dbEmployee);
            await this.dataContext.SaveChangesAsync();

            return Ok(await this.dataContext.Employees.ToListAsync());
        }
    }
}


