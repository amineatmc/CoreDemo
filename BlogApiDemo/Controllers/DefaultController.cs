using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values=c.Employees.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id)
        {
            using var c = new Context();
            var values = c.Employees.Find(id);
            if (values==null)
            {
                return BadRequest(string.Empty);
            }
            return Ok(values);
        }

        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var c = new Context();
            if (employee == null)
            {
                return BadRequest(string.Empty);
            }
            c.Employees.Add(employee);
            c.SaveChanges();
            return Ok(employee);
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var c = new Context();
            var value= c.Employees.Find(employee.Id);
            if (employee == null)
            {
                return BadRequest(string.Empty);
            }
            value.Name=employee.Name;
            c.Employees.Update(value);
            c.SaveChanges();
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult EmployeeDelete(int id)
        {
            using var c = new Context();
            var value = c.Employees.Find(id);
            if (value == null)
            {
                return BadRequest(string.Empty);
            }

            c.Employees.Remove(value);
            c.SaveChanges();
            return Ok(value);
        }
    }
}
