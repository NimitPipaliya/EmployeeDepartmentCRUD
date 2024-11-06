using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;
using WebApi.Services.Contract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServices _services;
        public EmployeeController(IServices services)
        {
            _services = services;
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var response = _services.GetAllEmployees();
                if (!response.Success)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        [HttpGet("GetEmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Please enter valid data.");
                }
                else
                {
                    var response = _services.GetEmployeeById(id);
                    return response.Success ? Ok(response) : NotFound(response);
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(AddEmployeeDto addEmployee)
        {
            try
            {
                var response = _services.AddEmployee(addEmployee);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(UpdateEmployeeDto updateEmployee)
        {
            try
            {
                var response = _services.ModifyEmployee(updateEmployee);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        [HttpDelete("RemoveEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var response = _services.RemoveEmployee(id);
                if (!response.Success)
                {
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        [HttpGet("GetAllDepartments")]
        public IActionResult GetAllDeparments()
        {
            try
            {
                var response = _services.GetAllDeparment();
                if (!response.Success)
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
