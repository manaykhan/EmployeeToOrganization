using Microsoft.AspNetCore.Mvc;
using CrudAPI.Interface;
using CrudAPI.Contracts;

namespace CrudAPI.Controllers
{

    [ApiController] // marks this class as controller
    [Route("api/[controller]")] // api/Employee
    public class EmployeeController : ControllerBase //inheriting (Employee controller inherits controller base)
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployeeAsync(CreateEmployeeRequest request)
        {
            // Validate the incoming request
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 Bad Request if validation fails
            }

            try
            {
                // Call the service to create a new employee
                await _employeeServices.CreateEmployeeAsync(request);

                // Return success response
                return Ok(new { message = "Employee successfully created" });
            }
            catch (Exception ex)
            {
                // Handle errors and return 500 Internal Server Error
                return StatusCode(500, new { message = "An error occurred while creating the employee", error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var emp = await _employeeServices.GetAllAsync();
                if (emp == null || !emp.Any())
                {
                    return Ok(new { message = "No Employees found" });
                }
                return Ok(new { message = "Successfully retrieved all Employee record.", data = emp });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving all Tood it posts", error = ex.Message });


            }
        }

    }
}