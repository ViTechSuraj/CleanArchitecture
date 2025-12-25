using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Core.DTOs.EmployeeMasterDtos;
using MyApp.Core.DTOs.LoginDtos;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMasterController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeMasterController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // 🔹 CREATE EMPLOYEE
        // POST: api/EmployeeMaster
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeId = await _employeeService.CreateAsync(dto);

            return Ok(new
            {
                message = "Employee created successfully",
                employeeId = employeeId
            });
        }

        // 🔹 UPDATE EMPLOYEE
        // PUT: api/EmployeeMaster/{id}
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _employeeService.UpdateAsync(id, dto);

            return Ok(new
            {
                message = "Employee updated successfully"
            });
        }

        // 🔹 GET ALL EMPLOYEES
        // GET: api/EmployeeMaster
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        // 🔹 GET EMPLOYEE BY ID
        // GET: api/EmployeeMaster/{id}
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
                return NotFound(new { message = "Employee not found" });

            return Ok(employee);
        }

        // 🔹 LOGIN (Used by Login Screen)
        // POST: api/EmployeeMaster/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = await _employeeService.LoginAsync(dto);

            // ⚠️ JWT token abhi add nahi kiya
            // Next step me JWT generate karke yahin return karenge

            return Ok(new
            {
                message = "Login successful",
                employeeId = employee.Id,
                roleId = employee.RoleId,
                centerId = employee.CenterId
            });
        }
    }
}
